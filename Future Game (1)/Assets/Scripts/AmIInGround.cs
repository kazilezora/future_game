using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmIInGround : MonoBehaviour
{
    public bool YesHesINGround;
    void OnTriggerStay2D(Collider2D collider)
    {
        
        YesHesINGround = true;
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        YesHesINGround = false;
    }
}

