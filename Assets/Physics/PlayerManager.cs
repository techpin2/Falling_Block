using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    float x;
    float y;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        print(Application.targetFrameRate);
    }

    void Update()
    {
        print("update");
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        print("X :" + x + " Y :" + y);
        // MovePlayer(new Vector3(x,y,0));
    }

    private void FixedUpdate()
    {
        print("Fixed update");
        rb.MovePosition(transform.position + new Vector3(x, y, 0) * speed * Time.fixedDeltaTime);
    }


    private void MovePlayer(Vector3 direction)
    {
        // transform.Translate(direction*speed);
        // rb.AddForce(direction * speed,ForceMode.Force);
        // rb.velocity = direction * speed*Time.deltaTime;
        rb.MovePosition(direction * speed * Time.deltaTime);
    }
}
