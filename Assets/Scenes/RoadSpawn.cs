using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawn : MonoBehaviour
{
    public GameObject road;
    public Transform startPosition;
    public Transform endPosition;

    public static RoadSpawn roadSpawn;
   
    void Start()
    {
        roadSpawn = this;
    }

    public void Spawn()
    {
        Instantiate(road, startPosition.position, Quaternion.identity,transform);
    }
}
