using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    public float speed;
    void Update()
    {
        if (CarMovement.isGameRunning == false)
            return;
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        if (transform.position.y <= -7f)
            Destroy(this.gameObject);
    }
}
