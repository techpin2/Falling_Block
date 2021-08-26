using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody r;
    float x;
    float y;
    float speed = 15;
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        
    }
    private void FixedUpdate()
    { Vector3 vec = new Vector3(x, y, 0);
        r.MovePosition(transform.position+(vec * speed * Time.fixedDeltaTime));
    }
}
