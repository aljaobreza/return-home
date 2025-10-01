using UnityEngine;

public class meleeEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    
    /*references*/
    private Animator anim;
    private Health playerHealth;
    private enemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<enemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        /*if player is in sight, enemy attacks*/
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
        }

        /*if enemy sees the player they stop patrolling*/
        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    /*sets enemy sight*/
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, /*origin*/
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), /*size*/
            0, Vector2.right, 0, playerLayer); /*angle, direction, distance, layer*/

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null; /*true, if the player is in sight*/
    }

    /*to visualise enemy sight*/
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        /*if player is still in range, damage them*/
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
