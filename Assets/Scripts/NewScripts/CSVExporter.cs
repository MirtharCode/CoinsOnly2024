using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVExporter : MonoBehaviour
{
    public static CSVExporter Instance;

    private string sessionID;
    private string csvPath;

    private float startTime;
    private List<float> clientTimes = new List<float>();
    private bool isTiming = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        DateTime now = DateTime.Now;
        sessionID = now.ToString("HHmmssddMMyy");

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderPath = Path.Combine(desktopPath, "ClientLogs");

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        csvPath = Path.Combine(folderPath, "DatosDeLaDemo.csv");

        if (!File.Exists(csvPath))
        {
            string header = "ID,clientZERO,clientONE,clientTWO,clientTHREE,clientFOUR,clientFIVE,clientSIX,clientSEVEN,clientFINAL";
            File.WriteAllText(csvPath, header + "\n");
        }
    }

    public void StartClientTimer()
    {
        if (!isTiming)
        {
            startTime = Time.time;
            isTiming = true;
        }
        else
        {
            Debug.LogWarning("[CSVExporter] Intento de iniciar temporizador mientras ya está activo.");
        }
    }

    public void StopClientTimer()
    {
        if (isTiming)
        {
            float duration = Time.time - startTime;
            clientTimes.Add(duration);
            isTiming = false;
        }
        else
        {
            Debug.LogWarning("[CSVExporter] Se intentó detener un temporizador que no estaba corriendo.");
        }
    }

    public void FinalizeSession()
    {
        // Si aún no se detuvo el último cliente, lo forzamos
        if (isTiming)
        {
            StopClientTimer();
        }

        string line = sessionID;

        foreach (var time in clientTimes)
        {
            line += "," + time.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
        }

        // Rellenamos con 0 si faltan clientes
        while (clientTimes.Count < 9)
        {
            line += ",0";
        }

        File.AppendAllText(csvPath, line + "\n");
        Debug.Log($"[CSV LOG] Datos guardados en: {csvPath}");
    }
}
