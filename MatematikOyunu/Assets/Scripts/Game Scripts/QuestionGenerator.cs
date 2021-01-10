using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour
{
    int ilkDeger;

    int sonDeger;

    public int sonuc;

    int zar;

    private void Start()
    {
        hangiSoru();

    }

    private void hangiSoru()
    {
        switch (PlayerPrefs.GetString("hangiOyun"))
        {
            case "toplama":
                toplama();
                break;

            case "cikarma":
                cikarma();
                break;

            case "carpma":
                carpma();
                break;

            case "bolme":
                bolme();
                break;

            case "karisik":
                karisik();
                break;
        }

    }


    private void toplama()
    {
        ilkDeger = Random.Range(2, 20);
        sonDeger = Random.Range(2, 20);

        sonuc = ilkDeger + sonDeger;
        PlayerPrefs.SetInt("dogruSonuc", sonuc);
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = ilkDeger + " + " + sonDeger;

    }

    private void cikarma()
    {
        ilkDeger = Random.Range(2, 20);
        sonDeger = Random.Range(2, 10);

        sonuc = ilkDeger - sonDeger;

        PlayerPrefs.SetInt("dogruSonuc", sonuc);

        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = ilkDeger + " - " + sonDeger;
    }

    private void carpma()
    {
        ilkDeger = Random.Range(2, 10);
        sonDeger = Random.Range(2, 5);

        sonuc = ilkDeger * sonDeger;

        PlayerPrefs.SetInt("dogruSonuc", sonuc);

        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = ilkDeger + " x " + sonDeger;
    }

    private void bolme()
    {
        ilkDeger = Random.Range(2, 20);
        sonDeger = Random.Range(2, 10);

        if(ilkDeger > sonDeger)
        {
            if (ilkDeger % sonDeger == 0)
            {
                sonuc = ilkDeger / sonDeger;

                PlayerPrefs.SetInt("dogruSonuc", sonuc);

                gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = ilkDeger + " / " + sonDeger;
            }
            else if(ilkDeger % sonDeger != 0)
            {
                bolme();
            }
        }
        else
        {
            bolme();
        }

        
    }

    private void karisik()
    {
        zar = Random.Range(1, 5);

        if (zar == 1)
        {
            toplama();
        }
        else if (zar == 2)
        {
            cikarma();
        }
        else if (zar == 3)
        {
            carpma();
        }
        else if (zar == 4)
        {
            bolme();
        }
    }


    

}

