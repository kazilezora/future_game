using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deublejumpcntroller : MonoBehaviour
{
    public int playersusme;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playersusme = playersusme+1;
            transform.gameObject.SetActive(false);
        }

    }
}
