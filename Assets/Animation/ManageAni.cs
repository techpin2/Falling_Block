using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAni : MonoBehaviour
{
    public Animator ani;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    ani.SetBool("jump", true);
        //}
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    ani.SetBool("jump", false);
        //}

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ani.Play("New Animation");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ani.Play("rotate");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ani.Play("FillAmount");
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            ani.Play("empty"); 
            
        }
    }

    public void OnEvent()
    {
        print("OneventCall");
    }
}
