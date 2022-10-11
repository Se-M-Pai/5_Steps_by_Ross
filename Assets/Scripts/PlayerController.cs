using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 15f;

    private int lockLevel = 0;

    private bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public InteractController interactController;
    public NextLevelScript Restart;

    public static PlayerController Instance { get; set; }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal") && gameObject.tag == "Player1")
        {
            RunPlayer1();
        }
        else anim.SetBool("Run1", false);
        if (Input.GetButton("Horizontal2") && gameObject.tag == "Player2")
        {
            RunPlayer2();
        }
        else anim.SetBool("Run2", false);
        if (isGrounded && Input.GetButtonDown("Jump") && gameObject.tag == "Player1")
        {
            JumpPlayer1();
        }
        if (isGrounded && gameObject.tag == "Player1") anim.SetBool("Jump1", false);
        if (isGrounded && Input.GetButtonDown("Jump2") && gameObject.tag == "Player2")
        {
            JumpPlayer2();
        }
        if (isGrounded && gameObject.tag == "Player2") anim.SetBool("Jump2", false);

        Debug.Log(PlayerPrefs.GetInt("levelAccess"));
    }

    private void RunPlayer1()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
        if (isGrounded) anim.SetBool("Run1", true);
    }
    private void RunPlayer2()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal2");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
        if (isGrounded) anim.SetBool("Run2", true);
    }

    private void JumpPlayer1()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        anim.SetBool("Jump1", true);
    }
    private void JumpPlayer2()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        anim.SetBool("Jump2", true);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "level")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "restart")
        {
            Restart.Restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Circle1")
        {
            lockLevel += 1;
            Stop();
        }
        if (collision.gameObject.name == "Circle2")
        {
            lockLevel += 1;
            Stop();
        }
    }

    public void Stop()
    {
        speed = 0f;
        jumpForce = 0f;
        interactController.LockLevel();
    }

    public enum States
    {
        funhero_idle,
        sadhero_idle,
        funhero_jump,
        sadhero_jump,
        funhero_use,
        sadhero_use,
        funhero_run,
        sadhero_run
    }
}