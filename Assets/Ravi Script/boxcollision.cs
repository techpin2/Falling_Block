using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxcollision : MonoBehaviour
{
    public GameObject box;
    public Transform pos;
     
    private void Start()
    {
        int t = Random.Range(0, 10);
        InvokeRepeating("spawn",1,t);
        print(t);

    }
    
    void spawn()
    {
        int x = Random.Range(-3,3);
        float y = pos.position.y;
        Vector3 p = new Vector3(x,y,0);
        Instantiate(box,p,Quaternion.identity);
    }
}
