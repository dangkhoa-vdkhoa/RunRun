using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vatlythambay : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int current = 0;
    [SerializeField] private float speed = 3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "hero")
        {
            collision.gameObject.transform.SetParent(transform);
        }
        if (collision.gameObject.CompareTag("cham")){
            Destroy(collision.gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "hero")
        {
            collision.gameObject.transform.SetParent(null);

        }

    }

    private void Update()
    {
        if (Vector2.Distance(waypoints[current].transform.position, transform.position) < .1f)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[current].transform.position, Time.deltaTime * speed);


    }
}
