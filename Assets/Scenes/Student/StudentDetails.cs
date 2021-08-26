using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class StudentDetails : MonoBehaviour
{
    public GameObject students;
    public Transform parent;
    public Student[] stu;
    public GameObject scroll;
    public GameObject indivisualStudent;
    void Start()
    {
     int index = 0;
        foreach (Student item in stu)
        {

            GameObject obj = Instantiate(students, parent);
            Image img = obj.transform.GetChild(0).GetComponent<Image>();
            TMP_Text studentName = obj.transform.GetChild(1).GetComponent<TMP_Text>();
            TMP_Text fatherName = obj.transform.GetChild(2).GetComponent<TMP_Text>();
            TMP_Text dob = obj.transform.GetChild(3).GetComponent<TMP_Text>();

            studentName.text = item.studentName;
            fatherName.text = item.fatherName;
            dob.text = item.DOB;
            if (item.image == null)
                img.color = Color.black;
            else
                img.sprite = item.image;

            Button bu = obj.GetComponent<Button>();
            int i = index;
            bu.onClick.AddListener(() =>
            {
                ClickButton(i);

            });


            index++;

        }
    }
    public void ClickButton(int index)
    {
        print("Button Detect" + index);
        scroll.SetActive(false);
        indivisualStudent.SetActive(true);

        Image img= indivisualStudent.transform.GetChild(0).GetComponent<Image>();
        TMP_Text Studentname = indivisualStudent.transform.GetChild(1).GetComponent<TMP_Text>();
        TMP_Text fathername= indivisualStudent.transform.GetChild(2).GetComponent<TMP_Text>();
        TMP_Text dob= indivisualStudent.transform.GetChild(3).GetComponent<TMP_Text>();

        Student st = stu[index];
        img.sprite = st.image;
        Studentname.text = st.studentName;
        fathername.text = st.fatherName;
        dob.text = st.DOB;

    }
    public void BackButton()
    {
        indivisualStudent.SetActive(false);
        scroll.SetActive(true);
    }
}
[System.Serializable]
public class Student
{
    public Sprite image;
    public string studentName;
    public string fatherName;
    public string DOB;
}

