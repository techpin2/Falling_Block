using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PhoneClone : MonoBehaviour
{
    public GameObject phoneObj;
    public Transform parent;
    public TMP_Text phoneName;
    public TMP_Text phoneRam;
    public TMP_Text phonePrice;
    public Mobile[] phones;
    void Start()
    {
        int index = 0;
        foreach (Mobile item in phones)
        {
           GameObject obj= Instantiate(phoneObj, parent);
           TMP_Text phone_name= obj.transform.GetChild(1).GetComponent<TMP_Text>();
            TMP_Text ram= obj.transform.GetChild(2).GetComponent<TMP_Text>();
            TMP_Text Price= obj.transform.GetChild(3).GetComponent<TMP_Text>();

            phone_name.text = item.name;
            ram.text = item.ram;
            Price.text = item.price.ToString();

            Button butt= obj.GetComponent<Button>();
            int i = index;
            butt.onClick.AddListener(()=> {
                Click(i);
            
            });
            index++;

            
        }
    }
    public void Click(int trr)
    {
        print("Button Detected"+trr);

        Mobile Mobiles = phones[trr];
        phoneName.text = Mobiles.name;
        phoneRam.text = Mobiles.ram;
        phonePrice.text = Mobiles.price.ToString();


    }

}
[System.Serializable]
public class Mobile
{
    public string name;
    public string ram;
    public int price;

}
