using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;
using static Unity.VisualScripting.Icons;

[Serializable]
public class DialogueEntry
{
    public string ID;
    public string DAY;
    public string RACE;
    public string ACTOR;
    public string TEXT;
    public string TYPE;
    public string TONE;
    public string MOOD;
    public string CLIENT;
    public string GIFT;
}

public class ProductsEntry
{
    public string CLIENTID;
    public string DAY;
    public string CLIENT;
    public string ID;
    public string NUMBEROF;
    public string TYPE1;
    public string TYPE2;
    public string TYPE3;
    public string TOBECHARGED;
    public string CLIENTMONEY;
    public string CORRECTCHOICE;
}

[Serializable]
public class DialogueDatabase
{
    public List<DialogueEntry> entries;
}

public class ProductsDatabase
{
    public List<ProductsEntry> entries;
}

public class CSVImporter : MonoBehaviour
{
    public string currentSceneName;
    [Header("IDIOMA ACTUAL")]
    [SerializeField] private Language currentLanguage = Language.ES; // El predeterminado es español


    // IDIOMAS DISPONIBLES (En caso de tener nuevas traducciones se añadirían aquí)
    public enum Language
    {
        ES,
        EN
    }

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        LoadDialoguesFromLocalCSV(currentLanguage);
    }

    // En caso de querer cambiar el idioma durante el juego (solo para cuando esté descargado).
    public void ChangeLanguage(Language newLanguage)
    {
        currentLanguage = newLanguage;
        LoadDialoguesFromLocalCSV(currentLanguage);
    }

    void LoadDialoguesFromLocalCSV(Language idioma)
    {
        string filename = $"dialogue_{idioma.ToString()}";  //Si es ES cargará el español, si es EN el inglés.
        TextAsset csvFile = Resources.Load<TextAsset>($"CSV/Dialogues/{filename}");

        if (csvFile == null)
        {
            Debug.LogError("No se encontró el archivo local CSV: " + filename);
            return;
        }

        DialogueDatabase db = ParseDialogueCSV(csvFile.text);
        DialogueManager.Instance.LoadFromDatabase(db, currentSceneName);
        ProductsDatabase productsDb= LoadProductsFromLocalCSV();
        DialogueManager.Instance.GenerateDailyClients(); // Crea los DailyClientInfo
        DialogueManager.Instance.AssignProductDataToClients(productsDb);          // Asigna productos a clientes
    }

    ProductsDatabase LoadProductsFromLocalCSV()
    {
        TextAsset csvFile = Resources.Load<TextAsset>($"CSV/Products/products");

        if (csvFile == null)
        {
            Debug.LogError("No se encontró el archivo local CSV de products");
            return null;
        }

        ProductsDatabase pDb = ParseProductsCSV(csvFile.text);
        return pDb;
    }


    #region Traducir de CSV a datos útiles

    DialogueDatabase ParseDialogueCSV(string csv)
    {
        DialogueDatabase db = new DialogueDatabase();
        db.entries = new List<DialogueEntry>();

        string[] lines = csv.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        // Empieza en la línea 1 porque la 0 es la cabecera.
        for (int i = 1; i < lines.Length; i++)
        {
            string[] fields = SplitCSVLine(lines[i]);

            if (fields.Length < 7)
            {
                Debug.LogWarning($"Línea inválida: {lines[i]}");
                continue;
            }

            DialogueEntry entry = new DialogueEntry
            {
                ID = fields[0].Trim(),
                DAY = fields[1].Trim(),
                RACE = fields[2].Trim(),
                ACTOR = fields[3].Trim(),
                TEXT = fields[4].Trim(),
                TYPE = fields[5].Trim(),
                TONE = fields[6].Trim(),
                MOOD = fields[7].Trim(),
                CLIENT = fields[8].Trim(),
                GIFT = fields[9].Trim()
            };

            db.entries.Add(entry);
        }

        return db;
    }

    ProductsDatabase ParseProductsCSV(string csv)
    {
        ProductsDatabase productsDB = new ProductsDatabase();
        productsDB.entries = new List<ProductsEntry>();

        string[] lines = csv.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        // Empieza en la línea 1 porque la 0 es la cabecera.
        for (int i = 1; i < lines.Length; i++)
        {
            string[] fields = SplitCSVLine(lines[i]);

            if (fields.Length < 7)
            {
                Debug.LogWarning($"Línea inválida: {lines[i]}");
                continue;
            }

            ProductsEntry entry = new ProductsEntry
            {
                CLIENTID = fields[0].Trim(),
                DAY = fields[1].Trim(),
                CLIENT = fields[2].Trim(),
                ID = fields[3].Trim(),
                NUMBEROF = fields[4].Trim(),
                TYPE1 = fields[5].Trim(),
                TYPE2 = fields[6].Trim(),
                TYPE3 = fields[7].Trim(),
                TOBECHARGED = fields[95].Trim(),
                CLIENTMONEY = fields[96].Trim(),
                CORRECTCHOICE = fields[97].Trim()
            };

            productsDB.entries.Add(entry);
        }

        return productsDB;
    }

    //Divide las líneas en campos (en este caso un array de cuatro)siempre que estén separados por coma (los diálogos con comas, vienen entrecomillados para que los ignore y nos los tome como separación)
    string[] SplitCSVLine(string line)
    {
        List<string> result = new List<string>();
        bool insideQuotes = false;
        string current = "";

        foreach (char c in line)
        {
            if (c == '"')
                insideQuotes = !insideQuotes;

            else if (c == ',' && !insideQuotes)
            {
                result.Add(current);
                current = "";
            }
            else
                current += c;
        }

        result.Add(current);
        return result.ToArray();
    }

    #endregion
}
