using UnityEngine;

public class EnemyProjectile : EnemyDamage /*inherits from EnemyDamage script*/
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision); /*executes parent script (EnemyDamage) first*/

        /*if (anim != null)
            anim.SetTrigger("explode"); /*explodes the projectile if it has an animator*/
        /*else
            gameObject.SetActive(false); /*deactivates the projectile when hitting something*/
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
