using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour
{
    public float speed;
    public static bool isGameRunning = false;
    public GameObject screen;
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;

    private Vector3 direction = Vector3.zero;
    public bool isprees;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Key Down");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space Key Up");
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x >= -2.15)
                transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x <= 2.15)
                transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (isGameRunning == false)
            return;

        if (!isprees) return;
        transform.Translate(direction * speed * Time.deltaTime);
        float clampValue = Mathf.Clamp(transform.position.x, -2.15f, 2.15f);
        transform.position = new Vector3(clampValue, transform.position.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("collision detected");
        isGameRunning = false;
        isprees = false;
        screen1.SetActive(true);
        screen2.SetActive(false);
        Destroy(collision.gameObject);
    }
    public void Play()
    {
        isGameRunning = true;
        screen.SetActive(false);

    }
    public void Left()
    {
        isprees = true;
        direction = Vector3.left;
    }
    public void Right()
    {
        isprees = true;
        direction = Vector3.right;
    }
    public void Release()
    {
        isprees = false;
    }
    public void Resatart()
    {
        SceneManager.LoadScene("Game");
    }
    public void Resume()
    {
        isGameRunning = true;
        screen3.SetActive(false);
        screen2.SetActive(true);
    }
}
