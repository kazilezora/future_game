using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlartformPassingMain : MonoBehaviour
{
    public bool playerinme;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerinme = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag== "Player")
        {
            playerinme = false;
        }
    }
}
