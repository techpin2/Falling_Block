using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionOfCar : MonoBehaviour
{
    public float speed;
    public bool isPress;
    Vector3 direction = Vector3.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collision detect"+collision.name);
    }

    public void Left()
    {
        isPress = true;
    }
    public void Right()
    {
        isPress = true;
    }
    public void Release()
    {
        isPress = false;
    }
}
