using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] spawnps;
    public int LastSpawnp;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Saw")
        {
            collision.gameObject.SetActive(false);
            transform.position = spawnps[LastSpawnp].transform.position;
            collision.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            collision.gameObject.SetActive(false);
            transform.position = spawnps[LastSpawnp].transform.position;
            collision.gameObject.SetActive(true);
        }
        if (collision.collider.tag == "Diken")
        {
            collision.collider.gameObject.SetActive(false);
            transform.position = spawnps[LastSpawnp].transform.position;
            collision.gameObject.SetActive(true);
        }
        if (collision.collider.tag == "Trap")
        {
            collision.collider.gameObject.SetActive(false);
            transform.position = spawnps[LastSpawnp].transform.position;
            collision.gameObject.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "FallDetector")
        {
            gameObject.SetActive(false);
            transform.position = spawnps[LastSpawnp].transform.position;
            gameObject.SetActive(true);
        }
    }
    
}
