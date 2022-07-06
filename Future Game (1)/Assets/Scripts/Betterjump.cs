using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Betterjump : MonoBehaviour
{
    public float fallmulti=2.5f;
    public float lowJumpMuli = 2f;

    private Rigidbody2D rb;
    public PlayerController pc;
    public GroundCheck gc;
    public airpuffer ap;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {

        if (gc.lastground == 1 && ap.inairbuffer==false)
        {
            betterjump();
        }
            

        
    }
    void betterjump()
    {
        if(pc.isdashing==false){
            animator.SetFloat("jumpspeed",rb.velocity.y);
        }
        else if(pc.isdashing==true){
            animator.SetFloat("jumpspeed",0);
        }
        
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallmulti - 1) * Time.deltaTime;
            
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMuli - 1) * Time.deltaTime;
        }
        
    }

}
