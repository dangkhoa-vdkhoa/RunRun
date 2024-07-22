using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [SerializeField] private GameObject Menu;

    private bool isPaused = false;
    private bool moveLeft = false;
    private bool moveRight = false;
    private bool jump = false;

    private enum MovementState { idle, running, jumping, falling }

    private void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Di chuyển bằng phím máy tính hoặc button
        if (moveLeft)
        {
            driX = -1f;
        }
        else if (moveRight)
        {
            driX = 1f;
        }
        else
        {
            driX = Input.GetAxisRaw("Horizontal");
        }

        rb.velocity = new Vector2(driX * tocdo, rb.velocity.y);

        // Nhảy bằng phím máy tính hoặc button
        if ((Input.GetButtonDown("Jump") || jump) && jumpCount < maxJumpCount)
        {
            jumsound.Play();
            rb.velocity = new Vector2(rb.velocity.x, lucnhay);
            jumpCount++;
            jump = false; // Reset jump sau khi nhảy
        }

        if (Input.GetKeyDown(KeyCode.P)) // Toggle pause
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

    public void MoveLeftButtonDown()
    {
        moveLeft = true;
    }

    public void MoveLeftButtonUp()
    {
        moveLeft = false;
    }

    public void MoveRightButtonDown()
    {
        moveRight = true;
    }

    public void MoveRightButtonUp()
    {
        moveRight = false;
    }

    public void JumpButtonDown()
    {
        jump = true;
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Pauses the game
        isPaused = true;
        Menu.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Resumes the game
        isPaused = false;
        Menu.SetActive(false);
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

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
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
