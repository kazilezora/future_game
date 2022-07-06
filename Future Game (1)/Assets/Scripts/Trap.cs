using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject startpos;
    public GameObject endpos;
    private Vector2 begindir;
    private Vector2 aimdir;

    public float time;

    public bool state;
    void Start()
    {
        begindir = new Vector2(startpos.transform.position.x, startpos.transform.position.y);
        aimdir = new Vector2(endpos.transform.position.x, endpos.transform.position.y);
    }


    void FixedUpdate()
    {
        if(new Vector2(transform.position.x, transform.position.y) == aimdir)
        {
            state = true;
        }
        if (new Vector2(transform.position.x, transform.position.y) == begindir)
        {
            state = false;
        }
        
        if (state==true)
        {

            transform.position = Vector2.MoveTowards(transform.position, begindir, time);

        }
        if(state==false)
        {
            transform.position = Vector2.MoveTowards(transform.position, aimdir, time);

        }

    }
}
