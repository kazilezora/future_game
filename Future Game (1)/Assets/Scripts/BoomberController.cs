using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomberController : MonoBehaviour
{

    public float lifetime;

    private float straitvaule;
    private Rigidbody2D rb;

    public bool isright;
    public bool isup;
    public bool isleft;
    public bool isdown;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        straitvaule = lifetime;
    }

    void FixedUpdate()
    {
        whichlocation();
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;

        }
        else
        {
            lifetime = straitvaule;
            Destroy(gameObject);
        }
    }
    void whichlocation()
    {
        if (isright == true )
        {
            rb.velocity = new Vector2(2, 0);
        }
        else if (isleft == true)
        {
            rb.velocity = new Vector2(-2, 0);
        }
        else if (isup == true)
        {
            rb.velocity = new Vector2(0, 2);
        }
        else if (isdown == true)
        {
            rb.velocity = new Vector2(0, -2);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);
        
    }
}
