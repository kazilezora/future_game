using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    PlayerController playerc;

    public float addforcepower;
    public float addforcedirectpower;
    public bool ontramboline;
    public bool normal;
    public bool sol;
    public bool sag;
    public bool basassa;
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player"&&normal==true )
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, addforcepower), ForceMode2D.Impulse);
            ontramboline = true;
        }
        if(collision.collider.tag == "Player"&& sol== true)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(addforcedirectpower, 0);
            ontramboline = true;
        }


    }
    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player")
        {

            ontramboline = false;
        }


    }
}
