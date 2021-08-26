using UnityEngine;

public class TransformFunc : MonoBehaviour
{
    public Transform childObj;
   // public GameObject parent;
    void Start()
    {
        // print(transform.childCount);

        // //childObj= transform.GetChild(0).gameObject;
        //GameObject t= childObj.transform.GetChild(1).gameObject;
        // print(t.name);
        // t.SetActive(false);

        // print(t.transform.childCount);

        // print(childObj.transform.childCount);

        // for (int i = 0; i < childObj.transform.childCount; i++)
        // {
        //     childObj.transform.GetChild(i).gameObject.SetActive(false);
        // }

        // Transform t= transform.Find("GameObject");
        // print(t.name);

        // childObj.SetParent(parent.transform);
        // childObj.SetParent(transform);
        Transform tra = childObj.GetChild(2).GetChild(1).GetChild(0);
        Destroy(tra.gameObject);
        //tra.SetParent(transform);
    }
}
