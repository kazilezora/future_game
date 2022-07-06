using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashFading : MonoBehaviour
{
    private float spawningtime=0;
    public float startspawningtime;

    public GameObject cloneright;
    public GameObject cloneleft;

    public SpriteRenderer cloner;
    public SpriteRenderer clonel;


    public PlayerController pc;

    public Color[] colors; 

    void FixedUpdate()
    {
        if (pc.isdashing == true)
        {
            if (spawningtime <= 0)
            {

                if (transform.localScale.x > 0)
                {
                   
                    GameObject ins = (GameObject)Instantiate(cloneright, transform.position, Quaternion.identity);
                    cloner.color = colors[Random.Range(0, colors.Length)];
                    Destroy(ins, 5f);
                }
                else
                {
                    GameObject ins = (GameObject)Instantiate(cloneleft, transform.position, Quaternion.identity);
                    clonel.color = colors[Random.Range(0, colors.Length)];
                    Destroy(ins, 5f);
                }

                spawningtime = startspawningtime;

            }
            else
            {
                spawningtime -= Time.deltaTime;
            }
        }

    }
}
