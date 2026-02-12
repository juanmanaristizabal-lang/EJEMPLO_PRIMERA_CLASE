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
    public TextMeshProUGUI correctAnswerText;
    public TextMeshProUGUI versiculoText;
    public TextMeshProUGUI dificultadText;
    public GameObject PanelResultado;


    List<MultipleQuestion> multipleQuestions = new List<MultipleQuestion>();

    int currentQuestion = 0;


    void Start()
    {
        LoadMultipleQuestions();

        MultipleQuestion question = multipleQuestions[0];
        questionText.text = question.Question;
        option1Text.text = question.Option1;
        option2Text.text = question.Option2;
        option3Text.text = question.Option3;
        option4Text.text = question.Option4;

        PanelResultado.SetActive(false);

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
            if (parts.Length >= 8)
            {

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

   
    void checkAnswer(string selectedOption)
    {
        MultipleQuestion question = multipleQuestions[currentQuestion];

        PanelResultado.SetActive(true);

        if (selectedOption.Trim() == question.Answer.Trim())
        {
            correctAnswerText.text = "Correcto!";
        }
        else
        {
            correctAnswerText.text = "incorrecto";
        }
        versiculoText.text = "Versiculo: " + question.Versiculo;
        dificultadText .text = "Dificultad: " + question.Dificultty;
    }
    public void Option1Selected()
    {
        checkAnswer(option1Text.text);
    }

    public void Option2Selected()
    {
        checkAnswer(option2Text.text);
    }
    public void Option3Selected()
    {
        checkAnswer(option3Text.text);
    }

    public void Option4Selected()
    {
        checkAnswer(option4Text.text);
    }

    public void nextQuestion() {
        currentQuestion++;
        if (currentQuestion < multipleQuestions.Count)
        {
            MultipleQuestion question = multipleQuestions[currentQuestion];
            questionText.text = question.Question;
            option1Text.text = question.Option1;
            option2Text.text = question.Option2;
            option3Text.text = question.Option3;
            option4Text.text = question.Option4;
            correctAnswerText.text = "";
            versiculoText.text = "";
            dificultadText.text = "";

            PanelResultado.SetActive(false); 
        }
        else
        {
            Debug.Log("No hay mas preguntas.");  
        }

    }

    public void closePanel ()
    {
        PanelResultado.SetActive(false);
    }


}