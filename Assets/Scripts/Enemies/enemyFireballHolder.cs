using UnityEngine;

public class enemyFireballHolder : MonoBehaviour
{
    [SerializeField] private Transform enemy;

    /*makes fireballs fly in the right direction when the enemy is turned either way*/
    private void Update()
    {
        transform.localScale = enemy.localScale;
    }
}
