using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.Play("rotate");
        }
        if (Input.GetKeyDown(KeyCode.Z))
            ani.Play("SquareAni");

        if (Input.GetKeyDown(KeyCode.X))
            ani.Play("color");

       
       if (Input.GetKeyUp(KeyCode.X) ||Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.C))
                {
            ani.Play("New State");
        }

       if(Input.GetKeyDown(KeyCode.C))
        {
            ani.Play("scale");
        }

       
        
    }
}
