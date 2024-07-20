using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack_die : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hero_die die = collision.gameObject.GetComponent<hero_die>();
            die.Die();
            Debug.Log("find Player");
        }
    }
}
