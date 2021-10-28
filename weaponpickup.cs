using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponpickup : MonoBehaviour
{

    public bool isInArea;

    public Dialogue dialogue;

    public void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInArea == true)
            {
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInArea = false;
        }
    }
}
