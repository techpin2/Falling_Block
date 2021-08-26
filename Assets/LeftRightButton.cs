using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightButton : MonoBehaviour
{
    public Transform obj;
    public float speed;
    private Vector3 direction = Vector3.zero;
    public bool isPressed;
    void Update()
    {if (isPressed == true)
        {
            obj.Translate(direction * speed * Time.deltaTime);
        }
       
        
    }
    public void Left()
    {
        isPressed = true;
        direction = Vector3.left;
        
    }
    public void Right()
    {
        isPressed = true;
        direction = Vector3.right;
    }
    public void Release()
        {
        isPressed = false;
    }
}


