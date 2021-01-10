using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void toplamaOyunBtn(string deger)
    {
        PlayerPrefs.SetString("hangiOyun", deger);
        Debug.Log(PlayerPrefs.GetString("hangiOyun"));
        SceneManager.LoadScene("MatematikOyunu");
        
    }


    public void cikarmaOyunBtn(string deger)
    {
        PlayerPrefs.SetString("hangiOyun", deger);
        Debug.Log(PlayerPrefs.GetString("hangiOyun"));
        SceneManager.LoadScene("MatematikOyunu");
    }


    public void carpmaOyunBtn(string deger)
    {
        PlayerPrefs.SetString("hangiOyun", deger);
        Debug.Log(PlayerPrefs.GetString("hangiOyun"));
        SceneManager.LoadScene("MatematikOyunu");
    }


    public void bolmeOyunBtn(string deger)
    {
        PlayerPrefs.SetString("hangiOyun", deger);
        Debug.Log(PlayerPrefs.GetString("hangiOyun"));
        SceneManager.LoadScene("MatematikOyunu");
    }


    public void karisikOyunBtn(string deger)
    {
        PlayerPrefs.SetString("hangiOyun", deger);
        Debug.Log(PlayerPrefs.GetString("hangiOyun"));
        SceneManager.LoadScene("MatematikOyunu");
    }


}
