using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public GameObject homeScreen;

    private void Start()
    {
        AdManager.adManager.ShowAd(AdsType.Banner);
    }

    public void StartButton(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ExitButton()
    {
        print("Exit called");
        Application.Quit();
    }
   public void Shop(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ExitButton();
    }

}
