using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    public float startX, endX;
    public float yOffsetAbovePlayer = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        var playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        var camX = transform.position.x;
        //float camY = fixedY;

        if (playerX > startX && playerX < endX)
        {
            camX = playerX;

        }
        else
        {
            if (playerX < startX)
            {
                camX = startX;
            }
            if (playerX > endX)
            {
                camX = endX;
            }
        }
        float camY = playerY + yOffsetAbovePlayer;

        transform.position = new Vector3(camX, camY, -10);
    }
}
