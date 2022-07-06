using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject fuat;
    public PlayerController playerc;
    public int lastplace;
    public Betterjump Bj;
    public int lastground;
    public bool hasbeendestroyed=false;

    public float breakingtime;
    public GameObject bl;
    
    public int sa =1;
    private GameObject go;
    public int  asa = 62;
    public SpawnController sp;
    public bool inbreakable;
    private bool stillin;

    
    // This value helps to know when to give dust effect
    public int candust =1;
    void Update()
    {
        StartCoroutine(destroying());
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            playerc.itTouchedOnce = false;
        }

        if (collision.collider.tag == "SpeedBoost")
        {
            playerc.istoc = true;
            lastplace = 2;
            lastground = 1;
            playerc.howMuckitjumped = 0;
            playerc.itTouchedOnce = false;
        }
        if (collision.collider.tag == "Tramboline")
        {
            lastground = 2;
        }

        if(collision.collider.tag == "Breakable")
        {
            playerc.istoc = true;
            lastplace = 2;
            lastground = 1;
            playerc.howMuckitjumped = 0;
            playerc.itTouchedOnce = false;

            if (sa == 3&& collision.transform.position==go.transform.position)
            {
                sa = 2;
            }
            else
            {
                sa = 1;
            }

            if (sa==1)
            {

                go = collision.gameObject;
                sa = 2;
            }
            if (sa==2&&collision.gameObject.transform.position == go.transform.position) 
            {
                sa = 2;
            }
            else
            {
                sa = 1;
            }
            if (sa == 2)
            {
                Destroy(collision.gameObject, breakingtime);
                Instantiate(bl, collision.transform.position, Quaternion.identity);
            }
        }
        if (collision.collider.tag == "MovingPlatform")
        {
            playerc.istoc = true;
            lastplace = 1;
            lastground = 1;
            fuat.transform.parent = collision.gameObject.transform;
            playerc.howMuckitjumped = 0;
            playerc.itTouchedOnce = false;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            playerc.istoc = true;
            lastplace = 1;
            lastground = 1;
            
            playerc.howMuckitjumped = 0;
        }
        if (sa==2)
        {
            asa = 31;
        }
        else
        {
            asa = 62;
        }

        if (collision.collider.tag == "Breakable")
        {

            playerc.istoc = true;
            stillin = true;
            inbreakable = true;


        }
        if (collision.collider.tag == "Box")
        {
            playerc.istoc = true;
            lastplace = 3;
            lastground = 1;
            playerc.howMuckitjumped = 0;
            playerc.itTouchedOnce = false;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground"&&lastplace==1)
        {
            playerc.istoc = false;
 
        }
         if (collision.collider.tag == "SpeedBoost"&&lastplace==2)
        {
            playerc.istoc = false;
        }
        if(collision.collider.tag == "Box" && lastplace == 3)
        {
            playerc.istoc = false;

        }
        if (collision.collider.tag == "Breakable" && lastplace==2)
        {
            playerc.istoc = false;
            sa = 3;
            inbreakable = false;
            stillin=false;
        }
        if(collision.collider.tag == "MovingPlatform" && lastplace == 1)
        {
            playerc.istoc = false;
            fuat.transform.parent = null;
        }

    }

    IEnumerator destroying()
    {
        if (sa==2)
        {

            yield return new WaitForSeconds(breakingtime);
            if (sa == 2 && asa == 31&&stillin==false)
            {
                    candust = 0;
                    playerc.istoc = false;

            }
            if (inbreakable == false)
            {
                sa = 1;
            }
            
            
        }

    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Flag")
        {
            Debug.Log("enter");
            for (int i = 0; i < sp.spawnps.Length; i++)
            {
                if (sp.spawnps[i].transform.position == collider.transform.position && sp.LastSpawnp < i)
                {
                    sp.LastSpawnp = i;

                }
            }
        }

    }

}
