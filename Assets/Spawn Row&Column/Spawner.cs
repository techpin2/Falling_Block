using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject obj;

    public Transform objPos;
   // public Transform parent;
  
    public int Row;
    public int Column;


    private void Start()
    {
        // Instantiate(obj);
        // Instantiate(obj,new Vector3(5,5,0),Quaternion.identity);

        //Instantiate(obj, objPos.position, Quaternion.identity);
        //Instantiate(obj, objPos.position, objPos.rotation);

        //Instantiate(obj, parent);
        // Instantiate(obj, objPos.position, Quaternion.identity,parent);


        //GameObject newObj= Instantiate(obj);
        //print(newObj.name+"  Position : "+newObj.transform.position);
        // newObj.transform.position = objPos.position;
        //print(newObj.name+"  Position : "+newObj.transform.position);
        // StartCoroutine(Spawn());

        Vector3 initPos = objPos.position;
        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Column; j++)
            {
                GameObject obj2 = Instantiate(obj, initPos, Quaternion.identity, objPos);
                // SpriteRenderer s= obj2.GetComponent<SpriteRenderer>();
                // s.color = Random.ColorHSV();
                //Brick b= obj2.GetComponent<Brick>();
                //b.sp.color = b.defaultColor;
                initPos.x = initPos.x + 1.1f;
            }
            initPos.y = initPos.y - 1.1f;
            initPos.x = objPos.position.x;
        }



    }


    IEnumerator Spawn()
    {
        float x = Random.Range(-2f, 2f);
        float y = Random.Range(-4f, 4f);
        Vector3 pos = new Vector3(x, y, 0);
        GameObject o = Instantiate(obj, pos, Quaternion.identity);
        o.transform.localScale = new Vector3(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), 1);
        yield return new WaitForSeconds(Random.Range(1, 5));
        Destroy(o, Random.Range(0, 3));
        StartCoroutine(Spawn());
    }
}
