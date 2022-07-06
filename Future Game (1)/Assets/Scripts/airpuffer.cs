using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airpuffer : MonoBehaviour
{
    public float airspeed;
    public bool inme;
    public PlayerController pc;

    public bool inairbuffer;



    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.W))
            {
                collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collider.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);


                    collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collider.gameObject.GetComponent<Rigidbody2D>().velocity.x, -1);

            }
        }


    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            inairbuffer = true;
            pc.istoc = false;
            pc.howMuckitjumped=1;
            if (Input.GetKey(KeyCode.W))
            {
                inme = true;

                collider.gameObject.GetComponent<Rigidbody2D>().drag = 0;
                collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, airspeed));
            }
            else 
            {
                inme = false;
            }

        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag== "Player")
        {
            inme = false;
            inairbuffer = false;
        }
    }
}
