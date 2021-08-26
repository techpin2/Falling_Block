using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenApp : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(FirstScene());
    }
    IEnumerator FirstScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);

    }

}
