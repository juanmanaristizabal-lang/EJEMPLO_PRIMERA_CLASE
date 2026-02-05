using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller_Scene_3 : MonoBehaviour
{

    List<Student> list_students = new List<Student>();
    public TMP_InputField tnameS;
    public TMP_InputField tmailS;
    public TMP_InputField tageS;
    public TMP_InputField tcourseS;
    public TMP_InputField tcodeS;
    public TextMeshProUGUI studentsText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddStudent()
    {
        Student student = new Student(tnameS.text, tmailS.text, int.Parse(tageS.text), tcourseS.text, tcodeS.text);
        list_students.Add(student);
        Debug.Log("Student Added: " + student.NameP + ", " + student.MailP + ", " + student.AgeP + ", " + student.CourseS + ", " + student.CodeS);
    }


    public void PrintStudentsPanel()
    {
        studentsText.text = "";
        foreach (Student student in list_students)
        {
            studentsText.text += "Name: " + student.NameP + ", Mail: " + student.MailP + ", Age: " + student.AgeP + ", Course: " + student.CourseS + ", Code: " + student.CodeS + "\n";
        }

    }

    public void SaveStudentsToJson()
    {
        studentListWrapped wrapper = new studentListWrapped(list_students);
        string json = JsonUtility.ToJson(wrapper, true);
        string path = Path.Combine(Application.persistentDataPath, "students.json");
        File.WriteAllText(path, json);
        Debug.Log("Students saved to: " + path);
    }



}