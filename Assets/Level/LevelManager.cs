using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject panel;
    public Image fillImage;

    //public int sceneIndex;
    private void Start()
    {
       
    }
    public void LoadLevel(int i)
    {
        panel.SetActive(true);
      //  sceneIndex = i;
        print("Load LEvel "+i);
        StartCoroutine(FillImage(5,i));
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("xyz");
    }

    IEnumerator FillImage(float waitingTime,int sceneIndex)
    {
        float t = 0;
        while(t<=1)
        {
              t += Time.deltaTime/waitingTime;
            float lerpValue= Mathf.Lerp(0, 1, t);
            fillImage.fillAmount = lerpValue;
              yield return null;
        }
        SceneManager.LoadScene(sceneIndex);
       
    }
    
}
