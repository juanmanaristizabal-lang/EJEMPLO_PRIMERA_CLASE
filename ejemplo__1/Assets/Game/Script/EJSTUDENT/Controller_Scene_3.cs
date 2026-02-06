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
    public TextMeshProUGUI panelObject; 


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
        Student students = new Student (tnameS.text, tmailS.text, int.Parse(tageS.text), tcourseS.text, tcodeS.text);
        list_students.Add(students);
        Debug.Log("Student Added: " + students.NameP + ", " + students.MailP + ", " + students.AgeP + ", " + students.CourseS + ", " + students.CodeS);
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
       List<StudentDTO> dtoList = new List<StudentDTO>();
        foreach (Student student in list_students)
        {
            StudentDTO dto = new StudentDTO
            {
                nameP = student.NameP,
                mailP = student.MailP,
                ageP = student.AgeP,
                courseS = student.CourseS,
                codeS = student.CodeS
            };
            dtoList.Add(dto);
        }
        studentListWrapped wrapper = new studentListWrapped(dtoList);
        wrapper.students = dtoList;
        string json = JsonUtility.ToJson(wrapper, true);
        string path = Application.persistentDataPath + "/students.json";
        File.WriteAllText(path, json);
        Debug.Log("Students saved to: " + path);
    }

    public void LoadStudentsFromJson()
    {
        string path = Path.Combine(Application.persistentDataPath, "students.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            studentListWrapped wrapper = JsonUtility.FromJson<studentListWrapped>(json);

            list_students.Clear();

            foreach (StudentDTO dto in wrapper.students)
            {
                Student s = new Student(dto.nameP, dto.mailP, dto.ageP, dto.courseS, dto.codeS);
                list_students.Add(s);
            }

            PrintStudentsPanel();
          
        }
    }


}