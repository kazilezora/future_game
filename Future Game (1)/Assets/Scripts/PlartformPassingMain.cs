using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlartformPassingMain : MonoBehaviour
{
    public PlayerController pc;
    public bool playerinme;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            pc.NotTheRightspot = true;
            playerinme = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag== "Player")
        {
            pc.NotTheRightspot = false;
            playerinme = false;
        }
    }
}
