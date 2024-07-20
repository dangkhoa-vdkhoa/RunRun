using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextgame : MonoBehaviour
{
    [SerializeField] private AudioSource winsound;
    [SerializeField]private GameObject win;
    // Start is called before the first frame update
    private void Start()
    {
        winsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "hero")
        {
            winsound.Play();
            Invoke("completelevel", 2f);
            GameObject phaohoa = Instantiate(win, collision.transform.position, collision.transform.rotation);
            Destroy(phaohoa, 3);

        }
    }
    private void completelevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
