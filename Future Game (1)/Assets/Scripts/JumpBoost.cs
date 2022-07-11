using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    
    public GameObject gm;
    public float addforcepower;
    public float addforcedirectpower;
    public float WaitForSecondstime;
    public bool ontramboline;
    public bool normal;
    public bool sol;
    public bool sag;
    public bool basassa;
    public Rigidbody2D rigidbody;
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag =="Player" &&normal==true )
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, addforcepower), ForceMode2D.Impulse);
            ontramboline = true;

        }
        if (collision.collider.tag == "Player" && sol == true)
        {

            rigidbody.AddForce(new Vector2(addforcedirectpower,0),ForceMode2D.Impulse);
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
