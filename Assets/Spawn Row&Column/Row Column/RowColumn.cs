using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowColumn : MonoBehaviour
{
    public SpriteRenderer sp;
    public BoxCollider2D bc;
    public Color defaultColor;
    public Color selectedColor;
    
    void Start()
    {
        sp = transform.GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        selectedColor =Random.ColorHSV();
        sp.color = defaultColor;
        
    }
    private void OnMouseDown()
    {
        sp.color = selectedColor;
    }

    void Update()
    {
        
    }
}
