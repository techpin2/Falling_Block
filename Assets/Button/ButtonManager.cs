using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class ButtonManager : MonoBehaviour
{
    public Image loadingImg;
    public GameObject buttons;
    public Transform parentObj;
    public string[] levelName;
    public GameObject loadingScreen;
    //public GameObject buttonScene;
   
    public void Level(int i)
    {
       
        print(i);
        string lname = levelName[i - 1];
        if (lname == "NA")
        {
            loadingScreen.SetActive(true); 
        }
        else
        {
            StartCoroutine(Loading(i));
        }
    }

    public void Level(string i)
    {
        SceneManager.LoadScene(i);
    }
    IEnumerator Loading(int i)
    {
        float t = 0;
        while (t <= 1)
        {
             t = t + Time.deltaTime/2;
            float Loadingvalue = Mathf.Lerp(0, 1, t);
           // print(Loadingvalue);
            loadingImg.fillAmount = Loadingvalue;
            yield return null;
        }
        SceneManager.LoadScene(i);
    }
    private void Start()
    {
        for (int p = 0; p < levelName.Length; p++)
        {
            GameObject obj = Instantiate(buttons, parentObj);
            TMP_Text LevelName = obj.transform.GetChild(0).GetComponent<TMP_Text>();

            LevelName.text = levelName[p];
            Button b= obj.transform.GetComponent<Button>();
            int i = p + 1;
            b.onClick.AddListener(() =>
            { 
                Level(i);
            });
        }
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
   
    

    
}

