using UnityEngine;

public class TrueFalseQuestion
{
    private string question;
    private string optionTrue; 
    private string optionFalse; 
    private string correctAnswer; 
    private string versiculo;
    private string dificultad;
    private string referencia; 

    public TrueFalseQuestion()
    {
    }

    public TrueFalseQuestion(string question, string optionTrue, string optionFalse,
                           string correctAnswer, string versiculo, string dificultad, string referencia = "")
    {
        this.question = question;
        this.optionTrue = optionTrue;
        this.optionFalse = optionFalse;
        this.correctAnswer = correctAnswer;
        this.versiculo = versiculo;
        this.dificultad = dificultad;
        this.referencia = referencia;
    }

    public TrueFalseQuestion(string lineFromFile)
    {
        string[] parts = lineFromFile.Split('-');
        if (parts.Length >= 5)
        {
            this.question = parts[0].Trim();
       
            this.correctAnswer = parts[1].Trim();
            this.referencia = parts[2].Trim();
            this.dificultad = parts[3].Trim();


            this.optionTrue = "Verdadero";
            this.optionFalse = "Falso";


            this.versiculo = parts[2].Trim();
        }
    }


    public string Question { get => question; set => question = value; }
    public string OptionTrue { get => optionTrue; set => optionTrue = value; }
    public string OptionFalse { get => optionFalse; set => optionFalse = value; }
    public string CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
    public string Versiculo { get => versiculo; set => versiculo = value; }
    public string Dificultad { get => dificultad; set => dificultad = value; }
    public string Referencia { get => referencia; set => referencia = value; }
}