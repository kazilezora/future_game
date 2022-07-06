using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawWChain : MonoBehaviour
{
    public  float RotationSpeed;
    void Update()
    {
        transform.Rotate(transform.rotation.x, transform.rotation.y, RotationSpeed*Time.deltaTime);
    }
}
