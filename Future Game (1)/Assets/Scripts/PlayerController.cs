using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool istoc;
    public int scale;
    public Rigidbody2D rbody;
    public float ver;
    public float speed;

    public bool done;

    public float dashdistance;

    public float jumpspeed;
    public bool isdashing;
    public float dashtime;

    public ParticleSystem dust;

    public int istoccontroller=1;
    public GroundCheck gc;

    public WallSticker Ws;
    public BoxCollider2D collide;
    public PolygonCollider2D pcollide;
    private bool InSomething;
    public bool itTouchedOnce;

    public KeyController kc;
    public int howMuckitjumped;

    public airpuffer ap;
    public Animator animator;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
       
    }
    void FixedUpdate()
    {
        ver = Input.GetAxis("Horizontal");
        
        animator.SetFloat("WalkAnim", Mathf.Abs(ver));
        animator.SetBool("DashFade",isdashing);
        if (!isdashing)
        {
            if (Ws.IsWallJumpingr == false && Ws.IsWallJumpingl==false)
            {
                rbody.velocity = new Vector2(ver * speed, rbody.velocity.y);
            }
            
        }


        if (rbody.velocity.x > 0)
        {
            transform.localScale = new Vector3(0.6f, transform.localScale.y, transform.localScale.z);

        }
        else if (rbody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-0.6f, transform.localScale.y, transform.localScale.z);
        }

        
    }
    void Update()
    {
        hitboxsmoller();
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(dash());
        }
        jump();
        firsttochground();
        infiltration();
    }
    void infiltration()
    {
        if (Input.GetKey(KeyCode.W)&&rbody.velocity.y<0&&ap.inme==false)
        {
            rbody.drag = 10;
            
        }
        else 
        {

            rbody.drag = 0;
        }
    }
    void hitboxsmoller()
    {
        if (isdashing == true)
        {
            pcollide.isTrigger = true;
            collide.enabled = true;
        }
       if(isdashing == false && InSomething==false)
        {
            pcollide.isTrigger = false;
            collide.enabled = false;
        }
    }

    void firsttochground()
    {
        if (istoc==true&&istoccontroller==1)
        {

            if (gc.candust == 1)
            {
                particledust();
            }
            istoccontroller = 2;
            gc.candust = 1;
        }
        if (istoccontroller == 2 && istoc== false)
        {
           
            istoccontroller = 1;
        }
    }

    void jump()
    {
        if (Input.GetKey(KeyCode.W) &&!isdashing&&istoc)
        {
                
                rbody.velocity = Vector2.up*jumpspeed;
                particledust();
            itTouchedOnce = true;
            //animator.SetBool("Jumping",true);

            
        }
        if (Input.GetKeyDown(KeyCode.W)&&istoc==false&&itTouchedOnce&&kc.nowplayertookme==true&&howMuckitjumped==0)
        {
            rbody.velocity = Vector2.up * jumpspeed;
            howMuckitjumped = 1;
        }
            //animator.SetBool("Jumping",false);
    }
    IEnumerator dash()
    {
        isdashing = true;

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) 
        {
            scale = 5;
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            scale = 6;
        }
        else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            scale = 7;
        }
        else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            scale = 8;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            scale = 1;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            scale = 2;
            
        }
        else if (Input.GetKey(KeyCode.W))
        {
            scale = 3;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            scale = 4;
        }
        else
        {
            scale = 0;
        }

        if (scale == 1)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 0f);
            rbody.AddForce(new Vector2(dashdistance, 0f),ForceMode2D.Impulse);
            float gravity = 1f;
            rbody.gravityScale = 0;
            yield return new WaitForSeconds(dashtime);
            isdashing = false;
            rbody.gravityScale = gravity;
        }
        else if (scale == 2)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 0f);
            rbody.AddForce(new Vector2(dashdistance*-1f, 0f), ForceMode2D.Impulse);
            float gravity = 1f;
            rbody.gravityScale = 0;
            yield return new WaitForSeconds(dashtime);
            isdashing = false;
            rbody.gravityScale = gravity;
        }
        else if (scale == 3&&istoc==false)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 0f);
            rbody.AddForce(new Vector2(0f, dashdistance/1.5f), ForceMode2D.Impulse);
            float gravity = 1f;
            rbody.gravityScale = 0;
            yield return new WaitForSeconds(dashtime);
            rbody.velocity = new Vector2(rbody.velocity.x, 0f);
            isdashing = false;
            rbody.gravityScale = gravity;
        }
        else if (scale == 4 && istoc == false)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 0f);
            rbody.AddForce(new Vector2(0f, (dashdistance*-1)/1.5f), ForceMode2D.Impulse);
            float gravity = 1f;
            rbody.gravityScale = 0;
            yield return new WaitForSeconds(dashtime);
            rbody.velocity = new Vector2(rbody.velocity.x, 0f);
            isdashing = false;
            rbody.gravityScale = gravity;
        }
        else if(scale==5&& istoc== false)
        {
            rbody.velocity = new Vector2(0, 0);
            rbody.AddForce(new Vector2(dashdistance, dashdistance / 1.5f), ForceMode2D.Impulse);
            float gravity = 1f;
            rbody.gravityScale = 0;
            yield return new WaitForSeconds(dashtime);
            rbody.velocity = new Vector2(0f, 0f);
            isdashing = false;
            rbody.gravityScale = gravity;
        }
        else if (scale == 6 && istoc == false)
        {
            rbody.velocity = new Vector2(0, 0);
            rbody.AddForce(new Vector2(dashdistance*-1f, dashdistance / 1.5f), ForceMode2D.Impulse);
            float gravity = 1f;
            rbody.gravityScale = 0;
            yield return new WaitForSeconds(dashtime);
            rbody.velocity = new Vector2(0f, 0f);
            isdashing = false;
            rbody.gravityScale = gravity;
        }
        else if (scale == 7 && istoc == false)
        {
            rbody.velocity = new Vector2(0, 0);
            rbody.AddForce(new Vector2(dashdistance, (dashdistance*-1f) / 1.5f), ForceMode2D.Impulse);
            float gravity = 1f;
            rbody.gravityScale = 0;
            yield return new WaitForSeconds(dashtime);
            rbody.velocity = new Vector2(0f, 0f);
            isdashing = false;
            rbody.gravityScale = gravity;
        }
        else if (scale == 8 && istoc == false)
        {
            rbody.velocity = new Vector2(0, 0);
            rbody.AddForce(new Vector2(dashdistance*-1f, (dashdistance*-1f) / 1.5f), ForceMode2D.Impulse);
            float gravity = 1f;
            rbody.gravityScale = 0;
            yield return new WaitForSeconds(dashtime);
            rbody.velocity = new Vector2(0f, 0f);
            isdashing = false;
            rbody.gravityScale = gravity;
        }
        isdashing = false;

    }

    void particledust()
    {
        dust.Play();
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        InSomething = true;
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        InSomething = false;
    }
}
