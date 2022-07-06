using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerpos;
    public float smooting;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerpos = new Vector3(player.transform.position.x, player.transform.position.y, -6);
        transform.position = Vector3.Lerp(transform.position, playerpos, smooting*Time.deltaTime);
    }
}
