using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSticker : MonoBehaviour
{

    public bool IsTouchFront;
    public bool IsSliding;
    public float SlidingSpeed;
    public PlayerController player;

    public bool IsWallJumpingl;
    public bool IsWallJumpingr;
    public float xjumpforce;
    public float yjumpforce;
    public float WallJumpDelay;
    public GameObject go;
    public Animator animator;
    void Update()
    {
        if(player.isdashing==false){
            animator.SetBool("Issliding",IsSliding);
            
        }
        else if(player.isdashing==true){
            animator.SetBool("Issliding",false);
        }
        
        float input = player.ver;
        if(IsTouchFront==true && player.istoc==false )
        {
            IsSliding = true;
        }
        else
        {
            IsSliding = false;
        }
        if (IsSliding == true)
        {
            animator.SetFloat("jumpspeed", 0);
            player.rbody.velocity = new Vector2(player.rbody.velocity.x, Mathf.Clamp(player.rbody.velocity.y, -SlidingSpeed, float.MaxValue));
        }
        if (IsSliding == true && Input.GetKey(KeyCode.W)&& Input.GetKeyDown(KeyCode.D )) 
        {
            IsWallJumpingr = true;
            Invoke("WallJumpInvorker",WallJumpDelay);
        }else if(IsSliding == true && Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
        {
            IsWallJumpingl = true;

            Invoke("WallJumpInvorker", WallJumpDelay);
        }

        //Scaleye g�re xjumpforca - veya + de�er vereceksin
        if (IsWallJumpingr == true )
        {
            player.rbody.velocity = new Vector2(-xjumpforce, yjumpforce);

        }else if (IsWallJumpingl == true)
        {
            player.rbody.velocity = new Vector2(xjumpforce, yjumpforce);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ground")
        {
            IsTouchFront = true;

        }


    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Ground")
        {
            IsTouchFront = false;

        }
    }
    void WallJumpInvorker()
    {
        IsWallJumpingr = false;
        IsWallJumpingl = false;
    }
}
