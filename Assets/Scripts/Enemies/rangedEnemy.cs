using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Ranged Attack")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    /*references*/
    private Animator anim;
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

    private void RangedAttack()
    {
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindFireball()
    {
        for(int i = 0; i < fireballs.Length; i++)
        {
            if (fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    /*sets enemy sight*/
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, /*origin*/
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), /*size*/
            0, Vector2.right, 0, playerLayer); /*angle, direction, distance, layer*/

        return hit.collider != null; /*true, if the player is in sight*/
    }

    /*to visualise enemy sight*/
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
