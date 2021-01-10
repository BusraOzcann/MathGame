using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    
    void Start()
    {
       

        if(gameObject != null)
        {
            int zar = Random.Range(1,100);

            if(zar <= 50)
            {
                int xPos = Random.Range(2, 10);
                Vector3 pos = new Vector3(xPos, -Camera.main.orthographicSize + 1.8f, 0);
                gameObject.transform.position = pos;
            }
            if (zar > 50)
            {
                int xPos = Random.Range(-2, -10);
                Vector3 pos = new Vector3(xPos, -Camera.main.orthographicSize + 1.8f, 0);
                gameObject.transform.position = pos;
            }


        }

    }

    
}
