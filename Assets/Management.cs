using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Management : MonoBehaviour
{
    Academic ac = new Academic();

    private void Start()
    {
        ac.students.teacher.Set(10,"");
        ac.teachers.Student.Get();
    }

}

[System.Serializable]
public class Academic
{
    public Stu students=new Stu();
    public Teacher teachers=new Teacher();
}

[System.Serializable]
public class Stu
{
    public int id;
    public string name;
    public Teacher teacher;

    public void Set(int id,string name)
    {
        this.id = id;
        this.name = name;
    }

    public void Get()
    {
        Debug.Log("Id="+id);
        Debug.Log("Name="+name);
    }
}

[System.Serializable]
public class Teacher
{
    public int id;
    public string name;
    public Stu Student;

    public void Set(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public void Get()
    {
        Debug.Log("Id=" + id);
        Debug.Log("Name=" + name);
    }
}
