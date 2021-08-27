using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public GameObject colorPrefab;
    public Transform contentPanel;
    public Buy[] colors;

    float totalscore = 0;

    private void Start()
    {
        PlayerPrefs.SetInt("score", 500);
        totalscore = PlayerPrefs.GetInt("score");
        print(totalscore);
        for (int i = 0; i < colors.Length; i++)
        {
            GameObject obj = Instantiate(colorPrefab, contentPanel);
            obj.GetComponent<Image>().color = colors[i].color;

            if (PlayerPrefs.HasKey(i + "itemPurchase"))
            {
                int purchaseIndex = PlayerPrefs.GetInt(i + "itemPurchase");
                if (PlayerPrefs.HasKey("usedIndex"))
                {
                    int usedIndex = PlayerPrefs.GetInt("usedIndex");
                    if (i == usedIndex)
                        ResetValue(usedIndex, "Used", Color.grey);
                    else
                        ResetValue(i, "Use", Color.green);
                }
                else
                {
                    ResetValue(i, "Use", Color.green);
                }
                int t = i;
                obj.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
                {
                    Use(t);
                });
            }
            else
            {
                obj.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = colors[i].price + "Buy";
                int t = i;
                obj.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
                {
                    OnBuyClick(t);
                });
            }

        }
    }

    public void OnBuyClick(int i)
    {
        Buy item = colors[i];
        if (item.price <= totalscore)
        {
            totalscore = totalscore - item.price;
            PlayerPrefs.SetInt("score", (int)totalscore);
            PlayerPrefs.SetInt(i + "itemPurchase", i);
            print("SuccessFully Purchase");

            GameObject obj = contentPanel.GetChild(i).gameObject;
            obj.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "Use";
            Button btn = obj.transform.GetChild(0).GetComponent<Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => { Use(i); });
        }
        else
        {
            print("Insufficient Coins");
        }
    }

    public void Use(int i)
    {
        int usedIndex = PlayerPrefs.GetInt("usedIndex");
        ResetValue(usedIndex, "Use", Color.green);

        PlayerPrefs.SetInt("usedIndex", i);
        ResetValue(i, "Used", Color.grey);
    }

    private void ResetValue(int index, string str, Color color)
    {
        GameObject obj = contentPanel.GetChild(index).gameObject;
        obj.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = str;
        obj.transform.GetChild(0).GetComponent<Image>().color = color;
    }
    public void Back(int index)
    {
       SceneManager.LoadScene(index);
    }
    
}

[System.Serializable]
public class Buy
{
    public Color color;
    public float price;
}


