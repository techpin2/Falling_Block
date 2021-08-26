using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemym : MonoBehaviour
{
    public GameObject enemyCar;

    void Start()
    {
        InvokeRepeating("SpawnEnemyCar", 2, 5);
    }
    public void SpawnEnemyCar()
    {
        float inputX = Random.Range(-2.5f, 2.5f);
        Vector3 pos = new Vector3(inputX, 5.4f, 0);
        Instantiate(enemyCar, pos, Quaternion.identity);
    }

    
}
