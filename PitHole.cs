using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PitHole : MonoBehaviour
{

    public bool isInRange;
    public void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(isInRange == true)
            {
                SceneManager.LoadScene("PitHole");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;  
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = false;
        }
    }
}
