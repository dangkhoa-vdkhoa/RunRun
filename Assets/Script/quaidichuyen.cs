using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quaidichuyen : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int current = 0;
    [SerializeField] private float speed = 5f;
    private SpriteRenderer sprite;


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Vector2.Distance(waypoints[current].transform.position, transform.position) < .1f)
        {
            sprite.flipX = true;
            current++;
            if (current >= waypoints.Length)
            {
                sprite.flipX = false;
                current = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[current].transform.position, Time.deltaTime * speed);


    }
}
