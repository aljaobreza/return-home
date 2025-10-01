using UnityEngine;

public class flyingEnemy : MonoBehaviour
{
    public float speed;
    [SerializeField] private float damage;
    private GameObject player;
    public bool chase = false;
    public Transform startingPoint;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        if (chase)
            Chase();
        else
            ReturnStartPoint();

        Flip();
    }
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }
    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }
    private void Flip()
    {
        if(transform.position.x > player.transform.position.x)
            transform.localScale = new Vector2(-1, 1);
        else
            transform.localScale = new Vector2(1, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
