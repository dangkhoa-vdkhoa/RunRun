using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hero_die : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource diesound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap")) {
            Die();
        }
    }
    public void Die()
    {
        diesound.Play();
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }
    private void Restarlevel()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
