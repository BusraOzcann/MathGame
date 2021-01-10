using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControllerScript : MonoBehaviour
{

    public GameManagerScript gameManagerScript;

    public BalloonController balloonController;

    public QuestionGenerator questionGenerator;

    float speed;

    float lerpCount;

    Vector2 currentVelocity;

    Vector2 targetVelocity;

    Rigidbody2D rBody;

    [SerializeField]
    private GameObject balloon;

    [SerializeField]
    private GameObject questionText;

    public List<Vector3> balloonPos; 

    bool chestController = true;

    int sonucKontrol;


    private void Awake()
    {

        rBody = GetComponent<Rigidbody2D>();

        rBody.velocity = Vector2.zero;

        lerpCount = 12;

        speed = 9;


    }


    private void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {

            targetVelocity = new Vector2(-1, 0) * speed;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            targetVelocity = new Vector2(1, 0) * speed;
        }
        else
        {
            targetVelocity = Vector2.zero;

        }


        currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, lerpCount * Time.deltaTime);

        rBody.velocity = currentVelocity;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "chest")
        {
            if (chestController)
            {
                Destroy(collision.gameObject, 0.2f);

                createQuestion();

                createBallons();
            }
            chestController = false;
        }

        if(collision.gameObject.tag == "balloon")
        {
            sonucKontrol = int.Parse(collision.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text);

            Debug.Log(sonucKontrol);

            if (sonucKontrol == PlayerPrefs.GetInt("dogruSonuc"))
            {
                Debug.Log("dogru cevap");

                Destroy(GameObject.FindGameObjectWithTag("question"));

                GameObject[] balloons = GameObject.FindGameObjectsWithTag("balloon");

                for(int i = 0; i < balloons.Length; i++)
                {
                    Destroy(balloons[i]);
                }

                chestController = true;

                gameManagerScript.createChest();
            }

            else
            {
                Debug.Log("yanlis cevap");

                Destroy(GameObject.FindGameObjectWithTag("question"));

                GameObject[] balloons = GameObject.FindGameObjectsWithTag("balloon");

                for (int i = 0; i < balloons.Length; i++)
                {
                    Destroy(balloons[i]);
                }

                chestController = true;

                gameManagerScript.createChest();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "chest")
        {
            chestController = true;
        }
    }

    private void createQuestion()
    {
        GameObject question = Instantiate(questionText);

        question.gameObject.transform.position = new Vector3(gameObject.transform.position.x , -Camera.main.orthographicSize + 4f, 0);

        question.gameObject.transform.SetParent(gameObject.transform);
    }


    private void createBallons()
    {
        balloonPos = new List<Vector3>();

        for (int i = 0; i < 3; i++)
        {
            Instantiate(balloon);  
        }

        balloonPos.Clear();
    }

   

}
