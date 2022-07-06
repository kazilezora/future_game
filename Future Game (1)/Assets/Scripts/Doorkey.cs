using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorkey : MonoBehaviour
{
    
    public int HMKeyItHas;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "DoorKey")
        {
            HMKeyItHas = HMKeyItHas + 1;
            collision.gameObject.SetActive(false);
        }
    }
}
