using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class QueueDemoUI : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField inputValue;
    public TextMeshProUGUI queueView;
    public TextMeshProUGUI frontView;

    [Header("Carro")]
    public TMP_InputField Vehiculo;
    public TMP_InputField Marca;
    public TMP_InputField Modelo;
    public TMP_InputField Placa;
    public TMP_InputField NumeroPuertas;


    private Queue<Carro> queue = new Queue<Carro>();

    public void Enqueue()
    {
        string id = Vehiculo.text.Trim();
        string marca = Marca.text.Trim();
        string modelo = Modelo.text.Trim();
        string placa = Placa.text.Trim();
        int puertas = int.Parse(NumeroPuertas.text);

        Carro nuevo = new Carro(id,marca,modelo,placa,puertas);
        queue.Enqueue(nuevo);
        showQueue();
    }

    private void showQueue()
    {
        throw new NotImplementedException();
    }

    public void Dequeue()
    {
        if (queue.Count == 0) return;

        Carro served = queue.Dequeue();
        Debug.Log("DEQUEUE: " + served);
        ShowQueue();
    }

    public void Clear()
    {
        queue.Clear();
        ShowQueue();
    }

    private void ShowQueue()
    {
        frontView.text = queue.Count > 0 ? $"FRENTE: {queue.Peek()}" : "FRENTE: (vacío)";

        var sb = new StringBuilder();
        sb.AppendLine("COLA (Frente → Final)");

        foreach (Carro c in queue)
            sb.AppendLine($"• {c.placa} - {c.marca} {c.modelo}");

        queueView.text = sb.ToString();
    }
}