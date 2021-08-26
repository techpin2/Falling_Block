using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManage : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public GameObject enemyPrefab;
    public Transform blocksParent;


    // public float secondBseetweenSpawn = 1;
    public Vector2 secondsBetweenSpawnsMinMax;
    public Vector2 spawnSizeMinMax;
    public float spawanAngleMax;

    Vector3 screenHalfSizeWorldUnits;
    float nextSpawnTime;

    void Start()
    {
        screenHalfSizeWorldUnits = new Vector3(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void Update()
    {
        if (!MenuUI.isGameRunning) return;
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.difficulty.GetDifficultyPercent());
            //  print(secondsBetweenSpawns);
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float spawanAngle = Random.Range(-spawanAngleMax, spawanAngleMax);

            Vector3 SpawnPosition = new Vector3(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
           
            int i = Random.Range(0, 2);
            GameObject obj = i == 0 ? enemyPrefab : fallingBlockPrefab;
            GameObject enemy = Instantiate(obj, SpawnPosition, Quaternion.Euler(Vector3.forward * spawanAngle), blocksParent);
            enemy.transform.localScale = Vector3.one * spawnSize;
        }
    }
}
