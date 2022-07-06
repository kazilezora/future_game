using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{

    public GameObject Saw;
    public GameObject Sawdir1;
    public GameObject Sawdir2;
    public Vector3 sawpos1;
    public Vector3 sawpos2;
    public float delay;
    public float firstdir;

    public float dönmehýzý=0;
    public float waitingtime;
    private float dönme = 0;
    
    void Start()
    {
        sawpos1 = new Vector3(Sawdir1.transform.position.x, Sawdir1.transform.position.y, Saw.transform.position.z);
        sawpos2 = new Vector3(Sawdir2.transform.position.x, Sawdir2.transform.position.y, Saw.transform.position.z);
    }
    void Update()
    {
        StartCoroutine(Sawmove1());
        StartCoroutine(Sawmove2());
        if (Saw.transform.position != sawpos2 && Saw.transform.position != sawpos1)
        {
            SawTurning();
        }
        

    }
    void SawTurning()
    {

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y,dönme );
        dönme = dönme + dönmehýzý*Time.deltaTime;
    }
    IEnumerator Sawmove1()
    {
        if(Saw.transform.position == sawpos2)
        {
            firstdir = 1;
            yield return new WaitForSeconds(waitingtime);
        }

        if (firstdir==1)
        {
                Saw.transform.position = Vector3.MoveTowards(Saw.transform.position, sawpos1, delay * Time.deltaTime);
        }


    }
    IEnumerator Sawmove2()
    {
        if (Saw.transform.position == sawpos1)
        {
            firstdir = 2;
            yield return new WaitForSeconds(waitingtime);
        }
        if (firstdir == 2)
        {
            Saw.transform.position = Vector3.MoveTowards(Saw.transform.position, sawpos2, delay * Time.deltaTime);
        }
    }

}
