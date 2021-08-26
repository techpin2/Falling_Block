using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadspeed : MonoBehaviour
{
    public float speed;
 //   public Transform endpoint;
   // public Transform startpoint;

    void Update()
    {
        RoadManager.a = 20;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y <= RoadManager.obj.endPoint.position.y)
        {
            RoadManager.obj.RoadSpawn();
            Debug.Log("cross end point");
            Destroy(this.gameObject);
        }
            //transform.position = RoadManager.obj.startPoint.position;
    }
}
