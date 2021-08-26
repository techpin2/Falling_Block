using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{   public float speed=10;
    public Rigidbody rb;
    float x;
    float y;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        x= Input.GetAxis("Horizontal");
        y= Input.GetAxis("Vertical");
        MoveSphere(new Vector3(x, y, 0));

      
    }
    private void FixedUpdate()
    {
        Vector3 vec = new Vector3(x, y, 0);
        rb.MovePosition(transform.position+(vec * speed * Time.fixedDeltaTime));
        
    }
    public void MoveSphere(Vector3 direction)
    {
        // transform.Translate(new Vector3(x, y, 0) * speed * Time.deltaTime);
        // rb.AddForce(direction * speed);
        // rb.velocity = direction * speed * Time.deltaTime;
    }
}
