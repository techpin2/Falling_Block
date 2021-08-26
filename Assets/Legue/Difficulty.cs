using UnityEngine;

public class Difficulty:MonoBehaviour
{
    public static Difficulty difficulty;

    public float secondsToMaxDificulty = 60;
    private float t = 0;
    private void Awake()
    {
        difficulty = this;
    }
    public float GetDifficultyPercent()
    {
        t+=0.5f;
        return Mathf.Clamp01(t / secondsToMaxDificulty);
    }
}