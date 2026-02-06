using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class studentListWrapped
{
  
    public List<StudentDTO> students;
    public studentListWrapped(List<StudentDTO> students)
    {
        this.students = students;
    }
}
