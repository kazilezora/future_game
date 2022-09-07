using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public GameObject gm;
    public float addforcepower;
    public float addforcedirectpower;
    public float timedeltatimeturn;
    public float WaitForSecondstime;
    public bool ontramboline;
    public bool normal;
    public bool sol;
    public bool sag;
    public bool basassa;
    public Rigidbody2D rigidbody;


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag =="Player" &&normal==true )
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            rigidbody.AddForce(new Vector2(0, addforcepower), ForceMode2D.Impulse);
            ontramboline = true;
          
        }
        if (collision.tag == "Player" && sol == true)
        {
            gm = collision.gameObject;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ontramboline = true;
            StartCoroutine(Solasagacoro());


        }
        if(collision.tag=="Player"&& sag == true)
        {
            gm = collision.gameObject;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ontramboline = true;
            StartCoroutine(Sagaacario());
        }
        if (collision.tag == "Player" && basassa == true)
        {
            gm = collision.gameObject;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ontramboline = true;
            StartCoroutine(Basasario());
        }
    }
    IEnumerator Basasario()
    {
        for (int i = 0; i < timedeltatimeturn; i++)
        {
            yield return new WaitForSeconds(WaitForSecondstime);
            gm.transform.position += new Vector3(0, -addforcedirectpower * Time.deltaTime);
        }
    }

    IEnumerator Sagaacario()
    {
        for (int i = 0; i < timedeltatimeturn; i++)
        {
            yield return new WaitForSeconds(WaitForSecondstime);
            gm.transform.position += new Vector3(-addforcedirectpower * Time.deltaTime, 0);
        }
    }
    IEnumerator Solasagacoro()
    {
        for (int i = 0; i < timedeltatimeturn ; i++)
        {
            yield return new WaitForSeconds(WaitForSecondstime);
            gm.transform.position += new Vector3(addforcedirectpower*Time.deltaTime, 0);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
            ontramboline = false;
        }
    }
}
