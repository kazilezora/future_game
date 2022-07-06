using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public bool sa;
    public Rigidbody2D rb;
    public float gravitscale;
 
    void OnTriggerStay2D(Collider2D other)
    {
            rb.gravityScale = 1;
            sa = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        sa = false;
        rb.gravityScale = gravitscale;
    }
}