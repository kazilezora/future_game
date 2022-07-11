using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorkey : MonoBehaviour
{
    
    public int HMKeyItHas;

    public float kutu;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "DoorKey")
        {
            kutu = collision.gameObject.GetComponent<DoorkeyId>().Canopen;

            collision.gameObject.SetActive(false);
        }
    }
}
