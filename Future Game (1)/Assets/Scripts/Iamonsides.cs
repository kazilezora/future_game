using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iamonsides : MonoBehaviour
{
    public bool isheinsides;
    void OnTriggerStay2D(Collider2D collider)
    {
        isheinsides = true;
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        isheinsides = false;
    }
}
