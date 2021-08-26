using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyCarObject;

    private void Start()
    {
        //InvokeRepeating("SpawnEnemyCar", 1f, 0.1f);
        StartCoroutine(SpawnEnemyCar1());
    }

    void SpawnEnemyCar()
    {
        float randomX = Random.Range(-2.15f,2.15f);
        Vector3 pos = new Vector3(randomX, 6.48f, 0);
        Instantiate(enemyCarObject[Random.Range(0,enemyCarObject.Length)],pos,Quaternion.identity);
    }

    IEnumerator SpawnEnemyCar1()
    {
        if (CarMovement.isGameRunning)
        {
            float randomX = Random.Range(-2.15f, 2.15f);
            Vector3 pos = new Vector3(randomX, 6.48f, 0);
            Instantiate(enemyCarObject[Random.Range(0, enemyCarObject.Length)], pos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
        yield return null;

         StartCoroutine(SpawnEnemyCar1());
    }
}
