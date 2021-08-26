using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ravi : MonoBehaviour
{
    public Transform car;
    public float roadspeed;
    public GameObject screen;
    public GameObject screen1;
    public bool b;


    
    void Update()
    {
        if (b == true)
        {
            car.Translate(Vector3.up * roadspeed * Time.deltaTime);
           
            
        }
    }
    public void play()
    {
        b = true;
        screen.SetActive(false);
    }
    public void startgame()
    {
        screen1.SetActive(false);
    }
    public void backstart()
    {
        screen1.SetActive(true);
    }
}
