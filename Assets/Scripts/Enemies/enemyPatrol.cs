using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initialScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initialScale = enemy.localScale;
    }

    /*when enemyPatrol gets disabled the moving animation stops*/
    private void OnDisable()
    {
        anim.SetBool("walking", false);
    }

    private void Update()
    {
        /*moves left untill hitting left edge*/
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        /*moves right untill hitting right edge*/
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
        
    }
    
    private void DirectionChange()
    {
        anim.SetBool("walking", false);

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
            movingLeft = !movingLeft; /*if movingLeft is true it changes to false and vice versa*/
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("walking", true);

        /*make enemy face a direction*/
        enemy.localScale = new Vector3(Mathf.Abs(initialScale.x) * _direction, 
            initialScale.y, initialScale.z);

        /*make enemy move in that direction*/
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, /*x axis*/
            enemy.position.y, enemy.position.z);
    }
}
