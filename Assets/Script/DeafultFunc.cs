using UnityEngine;

public class DeafultFunc : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake Function");
    }

    private void OnEnable()
    {
        Debug.Log("Onenable Function");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Function");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable Function");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update Function");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate Function");
    }

    private void FixedUpdate()
    {
        Debug.Log("Fixed Function");
    }
}
