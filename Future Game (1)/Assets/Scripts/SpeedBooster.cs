using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    public PlayerController pcontrol;
    private float speedstart;
    private float speedstatic;
    public float speedController;

    void Start()
    {
        speedstart = pcontrol.speed * speedController;
        speedstatic = pcontrol.speed;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag== "Player")
        {
            pcontrol.speed = speedstart;

        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pcontrol.speed = speedstatic;

        }
    }

}
