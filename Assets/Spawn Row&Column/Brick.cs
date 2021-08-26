using UnityEngine;

public class Brick : MonoBehaviour
{
    public Color defaultColor;

    public Color selectedColor;
    public SpriteRenderer sp;
    private bool isSelected;

    public BoxCollider2D boxCollider;

    private void Start()
    {
        print(gameObject.name);
        selectedColor = Random.ColorHSV();
        sp = GetComponent<SpriteRenderer>();
        boxCollider= GetComponent<BoxCollider2D>();
        sp.color = defaultColor;
    }

    private void OnMouseDown()
    {
        //if (isSelected == false)
        //{
        //    sp.color = selectedColor;
        //    isSelected = true;
        //}
        //else
        //{
        //    sp.color = defaultColor;
        //    isSelected = false;
        //}
        isSelected = !isSelected;
        sp.color = isSelected ? selectedColor : defaultColor;
    }
}
