using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public GameObject homeScreen;
   
    public void StartButton()
    {
        SceneManager.LoadScene(12);
        homeScreen.SetActive(false);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
