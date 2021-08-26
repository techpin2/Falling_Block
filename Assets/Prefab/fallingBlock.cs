using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingBlock : MonoBehaviour
{
    public Vector3 speedMinMax;
    float speed;
    float visibleHeightThreshold;

    private void Start()
    {
        float clamp01 = Difficulty.difficulty.GetDifficultyPercent();
       // print("clamp01 :"+clamp01);
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, clamp01);
       // print(speed);
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
        
    }


    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime,Space.Self);
        if (transform.position.y < visibleHeightThreshold)
            Destroy(gameObject);
    }
}
