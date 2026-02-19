using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class StackDemoUI : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField inputValue;
    public TextMeshProUGUI stackView;
    public TextMeshProUGUI topView;

    [Header("Carro")]
    public TMP_InputField Vehiculo;
    public TMP_InputField Marca;
    public TMP_InputField Modelo;
    public TMP_InputField Placa;
    public TMP_InputField NumeroPuertas;

    private Stack<Carro> stack = new Stack<Carro>();

    public void Push()
    {
       

        string idVehiculo = Vehiculo.text.Trim();
        string marca = Marca.text.Trim();
        string modelo = Modelo.text.Trim();
        string placa = Placa.text.Trim();
        int puertas = int.Parse(NumeroPuertas.text.Trim());

        Carro nuevo = new Carro(idVehiculo,marca,modelo,placa,puertas);
        stack.Push(nuevo);
        ShowStack();
    }

    public void Pop()
    {
        if (stack.Count == 0) return;

        Carro removed = stack.Pop();
        Debug.Log("POP: " + removed);
        ShowStack();
    }

    public void Clear()
    {
        stack.Clear();
        ShowStack();
    }

    private void ShowStack()
    {
        topView.text = stack.Count > 0 ? $"TOP: {stack.Peek().placa}" : "TOP: (vacío)";

        var sb = new StringBuilder();
        sb.AppendLine("PILA (Top → Bottom)");

        foreach (Carro c in stack)
            sb.AppendLine($"• {c.placa} - {c.marca} {c.modelo}");

        stackView.text = sb.ToString();
    }
}
