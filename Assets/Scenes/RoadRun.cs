using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRun : MonoBehaviour
{ 
    public float speed;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= RoadSpawn.roadSpawn.endPosition.position.y)
        {
            RoadSpawn.roadSpawn.Spawn();
            Destroy(gameObject);

            
        }
          
    }
}
