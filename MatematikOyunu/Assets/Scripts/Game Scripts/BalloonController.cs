using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BalloonController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D balloonRGD;

    [SerializeField]
    private Sprite[] colorfullBalloons;

    CharacterControllerScript characterControllerScript;

    QuestionGenerator questionGenerator;

    int speed = 450;

    private void Awake()
    {
        characterControllerScript = Object.FindObjectOfType<CharacterControllerScript>();

        questionGenerator = Object.FindObjectOfType<QuestionGenerator>();
    }

    void Start()
    {
        position();
        balloonText();
        
    }

    
    void Update()
    {
        balloonRGD.velocity = Vector3.down * speed * Time.deltaTime;
    }

    private void position()
    {

        int num = (int)Random.Range(-9, 10);
        Vector3 balloonPos = new Vector3(num, Camera.main.orthographicSize + 2, 0);
        Vector3 balloonPos1 = new Vector3(num+1, Camera.main.orthographicSize + 2, 0);
        Vector3 balloonPos2 = new Vector3(num-1, Camera.main.orthographicSize + 2, 0);

        if (characterControllerScript.balloonPos.Contains(balloonPos))
        {
            position();
        }
        else
        {
            characterControllerScript.balloonPos.Add(balloonPos);
            characterControllerScript.balloonPos.Add(balloonPos1);
            characterControllerScript.balloonPos.Add(balloonPos2);
            gameObject.transform.position = balloonPos;
        }

        color();
    }

    private void color()
    {
        int num = Random.Range(0, colorfullBalloons.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = colorfullBalloons[num];
    }

    public void balloonText()
    {
        int answer = questionGenerator.sonuc;
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = answer + "";

        int num = Random.Range(2, 10);
        int zar = Random.Range(1, 100);

        if(zar < 50)
        {
            questionGenerator.sonuc += num;
            if(answer == questionGenerator.sonuc)
            {
                balloonText();
            }
        }
        else if(zar >= 50)
        {
            questionGenerator.sonuc -= num;
            if (answer == questionGenerator.sonuc)
            {
                balloonText();
            }
        }

    }

    
}
