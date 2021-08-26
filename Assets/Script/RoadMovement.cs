using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    public Transform endPosition;
    public Transform startPosition;
    public float speed;
    void Update()
    {
        if (CarMovement.isGameRunning == false)
            return;
        transform.Translate(Vector3.up*speed*Time.deltaTime);
        if (transform.position.y <= endPosition.position.y)
            transform.position = startPosition.position;
    }
    
}
