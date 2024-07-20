using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private float driX = 0f;
    [SerializeField] private float tocdo = 10f;
    [SerializeField] private float lucnhay = 14f;

    private int jumpCount = 0;
    [SerializeField] private int maxJumpCount = 2;
    [SerializeField] private AudioSource jumsound;
    [SerializeField] private AudioSource chamnensound;

    private bool isPaused = false;

    private enum MovementState { idle, running, jumping,falling}


    //private MovementState satate = MovementState.idle;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();    
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    private void Update()
    {

        driX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (driX * tocdo, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            jumsound.Play();
            rb.velocity = new Vector2(rb.velocity.x, lucnhay);
            jumpCount++;

        }

        if (Input.GetKeyDown(KeyCode.Escape)) // You can use any key or condition to toggle pause
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        updateanimation();
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // This pauses the game
        isPaused = true;
        // You may also want to show a pause menu or overlay here
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // This resumes the game
        isPaused = false;
        // If you have a pause menu or overlay, you may want to hide it here
    }

    private void updateanimation()
    {
        MovementState state;
        if (driX > 0f)
        {
            

            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (driX < 0f)
        {
            
            
            state = MovementState.running;
            sprite.flipX = true;

        }
        else
        {
            
            state = MovementState.idle;
        }
       
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state",(int)state);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "nen")
        {
            chamnensound.Play();
            jumpCount = 0;
        }
    }





}
