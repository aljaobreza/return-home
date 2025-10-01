using UnityEngine;

public class Stomper : MonoBehaviour
{
    public int damage;

    private Rigidbody2D rb;
    public float bounceForce;

    void Start()
    {
        /*gets the Rigidbody component from it's parent object*/
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "HurtBox")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            rb.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
