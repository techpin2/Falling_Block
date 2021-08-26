using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneManager : MonoBehaviour
{
    public GameObject phoneObj;
    public Transform parent;

    public GameObject scrollView;
    public GameObject info;

    public Phone[] phones;

    private void Start()
    {
        int index = 0;
        foreach (Phone item in phones)
        {
           GameObject obj= Instantiate(phoneObj,parent);
          TMP_Text phoneName=  obj.transform.GetChild(1).GetComponent<TMP_Text>();
          TMP_Text ram=  obj.transform.GetChild(2).GetComponent<TMP_Text>();
          TMP_Text price=  obj.transform.GetChild(3).GetComponent<TMP_Text>();

            phoneName.text = item.name;
            ram.text = item.ram;
            price.text = item.price;

           Button b= obj.GetComponent<Button>();
                int i = index;
            b.onClick.AddListener(() => {

                ButtonClick(i);

            });
            index++;
        }
    }

    public void ButtonClick(int index)
    {
        scrollView.SetActive(false);
        info.SetActive(true);

        TMP_Text phoneName = info.transform.GetChild(1).GetComponent<TMP_Text>();
        TMP_Text ram = info.transform.GetChild(2).GetComponent<TMP_Text>();
        TMP_Text price = info.transform.GetChild(3).GetComponent<TMP_Text>();

       Phone item= phones[index];

        phoneName.text = item.name;
        ram.text = item.ram;
        price.text = item.price;
    }
}





[System.Serializable]
public class Phone
{
    public Image phoneImage;
    public string name;
    public string ram;
    public string price;
}
