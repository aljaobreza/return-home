using UnityEngine;

public class ChaseControl : MonoBehaviour
{
    public flyingEnemy[] enemyArray;
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Player"))
        {
            foreach (flyingEnemy enemy in enemyArray)
            {
                enemy.chase = true;
                enemy.speed = 3;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            foreach (flyingEnemy enemy in enemyArray)
            {
                enemy.chase = false;
                enemy.speed = 1;
            }
        }
    }
}
