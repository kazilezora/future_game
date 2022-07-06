using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public Sprite platesprite;
    public Sprite spritenull;
    public int plate;
    


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Pp")
        {
            collider.gameObject.GetComponent<SpriteRenderer>().sprite = spritenull;
            Pressurep Pp = collider.GetComponent<Pressurep>();
            plate = Pp.whichpp;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Pp")
        {
            collider.gameObject.GetComponent<SpriteRenderer>().sprite = platesprite;
            plate = 0;
        }
    }

}