using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField]private Carmanagement[] bolero; //or public Carmanager[] bolero;
    [SerializeField]private Book[] books;

    //public GameObject car1;
    //public Transform car2;

    public GameObject startPanel;

   // public SpriteRenderer sp;

    private void Start()
    {
      //  car1.SetActive(false);
        //car2.gameObject.SetActive(false);
    }
    public bool b;
    void Update()
    {
        if (b == true)
        {
            for (int i = 0; i < bolero.Length; i++)
            {
                bolero[i].car.Translate(new Vector3(0, 1, 0) * bolero[i].speed * Time.deltaTime);
            }
            // car1.transform.Translate(Vector3.up * 10 * Time.deltaTime);
        }
    }

    public void Play()
    {
        b = true;
        startPanel.SetActive(false);
    }

}

[System.Serializable]
public class Carmanagement
    {
    public float speed;
    public Transform car;
    }

[System.Serializable]
public class Book
{
    public float id;
    public string name;
}
