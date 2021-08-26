using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject roadObject;

    public Transform startPoint;
    public Transform endPoint;

    public static RoadManager obj;
    public static int a;

    private void Start()
    {
        obj = this;
    }

    public void RoadSpawn()
    {
        Instantiate(roadObject,startPoint.position,Quaternion.identity);
    }
}
