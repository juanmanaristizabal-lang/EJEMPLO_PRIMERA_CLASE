using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using System.Linq;

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
    public GameObject PanelMultiple; 
    public GameObject PanelTrueFalse; 

    List<MultipleQuestion> multipleQuestions = new List<MultipleQuestion>();
    List<TrueFalseQuestion> trueFalseQuestions = new List<TrueFalseQuestion>(); 

    int currentQuestion = 0;
    bool isTrueFalseMode = true; 

    void Start()
    {
        if (isTrueFalseMode)
        {
            PanelMultiple.SetActive(false);
            PanelTrueFalse.SetActive(true);

            LoadTrueFalseQuestions(); 
            trueFalseQuestions = trueFalseQuestions.OrderBy(q => Random.value).ToList();

            if (trueFalseQuestions.Count > 0)
            {
                TrueFalseQuestion question = trueFalseQuestions[0];
                questionText.text = question.Question;
                option1Text.text = "Verdadero";
                option2Text.text = "Falso";
                option3Text.transform.parent.gameObject.SetActive(false);
                option4Text.transform.parent.gameObject.SetActive(false);
            }
        }
        else
        {
            PanelMultiple.SetActive(true);
            PanelTrueFalse.SetActive(false);

            LoadMultipleQuestions();
            multipleQuestions = multipleQuestions.OrderBy(q => Random.value).ToList();

            if (multipleQuestions.Count > 0)
            {
                MultipleQuestion question = multipleQuestions[0];
                questionText.text = question.Question;
                option1Text.text = question.Option1;
                option2Text.text = question.Option2;
                option3Text.text = question.Option3;
                option4Text.text = question.Option4;
                option3Text.transform.parent.gameObject.SetActive(true);
                option4Text.transform.parent.gameObject.SetActive(true);
            }
        }

        PanelResultado.SetActive(false);
    }

    public void LoadTrueFalseQuestions()
    {
        string path = Application.streamingAssetsPath + "/FALSO_VERDADERO_2024.txt";
        string[] lines = File.ReadAllLines(path);
        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                TrueFalseQuestion tfQ = new TrueFalseQuestion(line);
                trueFalseQuestions.Add(tfQ);
            }
        }
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
                    parts[0], parts[1], parts[2], parts[3],
                    parts[4], parts[5], parts[6], parts[7]
                );
                multipleQuestions.Add(multipleQ);
            }
        }
    }

    void checkAnswer(string selectedOption)
    {
        PanelResultado.SetActive(true);

        if (isTrueFalseMode) 
        {
            TrueFalseQuestion question = trueFalseQuestions[currentQuestion];

            if (selectedOption == "Verdadero" && question.CorrectAnswer.ToLower() == "true")
            {
                correctAnswerText.text = "Correcto!";
            }
            else if (selectedOption == "Falso" && question.CorrectAnswer.ToLower() == "false")
            {
                correctAnswerText.text = "Correcto!";
            }
            else
            {
                correctAnswerText.text = "incorrecto";
            }

            versiculoText.text = "Versiculo: " + question.Versiculo;
            dificultadText.text = "Dificultad: " + question.Dificultad;
        }
        else 
        {
            MultipleQuestion question = multipleQuestions[currentQuestion];

            if (selectedOption.Trim() == question.Answer.Trim())
            {
                correctAnswerText.text = "Correcto!";
            }
            else
            {
                correctAnswerText.text = "incorrecto";
            }
            versiculoText.text = "Versiculo: " + question.Versiculo;
            dificultadText.text = "Dificultad: " + question.Dificultty;
        }
    }

    public void Option1Selected() { checkAnswer(option1Text.text); }
    public void Option2Selected() { checkAnswer(option2Text.text); }
    public void Option3Selected() { checkAnswer(option3Text.text); }
    public void Option4Selected() { checkAnswer(option4Text.text); }
    public void BotonVerdaderoSelected()
    {
        checkAnswer("Verdadero");
    }

    public void BotonFalsoSelected()
    {
        checkAnswer("Falso");
    }

    public void nextQuestion()
    {
        currentQuestion++;

        if (isTrueFalseMode) 
        {
            if (currentQuestion < trueFalseQuestions.Count)
            {
                TrueFalseQuestion question = trueFalseQuestions[currentQuestion];
                questionText.text = question.Question;
                option1Text.text = "Verdadero";
                option2Text.text = "Falso";
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
        else 
        {
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
    }
}