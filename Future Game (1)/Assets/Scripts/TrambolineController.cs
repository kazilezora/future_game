using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrambolineController : MonoBehaviour
{

    public JumpBoost jb;
    public Animator clip;

    void Update()
    {
        jumpanim();
    }
    void jumpanim()
    {
        if (jb.ontramboline == true)
        {
            clip.SetBool("isontramboline", true);
        }
        if (jb.ontramboline == false)
        {
            clip.SetBool("isontramboline", false);
        }
    }
}
