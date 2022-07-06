using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenableDoors : MonoBehaviour
{
    public PressurePlate pp;
    public Doorkey Dk;
    public int whichdoor;
    public GameObject upgameob;
    public GameObject downgameob;
    public float SpeedOfDoor;
    private Vector2 updir;
    private Vector2 downdir;
    public int HMKeyThisDooorW;


    void Start()
    {
        updir = new Vector2(upgameob.transform.position.x, upgameob.transform.position.y);
        downdir = new Vector2(downgameob.transform.position.x, downgameob.transform.position.y);
    }

    void Update()
    {
        Door›sMoving();
        if (Dk.HMKeyItHas == HMKeyThisDooorW)
        {
            pp.plate = 1;
        }
    }
    void Door›sMoving()
    {
        if(new Vector2(transform.position.x,transform.position.y)!=updir&& whichdoor == pp.plate)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), updir, SpeedOfDoor * Time.deltaTime);
        }
        else if(new Vector2(transform.position.x, transform.position.y)!= downdir)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), downdir, SpeedOfDoor * Time.deltaTime);
        }
    }
}
