using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class İnfilitration : MonoBehaviour
{
    public bool suzulbaby;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            suzulbaby = true;
            transform.gameObject.SetActive(false);
        }

    }
}
