using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    public GameObject go;
    public GameObject spawningplace;

    public float delay;
    private GameObject Clone;

    void Start()
    {

        StartCoroutine(whenspawn());

    }

    private void BombComing()
    {

        Clone = Instantiate(go) as GameObject;
        Clone.transform.position = new Vector2(spawningplace.transform.position.x, spawningplace.transform.position.y);
    }
    IEnumerator whenspawn()
    {
        while(true){
            yield return new WaitForSeconds(delay);
            BombComing();
        }
    }

}
