using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ControllerGame : MonoBehaviour
{

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI option1Text;
    public TextMeshProUGUI option2Text;
    public TextMeshProUGUI option3Text;
    public TextMeshProUGUI option4Text;


    List<MultipleQuestion> multipleQuestions = new List<MultipleQuestion>();


    void Start()
    {
        LoadMultipleQuestions();

        MultipleQuestion question = multipleQuestions[0];
        questionText.text = question.Question;
        option1Text.text = question.Option1;
        option2Text.text = question.Option2;
        option3Text.text = question.Option3;
        option4Text.text = question.Option4;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMultipleQuestions()
    {

        string path = Application.streamingAssetsPath + "/ArchivoPreguntasMV3 - copia.txt";
        string[] lines = File.ReadAllLines(path);
        foreach (string line in lines)
        {
            string[] parts = line.Split('-');

            MultipleQuestion multipleQ = new MultipleQuestion(
                parts[0],
                parts[1],
                parts[2],
                parts[3],
                parts[4],
                parts[5],
                parts[6],
                parts[7]
           
                );

            multipleQuestions.Add(multipleQ);
        }
       
    }
        }