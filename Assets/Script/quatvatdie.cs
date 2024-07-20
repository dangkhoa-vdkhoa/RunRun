using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class quatvatdie : MonoBehaviour
{

    private int conchon = 0;
    [SerializeField] private Text conchonext;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("quai"))
        {
            Destroy(collision.gameObject);
            conchon++;
            Debug.Log("conchon: " + conchon);
            conchonext.text = " " + conchon;
        }
    }
}
