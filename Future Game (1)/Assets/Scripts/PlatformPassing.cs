using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPassing : MonoBehaviour
{
    public PlartformPassingMain ppm;
    public BoxCollider2D bx1;
    private bool isout;


    void Update()
    {
        if(isout==true&& ppm.playerinme == false)
        {
            bx1.isTrigger = false;
            isout = false;
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            bx1.isTrigger = true;
            
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isout = true;
        }
    }

}
