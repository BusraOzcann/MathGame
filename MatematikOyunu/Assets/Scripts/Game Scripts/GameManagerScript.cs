using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public GameObject backgroundOffset;

    public GameObject character;

    public GameObject chest;

    void Start()
    {
        Camera.main.orthographicSize = 20 / Camera.main.aspect / 2;

        backgroundOffset.transform.position = new Vector3(0, -Camera.main.orthographicSize, 0);

        character.transform.position = new Vector3(0, -Camera.main.orthographicSize + 2f, 0);

        createChest();

    }



    public void createChest()
    {
        Instantiate(chest);
    }


}
