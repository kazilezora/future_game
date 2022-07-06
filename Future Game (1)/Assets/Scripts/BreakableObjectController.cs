using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjectController : MonoBehaviour
{

    public bool inscwithp;

    public Rigidbody2D rb1;
    public Rigidbody2D rb2;
    public Rigidbody2D rb3;
    public float breakabletimebreak;
    void Start()
    {
        
    }

    
    void Update()
    {
        StartCoroutine(breakable());
    }

    IEnumerator breakable()
    {
        if (inscwithp == true)
        {
            yield return new WaitForSeconds(breakabletimebreak);
            rb1.bodyType = RigidbodyType2D.Dynamic;
            yield return new WaitForSeconds(breakabletimebreak);
            rb2.bodyType = RigidbodyType2D.Dynamic;
            yield return new WaitForSeconds(breakabletimebreak);
            rb3.bodyType = RigidbodyType2D.Dynamic;

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        inscwithp = true;
    }
}
