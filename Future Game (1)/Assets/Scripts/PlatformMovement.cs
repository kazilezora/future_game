using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public float speed;
    public float WaitingTime;
    private Vector2 point1loc;
    private Vector2 point2loc;
    private bool controllerbool=true;
    void Start()
    {
        point1loc = new Vector2(point1.transform.position.x,point1.transform.position.y);
        point2loc = new Vector2(point2.transform.position.x, point2.transform.position.y);

    }


    void Update()
    {
        StartCoroutine(PlatformMoving());

    }
    IEnumerator PlatformMoving()
    {

         if (new Vector2(transform.position.x, transform.position.y) == point1loc)
        {
            yield return new WaitForSeconds(WaitingTime);
        }
        if(new Vector2(transform.position.x, transform.position.y) == point2loc|| controllerbool==true)
        {
            if (new Vector2(transform.position.x, transform.position.y) == point2loc)
            {
                yield return new WaitForSeconds(WaitingTime);

            }
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), point1loc, speed * Time.deltaTime);
            controllerbool = true;
        }
        if (new Vector2(transform.position.x, transform.position.y) == point1loc|| controllerbool== false)
        {
            if (new Vector2(transform.position.x, transform.position.y) == point1loc)
            {
                yield return new WaitForSeconds(WaitingTime);
            }
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), point2loc, speed * Time.deltaTime);
            controllerbool = false;
        }

        
        
    }
}
