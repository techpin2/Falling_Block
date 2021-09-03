using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float screenHalfWidthInWorldUnit;

    public GameObject ob1;
    public GameObject ob2;

    //[SerializeField]
    private float inputX;
    private int score;

    int lastScore;

    public Color[] colors;

    void Start()
    {
        int selectedIndex = PlayerPrefs.GetInt("usedIndex");
        GetComponent<MeshRenderer>().material.color = colors[selectedIndex];
        lastScore = PlayerPrefs.GetInt("score");
        MenuUI.menuUI.SetHighScore(lastScore);

        screenHalfWidthInWorldUnit = Camera.main.orthographicSize * Camera.main.aspect+transform.localScale.x/2;
       
        
        float f = Camera.main.orthographicSize * Camera.main.aspect+ob1.transform.localScale.x/2;
        float f1 = Camera.main.orthographicSize * Camera.main.aspect+ob2.transform.localScale.x/2;


        ob1.transform.position = new Vector3(f,ob1.transform.position.y,0);
        ob2.transform.position = new Vector3(-f1,ob2.transform.position.y,0);
    }


    void Update()
    {
        //  if(Application.isEditor)
#if UNITY_EDITOR
        inputX = Input.GetAxisRaw("Horizontal");
#endif
        //print( "direction="+inputX);
        float velocity= inputX * speed;
        transform.Translate(Vector3.right*velocity*Time.deltaTime);
        if (MenuUI.isGameRunning == true)
        {
            if (transform.position.x < -screenHalfWidthInWorldUnit)
                transform.position = new Vector3(screenHalfWidthInWorldUnit, transform.position.y);

            if (transform.position.x > screenHalfWidthInWorldUnit)
                transform.position = new Vector3(-screenHalfWidthInWorldUnit, transform.position.y);
        }

        float scr = Screen.width/2;
        if (Input.GetMouseButtonDown(0))
        {
           Vector3 pos= Input.mousePosition;
            if (pos.x >= scr)
                Right();
            else
                Left();
        }
        if(Input.GetMouseButtonUp(0))
        {
            Release();
        }
    }
    //public void OnCollisionEnter2D(Collision2D triggerCollider)
    //{
    //    if(triggerCollider.gameObject.tag =="Falling Block")
    //    { Destroy(gameObject); }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Falling Block")
        {
            Destroy(collision.gameObject);
            AddScore();
        }

        if (collision.gameObject.tag == "Enemy Block")
        {
            Destroy(gameObject);
            MenuUI.menuUI.gameOverScreen.SetActive(true);
            MenuUI.menuUI.buttonScreen.SetActive(false);
            MenuUI.isGameRunning = false;

            if(lastScore<score)
                PlayerPrefs.SetInt("score", score);
        }

    }
    public void Left()
    {

        inputX = -1;
    }
    public void Right()
    {
        inputX = 1;
    }
    public void Release()
    {
        inputX = 0;
    }
    public void AddScore()
    {
        score++;
        MenuUI.menuUI.SetScore(score);
    }
    
}
