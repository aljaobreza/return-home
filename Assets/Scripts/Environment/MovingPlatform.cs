using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform leftEdge, rightEdge;
    public Transform startPosition;
    public float speed;
    
    Vector2 nextPosition;

    void Start()
    {
        nextPosition = startPosition.position;
    }

    void Update()
    {
        /*za premikanje platforme od ene toèke do druge*/
        if(transform.position == leftEdge.position)
        {
            nextPosition = rightEdge.position;
        }
        if (transform.position == rightEdge.position)
        {
            nextPosition = leftEdge.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }

    /*za vizualizacijo poti platforme*/
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(leftEdge.position, rightEdge.position);
    }

    /*ko player pristane na platformi postane njen child object in se premika z njo*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    /*ko gre player z platforme ni veè njen child object in se premika neodvisno od nje*/
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
