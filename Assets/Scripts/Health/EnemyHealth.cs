using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHP;
    public int currentHP;
    
    void Start()
    {
        currentHP = enemyHP;
    }

    void Update()
    {
        if(currentHP <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }
}
