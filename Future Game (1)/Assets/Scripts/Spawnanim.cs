using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnanim : MonoBehaviour
{

    public Animator spwna;
    public PlayerController pc;
    private int i= 0;
    public Sprite sprite;
    public SpriteRenderer Sr;
    public GameObject pointlight;

    void Update() { 
    }



    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player"&& i==0)
        {
            i = 1;
            StartCoroutine(staybro());

        }
    }
    IEnumerator staybro()
    {
        spwna.SetBool("touchedme", true);
        yield return new WaitForSeconds(1.5f);
        spwna.SetBool("touchedme", false);
        spwna.enabled = false;
        Sr.sprite = sprite;
        pointlight.SetActive(true);
    }
}
