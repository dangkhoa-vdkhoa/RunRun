using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class itemcollider : MonoBehaviour
{

    private int cherries = 0;
    public GameObject votan;

    [SerializeField] private Text cherriestext;
    [SerializeField] private AudioSource cherrysound;


     private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Cherry"))
            {

            cherrysound.Play();
                Destroy(collision.gameObject);
                cherries++;
                Debug.Log("cherries: " + cherries);
            cherriestext.text = " " + cherries;

            //hieu ung vo ra
            GameObject votanra = Instantiate(votan, collision.transform.position, collision.transform.rotation);
            Destroy(votanra,3);
            }
        }



}
