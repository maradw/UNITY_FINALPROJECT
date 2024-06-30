using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Blue")
        {
            Debug.Log("blue");
        }
        else if (collision.tag == "Red")
        {
            Debug.Log("red");
        }
        else if (collision.tag == "Green")
        {
            Debug.Log("green");
        }
        else if (collision.tag == "Yellow")
        {
            Debug.Log("yellow");
        }
        else if (collision.tag == "Damage")
        {
            Debug.Log("yellow");
        }
    }*/
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Blue")
        {
            Debug.Log("blue");
        }
        else if(other.tag== "Red")
        {
            Debug.Log("red");
        }
        else if (other.tag == "Green")
        {
            Debug.Log("green");
        }
        else if(other.tag == "Yellow")
        {
            Debug.Log("yellow");
        }
        else if (other.tag == "Damage")
        {
            Debug.Log("yellow");
        }
    }
}
