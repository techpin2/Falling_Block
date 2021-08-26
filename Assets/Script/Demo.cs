using UnityEngine;

public class Demo : MonoBehaviour
{
    public Color newColor;
    public Color defaultColor;
    public SpriteRenderer sp;
    public bool isColorChange;

    public Vector3 scale;
    public Vector3 position;
    //public Quaternion roat;

    public Color[] colors;
    public Vector3[] scales;

    private int index=-1;
    private int index1 = -1;
    
    

    // Start is called before the first frame update

    private void Update()
    {
        //  ChangeColor();
       
       
     
    }

    void ChangeColor()
    {
        if (isColorChange == true)
            sp.color = newColor;
        else
        {
            sp.color = defaultColor;
        }

       // transform.localScale = scale;
        transform.position = position;
         //transform.rotation = roat;
    }

    public bool outOfIndex = false;

    private void OnMouseDown()
    {
        Debug.Log("Touch Detect" + transform.name);
        index1++;
        if(index1 == colors.Length)
        {
            index1 = 0;
        }
        sp.color = colors[index1];


        if (outOfIndex == false)
        {
            index = index + 1;
            if ( index == scales.Length)
            {
                index = scales.Length-2;
                outOfIndex = true;
            }
            transform.localScale = scales[index];
        }
        else
        {
            index = index - 1;
            if (index <=-1)
            {
                index = 1;
                outOfIndex = false;
            }
            transform.localScale = scales[index];
        }

    }
    
}
