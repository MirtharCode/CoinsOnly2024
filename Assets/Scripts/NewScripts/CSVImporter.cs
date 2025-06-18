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
    public string SUSPECT1;
    public string SUSPECT2;
    public string SUSPECT3;
    public string CORRECTANSWER;
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
    public string HASCOUPON;
    public string COUPONRACE;
    public string COUPONTYPE;
    public string CURRENTREGULATION_01;
    public string WHICHTYPE_01;
    public string WHICHPRODUCT_01;
    public string NEWPRICE_01;
    public string MIX1_01;
    public string MIX2_01;
    public string FORWHO_01;
    public string CURRENTREGULATION_02;
    public string WHICHTYPE_02;
    public string WHICHPRODUCT_02;
    public string NEWPRICE_02;
    public string MIX1_02;
    public string MIX2_02;
    public string FORWHO_02;
    public string CURRENTREGULATION_03;
    public string WHICHTYPE_03;
    public string WHICHPRODUCT_03;
    public string NEWPRICE_03;
    public string MIX1_03;
    public string MIX2_03;
    public string FORWHO_03;
    public string CURRENTREGULATION_04;
    public string WHICHTYPE_04;
    public string WHICHPRODUCT_04;
    public string NEWPRICE_04;
    public string MIX1_04;
    public string MIX2_04;
    public string FORWHO_04;
    public string CURRENTREGULATION_05;
    public string WHICHTYPE_05;
    public string WHICHPRODUCT_05;
    public string NEWPRICE_05;
    public string MIX1_05;
    public string MIX2_05;
    public string FORWHO_05;
    public string CURRENTREGULATION_06;
    public string WHICHTYPE_06;
    public string WHICHPRODUCT_06;
    public string NEWPRICE_06;
    public string MIX1_06;
    public string MIX2_06;
    public string FORWHO_06;
    public string CURRENTREGULATION_07;
    public string WHICHTYPE_07;
    public string WHICHPRODUCT_07;
    public string NEWPRICE_07;
    public string MIX1_07;
    public string MIX2_07;
    public string FORWHO_07;
    public string CURRENTREGULATION_08;
    public string WHICHTYPE_08;
    public string WHICHPRODUCT_08;
    public string NEWPRICE_08;
    public string MIX1_08;
    public string MIX2_08;
    public string FORWHO_08;
    public string CURRENTREGULATION_09;
    public string WHICHTYPE_09;
    public string WHICHPRODUCT_09;
    public string NEWPRICE_09;
    public string MIX1_09;
    public string MIX2_09;
    public string FORWHO_09;
    public string CURRENTREGULATION_10;
    public string WHICHTYPE_10;
    public string WHICHPRODUCT_10;
    public string NEWPRICE_10;
    public string MIX1_10;
    public string MIX2_10;
    public string FORWHO_10;
    public string CURRENTREGULATION_11;
    public string WHICHTYPE_11;
    public string WHICHPRODUCT_11;
    public string NEWPRICE_11;
    public string MIX1_11;
    public string MIX2_11;
    public string FORWHO_11;
    public string CURRENTREGULATION_12;
    public string WHICHTYPE_12;
    public string WHICHPRODUCT_12;
    public string NEWPRICE_12;
    public string MIX1_12;
    public string MIX2_12;
    public string FORWHO_12;
    public string TOBECHARGED;
    public string CLIENTMONEY;
    public string CORRECTCHOICE;
    public string TIPSIFCHECK;
    public string TIPSIFBYE;
    public string BOSSCOMPLAINSCHECKWRONG;
    public string BOSSCOMPLAINSBYEWRONG;
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
        
        // En caso que no venga de un Minijuego, que me genere la lista de clientes de ese día
        if (DialogueManager.Instance.savedDailyCustomers.Count == 0)
        {
            Debug.Log("Creo una lista de clientes diarios porque no había nada guardado en savedDailyCustomers");
            DialogueManager.Instance.GenerateDailyClients(); // Crea los DailyClientInfo
            DialogueManager.Instance.AssignProductDataToClients(productsDb);          // Asigna productos a clientes
        }        
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
                GIFT = fields[9].Trim(),
                SUSPECT1 = fields[10].Trim(),
                SUSPECT2 = fields[11].Trim(),
                SUSPECT3 = fields[12].Trim(),
                CORRECTANSWER = fields[13].Trim(),
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
                HASCOUPON = fields[8].Trim(),
                COUPONRACE = fields[9].Trim(),
                COUPONTYPE = fields[10].Trim(),

                #region REGULATIONS_DATA
                CURRENTREGULATION_01 = fields[11].Trim(),
                WHICHTYPE_01 = fields[12].Trim(),
                WHICHPRODUCT_01 = fields[13].Trim(),
                NEWPRICE_01 = fields[14].Trim(),
                MIX1_01 = fields[15].Trim(),
                MIX2_01 = fields[16].Trim(),
                FORWHO_01 = fields[17].Trim(),
                CURRENTREGULATION_02 = fields[18].Trim(),
                WHICHTYPE_02 = fields[19].Trim(),
                WHICHPRODUCT_02 = fields[20].Trim(),
                NEWPRICE_02 = fields[21].Trim(),
                MIX1_02 = fields[22].Trim(),
                MIX2_02 = fields[23].Trim(),
                FORWHO_02 = fields[24].Trim(),
                CURRENTREGULATION_03 = fields[25].Trim(),
                WHICHTYPE_03 = fields[26].Trim(),
                WHICHPRODUCT_03 = fields[27].Trim(),
                NEWPRICE_03 = fields[28].Trim(),
                MIX1_03 = fields[29].Trim(),
                MIX2_03 = fields[30].Trim(),
                FORWHO_03 = fields[31].Trim(),
                CURRENTREGULATION_04 = fields[32].Trim(),
                WHICHTYPE_04 = fields[33].Trim(),
                WHICHPRODUCT_04 = fields[34].Trim(),
                NEWPRICE_04 = fields[35].Trim(),
                MIX1_04 = fields[36].Trim(),
                MIX2_04 = fields[37].Trim(),
                FORWHO_04 = fields[38].Trim(),
                CURRENTREGULATION_05 = fields[39].Trim(),
                WHICHTYPE_05 = fields[40].Trim(),
                WHICHPRODUCT_05 = fields[41].Trim(),
                NEWPRICE_05 = fields[42].Trim(),
                MIX1_05 = fields[43].Trim(),
                MIX2_05 = fields[44].Trim(),
                FORWHO_05 = fields[45].Trim(),
                CURRENTREGULATION_06 = fields[46].Trim(),
                WHICHTYPE_06 = fields[47].Trim(),
                WHICHPRODUCT_06 = fields[48].Trim(),
                NEWPRICE_06 = fields[49].Trim(),
                MIX1_06 = fields[50].Trim(),
                MIX2_06 = fields[51].Trim(),
                FORWHO_06 = fields[52].Trim(),
                CURRENTREGULATION_07 = fields[53].Trim(),
                WHICHTYPE_07 = fields[54].Trim(),
                WHICHPRODUCT_07 = fields[55].Trim(),
                NEWPRICE_07 = fields[56].Trim(),
                MIX1_07 = fields[57].Trim(),
                MIX2_07 = fields[58].Trim(),
                FORWHO_07 = fields[59].Trim(),
                CURRENTREGULATION_08 = fields[60].Trim(),
                WHICHTYPE_08 = fields[61].Trim(),
                WHICHPRODUCT_08 = fields[62].Trim(),
                NEWPRICE_08 = fields[63].Trim(),
                MIX1_08 = fields[64].Trim(),
                MIX2_08 = fields[65].Trim(),
                FORWHO_08 = fields[66].Trim(),
                CURRENTREGULATION_09 = fields[67].Trim(),
                WHICHTYPE_09 = fields[68].Trim(),
                WHICHPRODUCT_09 = fields[69].Trim(),
                NEWPRICE_09 = fields[70].Trim(),
                MIX1_09 = fields[71].Trim(),
                MIX2_09 = fields[72].Trim(),
                FORWHO_09 = fields[73].Trim(),
                CURRENTREGULATION_10 = fields[74].Trim(),
                WHICHTYPE_10 = fields[75].Trim(),
                WHICHPRODUCT_10 = fields[76].Trim(),
                NEWPRICE_10 = fields[77].Trim(),
                MIX1_10 = fields[78].Trim(),
                MIX2_10 = fields[79].Trim(),
                FORWHO_10 = fields[80].Trim(),
                CURRENTREGULATION_11 = fields[81].Trim(),
                WHICHTYPE_11 = fields[82].Trim(),
                WHICHPRODUCT_11 = fields[83].Trim(),
                NEWPRICE_11 = fields[84].Trim(),
                MIX1_11 = fields[85].Trim(),
                MIX2_11 = fields[86].Trim(),
                FORWHO_11 = fields[87].Trim(),
                CURRENTREGULATION_12 = fields[88].Trim(),
                WHICHTYPE_12 = fields[89].Trim(),
                WHICHPRODUCT_12 = fields[90].Trim(),
                NEWPRICE_12 = fields[91].Trim(),
                MIX1_12 = fields[92].Trim(),
                MIX2_12 = fields[93].Trim(),
                FORWHO_12 = fields[94].Trim(),
                #endregion

                TOBECHARGED = fields[95].Trim(),
                CLIENTMONEY = fields[96].Trim(),
                CORRECTCHOICE = fields[97].Trim(),
                TIPSIFCHECK = fields[98].Trim(),
                TIPSIFBYE = fields[99].Trim(),
                BOSSCOMPLAINSCHECKWRONG = fields[100].Trim(),
                BOSSCOMPLAINSBYEWRONG = fields[101].Trim()
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
