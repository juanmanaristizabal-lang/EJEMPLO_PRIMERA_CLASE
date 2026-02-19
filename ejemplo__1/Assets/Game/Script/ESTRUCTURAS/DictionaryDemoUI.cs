using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class DictionaryDemoUI : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField inputKey;
    public TMP_InputField inputValue;
    public TextMeshProUGUI resultView;
    public TextMeshProUGUI dictView;

    [Header("Carro")]
    public TMP_InputField Vehiculo;
    public TMP_InputField Marca;
    public TMP_InputField Modelo;
    public TMP_InputField Placa;
    public TMP_InputField NumeroPuertas;

    private Dictionary<string, Carro> dict = new Dictionary<string, Carro>();

    public void AddOrUpdate()
    {
        string id = Vehiculo.text.Trim();
        string marca = Marca.text.Trim();
        string modelo = Modelo.text.Trim();
        string placa = Placa.text.Trim();
        int puertas = int.Parse(NumeroPuertas.text);

        Carro nuevo = new Carro(id, marca, modelo, placa, puertas);

        dict[placa] = nuevo; // si existe, actualiza; si no, agrega     
        resultView.text = $"Guardado: {placa}";
        ShowDictionary();
    }

    public void Get()
    {
        string k = inputKey.text.Trim();
        if (string.IsNullOrEmpty(k)) return;

        if (dict.TryGetValue(k, out var v))
            resultView.text = $"Encontrado: [{k}] = {v}";
        else
            resultView.text = $"No existe la clave: {k}";
    }

    public void Remove()
    {
        string k = inputKey.text.Trim();
        if (string.IsNullOrEmpty(k)) return;

        bool removed = dict.Remove(k);
        resultView.text = removed ? $"Eliminado: {k}" : $"No se pudo eliminar (no existe): {k}";
        ShowDictionary();
    }

    public void Clear()
    {
        dict.Clear();
        resultView.text = "Diccionario limpiado";
        ShowDictionary();
    }

    private void ShowDictionary()
    {
        var sb = new StringBuilder();
        sb.AppendLine("DICCIONARIO (Placa → Carro)");

        foreach (var kv in dict)
            sb.AppendLine($"• {kv.Key} → {kv.Value.marca} {kv.Value.modelo}");
        dictView.text = sb.ToString();
    }
}