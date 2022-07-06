using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airbooster : MonoBehaviour
{

    public float airforce;

    public GroundCheck gc;

    void OnTriggerStay2D(Collider2D collider)
    {

        if(collider.gameObject.tag == "Player" )
        {

            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, airforce));
            gc.lastground = 3;
            if (collider.gameObject.GetComponent<Rigidbody2D>().velocity.y <-10f)
            {
                collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collider.gameObject.GetComponent<Rigidbody2D>().velocity.x, -7f);
            }
            
        }
    }


}