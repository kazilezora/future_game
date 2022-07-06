using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetectorController : MonoBehaviour
{

    public GameObject playerp;

    void Update()
    {
        transform.position = new Vector2(playerp.transform.position.x, transform.position.y);
    }

}
