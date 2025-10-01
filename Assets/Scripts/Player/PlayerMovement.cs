
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    [SerializeField] private float speed;
    [SerializeField] private float jmpHeight;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool doubleJump;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private void Awake()
    {
        //dobi reference za rigidBody in Animator iz objektov
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //obrne player sprite v smer gibanja
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector2(2, 2);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector2(-2, 2);


        if (Input.GetKeyDown(KeyCode.Space)){
            if (grounded || doubleJump)
            {
                Jump();
                SoundManager.instance.PlaySound(jumpSound);
            }
        }

        //nastavi animacije
        anim.SetBool("walk", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jmpHeight);
        anim.SetTrigger("jump");
        grounded = false;
        doubleJump = !doubleJump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            grounded = true;
            anim.SetTrigger("land");
        }
    }
}
