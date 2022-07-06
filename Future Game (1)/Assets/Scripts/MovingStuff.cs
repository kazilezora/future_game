using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStuff : MonoBehaviour
{
    public GameObject[] Clouds;
    public float[] Cloudspeed;
    
    private int des;
    public Vector3[] CloudsEnding;
    public GameObject[] ClouDes;

    public float[] CloudSpeeds;
    void Start()
    {
        CloudStarting();
    }

    
    void FixedUpdate()
    {

        CloudsMoving();
        
    }
    // Beni �ok yoran bu kardi�i ��zmenin yolu �u: �ncelik olarak random de�erleri saklad���m arry alan�n� 
    // tan�mlamam gerekiyomu� (Bruh) Bunu kavramam yakla��k 4 saatimi ald� ama sonu� iyi ld slim y�ld�z sak�z
    public void CloudStarting()
    {

        CloudsEnding=new Vector3[Clouds.Length];
        for (int i = 0; i < Clouds.Length; i++)
        {

            des = Random.Range(0, ClouDes.Length);
            CloudsEnding[i] = new Vector3(ClouDes[des].transform.position.x, ClouDes[des].transform.position.y,ClouDes[des].transform.position.z);
        }
         CloudSpeeds = new float[Clouds.Length];
        for (int j = 0; j < Clouds.Length; j++)
        {
            CloudSpeeds[j] = Cloudspeed[Random.Range(0,Cloudspeed.Length)];
            
        }

    }
    void CloudsMoving()
    {
        for (int k = 0; k < Clouds.Length; k++)
        {

            Clouds[k].transform.position = Vector3.MoveTowards(Clouds[k].transform.position, CloudsEnding[k],CloudSpeeds[k]);
            if (Clouds[k].transform.position == CloudsEnding[k])
            {
                des = Random.Range(0, ClouDes.Length);
                CloudsEnding[k] = new Vector3(ClouDes[des].transform.position.x, ClouDes[des].transform.position.y, ClouDes[des].transform.position.z);
            }
        }
    }
}