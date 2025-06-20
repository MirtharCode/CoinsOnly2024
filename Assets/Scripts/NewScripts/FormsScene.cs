using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FormsScene : MonoBehaviour
{
    public GameObject intro1, intro2, intro3;
    public GameObject pregunta1;
    public GameObject pregunta2;
    public GameObject pregunta3_ANTONIO, pregunta3_ELVOG, pregunta3_ELIDORA, pregunta3_PIJUSMAGNUS, pregunta3_RAVEN, pregunta3_ROCON, pregunta3_MINIJEFE, pregunta3_DETECTIVE;
    public GameObject pregunta4;
    public GameObject pregunta5;
    public GameObject pregunta6;
    public GameObject pregunta7;
    public GameObject pregunta8;
    public GameObject pregunta9;
    public GameObject pregunta10;
    public GameObject pregunta11;
    public GameObject pregunta12;
    public GameObject pregunta13;
    public GameObject pregunta14;
    public GameObject pregunta15;
    public GameObject outro;

    // RESPUESTA PREGUNTA 1
    public bool demoAburrida, demoNormal, demoEntretenida, demoDivertida;

    public int atLeastOne = 0;

    // RESPUESTA PREGUNTA 2
    public bool elegidoANTONIO, elegidoELVOG, elegidoELIDORA, elegidoPIJUSMAGNUS, elegidoRAVEN, elegidoROCON, elegidoMINIJEFE, elegidoDETECTIVE;

    // RESPUESTA PREGUNTA 3
    public bool aspectoVisualANTONIO, personalidadGuionANTONIO, ambasCosasANTONIO;
    public bool aspectoVisualELVOG, personalidadGuionELVOG, ambasCosasELVOG;
    public bool aspectoVisualELIDORA, personalidadGuionELIDORA, ambasCosasELIDORA;
    public bool aspectoVisualPIJUSMAGNUS, personalidadGuionPIJUSMAGNUS, ambasCosasPIJUSMAGNUS;
    public bool aspectoVisualRAVEN, personalidadGuionRAVEN, ambasCosasRAVEN;
    public bool aspectoVisualROCON, personalidadGuionROCON, ambasCosasROCON;
    public bool aspectoVisualMINIJEFE, personalidadGuionMINIJEFE, ambasCosasMINIJEFE;
    public bool aspectoVisualDETECTIVE, personalidadGuionDETECTIVE, ambasCosasDETECTIVE;

    public List<GameObject> charactersPanelsSelected;

    // RESPUESTA PREGUNTA 4
    public bool yesCosmetics, noCosmetics;

    // RESPUESTA PREGUNTA 5
    public bool entendiCobro, noEntendiCobro;

    // RESPUESTA PREGUNTA 6
    public bool entendiNormativas, noEntendiNormativas;

    // RESPUESTA PREGUNTA 7
    public bool entendiCupones, noEntendiCupones;

    // RESPUESTA PREGUNTA 8
    public bool mejorarCobrar, noTocarCobrar;

    // RESPUESTA PREGUNTA 9
    public TMP_InputField entradaSugerenciaCobro;
    public string sugerenciaCobro;

    // RESPUESTA PREGUNTA 10
    public bool odioVictor, mehVictor, quieromasVictor, fangirlVictor;

    // RESPUESTA PREGUNTA 11
    public bool odioMiguel, mehMiguel, quieromasMiguel, fangirlMiguel;

    // RESPUESTA PREGUNTA 12
    public bool odioHumor, mehHumor, quieromasHumor, fangirlHumor;

    // RESPUESTA PREGUNTA 13
    public bool masLore, noMasLore;

    // RESPUESTA PREGUNTA 14
    public TMP_InputField entradaSugerenciaMerchan;
    public string sugerenciaMerchan;

    // RESPUESTA PREGUNTA 15
    public TMP_InputField entradaSugerenciaFinal;
    public string sugerenciaFinal;

    public GameObject fadeToBlackObject;
    [SerializeField] public AnimationClip fadeToblackClip;
    [SerializeField] public float fadeToblackClipTime;

    private string csvPath;


    private void Awake()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderPath = Path.Combine(desktopPath, "MadridOtakuData");

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        csvPath = Path.Combine(folderPath, "DatosDelFormulario.csv");
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(activateINTRO1), .5f);
        charactersPanelsSelected = new List<GameObject>();
        fadeToblackClipTime = fadeToblackClip.length;
        DialogueManager.Instance.lastSceneWithDialogues = "";
    }

    public void activateINTRO1()
    {
        intro1.SetActive(true);
        intro1.GetComponent<AudioSource>().Play();
    }
    public void activateINTRO2()
    {
        intro1.SetActive(false);
        intro2.SetActive(true);
        intro2.GetComponent<AudioSource>().Play();
    }
    public void activateINTRO3()
    {
        intro2.SetActive(false);
        intro3.SetActive(true);
        intro3.GetComponent<AudioSource>().Play();
    }

    public void activatePREGUNTA1()
    {
        intro3.transform.GetChild(0).GetComponent<Animator>().Play("JacoboToTheRight");
        Invoke(nameof(activatePREGUNTA1conDelay), 2);
    }

    public void activatePREGUNTA1conDelay()
    {
        intro3.SetActive(false);
        pregunta1.SetActive(true);
        pregunta1.GetComponent<AudioSource>().Play();
    }

    public void activatePREGUNTA2(int opcion)
    {
        // Resetea todos los valores primero (opcional)
        demoAburrida = false;
        demoNormal = false;
        demoEntretenida = false;
        demoDivertida = false;

        // Activa solo el booleano correspondiente
        switch (opcion)
        {
            case 0:
                demoAburrida = true;
                break;
            case 1:
                demoNormal = true;
                break;
            case 2:
                demoEntretenida = true;
                break;
            case 3:
                demoDivertida = true;
                break;
        }

        pregunta1.SetActive(false);
        pregunta2.SetActive(true);
        pregunta2.GetComponent<AudioSource>().Play();
    }

    public void seleccionarPersonaje(int opcion)
    {
        // Activa solo el booleano correspondiente
        switch (opcion)
        {
            case 0:
                if (elegidoANTONIO)
                {
                    atLeastOne--;
                    elegidoANTONIO = false;
                    pregunta2.transform.GetChild(3).GetComponent<Image>().color = new Color(255, 255, 255);
                }

                else
                {
                    atLeastOne++;
                    elegidoANTONIO = true;
                    pregunta2.transform.GetChild(3).GetComponent<Image>().color = new Color(0, 255, 0);
                }

                break;

            case 1:
                if (elegidoELVOG)
                {
                    atLeastOne--;
                    elegidoELVOG = false;
                    pregunta2.transform.GetChild(4).GetComponent<Image>().color = new Color(255, 255, 255);
                }

                else
                {
                    atLeastOne++;
                    elegidoELVOG = true;
                    pregunta2.transform.GetChild(4).GetComponent<Image>().color = new Color(0, 255, 0);
                }
                break;

            case 2:
                if (elegidoELIDORA)
                {
                    atLeastOne--;
                    elegidoELIDORA = false;
                    pregunta2.transform.GetChild(5).GetComponent<Image>().color = new Color(255, 255, 255);
                }

                else
                {
                    atLeastOne++;
                    elegidoELIDORA = true;
                    pregunta2.transform.GetChild(5).GetComponent<Image>().color = new Color(0, 255, 0);
                }
                break;

            case 3:
                if (elegidoPIJUSMAGNUS)
                {
                    atLeastOne--;
                    elegidoPIJUSMAGNUS = false;
                    pregunta2.transform.GetChild(6).GetComponent<Image>().color = new Color(255, 255, 255);
                }

                else
                {
                    atLeastOne++;
                    elegidoPIJUSMAGNUS = true;
                    pregunta2.transform.GetChild(6).GetComponent<Image>().color = new Color(0, 255, 0);
                }
                break;

            case 4:
                if (elegidoRAVEN)
                {
                    atLeastOne--;
                    elegidoRAVEN = false;
                    pregunta2.transform.GetChild(7).GetComponent<Image>().color = new Color(255, 255, 255);
                }

                else
                {
                    atLeastOne++;
                    elegidoRAVEN = true;
                    pregunta2.transform.GetChild(7).GetComponent<Image>().color = new Color(0, 255, 0);
                }
                break;

            case 5:
                if (elegidoROCON)
                {
                    atLeastOne--;
                    elegidoROCON = false;
                    pregunta2.transform.GetChild(8).GetComponent<Image>().color = new Color(255, 255, 255);
                }

                else
                {
                    atLeastOne++;
                    elegidoROCON = true;
                    pregunta2.transform.GetChild(8).GetComponent<Image>().color = new Color(0, 255, 0);
                }
                break;

            case 6:
                if (elegidoMINIJEFE)
                {
                    atLeastOne--;
                    elegidoMINIJEFE = false;
                    pregunta2.transform.GetChild(9).GetComponent<Image>().color = new Color(255, 255, 255);
                }

                else
                {
                    atLeastOne++;
                    elegidoMINIJEFE = true;
                    pregunta2.transform.GetChild(9).GetComponent<Image>().color = new Color(0, 255, 0);
                }
                break;

            case 7:
                if (elegidoDETECTIVE)
                {
                    atLeastOne--;
                    elegidoDETECTIVE = false;
                    pregunta2.transform.GetChild(10).GetComponent<Image>().color = new Color(255, 255, 255);
                }

                else
                {
                    atLeastOne++;
                    elegidoDETECTIVE = true;
                    pregunta2.transform.GetChild(10).GetComponent<Image>().color = new Color(0, 255, 0);
                }
                break; ;
        }
    }

    public void activatePREGUNTAS3()
    {
        if (atLeastOne > 0)
        {
            addingPersonajes();
            Invoke(nameof(activatePREGUNTA3conDelay), .5f);
        }            
    }

    public void addingPersonajes()
    {
        if (elegidoANTONIO)
            charactersPanelsSelected.Add(pregunta3_ANTONIO);

        if (elegidoELVOG)
            charactersPanelsSelected.Add(pregunta3_ELVOG);

        if (elegidoELIDORA)
            charactersPanelsSelected.Add(pregunta3_ELIDORA);

        if (elegidoPIJUSMAGNUS)
            charactersPanelsSelected.Add(pregunta3_PIJUSMAGNUS);

        if (elegidoRAVEN)
            charactersPanelsSelected.Add(pregunta3_RAVEN);

        if (elegidoROCON)
            charactersPanelsSelected.Add(pregunta3_ROCON);

        if (elegidoMINIJEFE)
            charactersPanelsSelected.Add(pregunta3_MINIJEFE);

        if (elegidoDETECTIVE)
            charactersPanelsSelected.Add(pregunta3_DETECTIVE);
    }

    void activatePREGUNTA3conDelay()
    {
        pregunta2.SetActive(false);
        charactersPanelsSelected[0].SetActive(true);
        charactersPanelsSelected[0].GetComponent<AudioSource>().Play();
    }

    public void savingDataANTONIO(int opcion)
    {
        // Activa solo el booleano correspondiente
        switch (opcion)
        {
            case 0:
                aspectoVisualANTONIO = true;
                break;
            case 1:
                personalidadGuionANTONIO = true;
                break;
            case 2:
                ambasCosasANTONIO = true;
                break;
        }
        charactersPanelsSelected.Remove(pregunta3_ANTONIO);

        if (charactersPanelsSelected.Count == 0)
        {
            pregunta3_ANTONIO.SetActive(false);
            pregunta4.SetActive(true);
            pregunta4.GetComponent<AudioSource>().Play();
        }

        else
        {
            pregunta3_ANTONIO.SetActive(false);
            charactersPanelsSelected[0].SetActive(true);
            charactersPanelsSelected[0].GetComponent<AudioSource>().Play();
        }
    }

    public void savingDataELVOG(int opcion)
    {
        switch (opcion)
        {
            case 0:
                aspectoVisualELVOG = true;
                break;
            case 1:
                personalidadGuionELVOG = true;
                break;
            case 2:
                ambasCosasELVOG = true;
                break;
        }
        charactersPanelsSelected.Remove(pregunta3_ELVOG);

        if (charactersPanelsSelected.Count == 0)
        {
            pregunta3_ELVOG.SetActive(false);
            pregunta4.SetActive(true);
            pregunta4.GetComponent<AudioSource>().Play();
        }
        else
        {
            pregunta3_ELVOG.SetActive(false);
            charactersPanelsSelected[0].SetActive(true);
            charactersPanelsSelected[0].GetComponent<AudioSource>().Play();
        }
    }

    public void savingDataELIDORA(int opcion)
    {
        switch (opcion)
        {
            case 0:
                aspectoVisualELIDORA = true;
                break;
            case 1:
                personalidadGuionELIDORA = true;
                break;
            case 2:
                ambasCosasELIDORA = true;
                break;
        }
        charactersPanelsSelected.Remove(pregunta3_ELIDORA);

        if (charactersPanelsSelected.Count == 0)
        {
            pregunta3_ELIDORA.SetActive(false);
            pregunta4.SetActive(true);
            pregunta4.GetComponent<AudioSource>().Play();
        }
        else
        {
            pregunta3_ELIDORA.SetActive(false);
            charactersPanelsSelected[0].SetActive(true);
            charactersPanelsSelected[0].GetComponent<AudioSource>().Play();
        }
    }

    public void savingDataPIJUSMAGNUS(int opcion)
    {
        switch (opcion)
        {
            case 0:
                aspectoVisualPIJUSMAGNUS = true;
                break;
            case 1:
                personalidadGuionPIJUSMAGNUS = true;
                break;
            case 2:
                ambasCosasPIJUSMAGNUS = true;
                break;
        }
        charactersPanelsSelected.Remove(pregunta3_PIJUSMAGNUS);

        if (charactersPanelsSelected.Count == 0)
        {
            pregunta3_PIJUSMAGNUS.SetActive(false);
            pregunta4.SetActive(true);
            pregunta4.GetComponent<AudioSource>().Play();
        }
        else
        {
            pregunta3_PIJUSMAGNUS.SetActive(false);
            charactersPanelsSelected[0].SetActive(true);
            charactersPanelsSelected[0].GetComponent<AudioSource>().Play();
        }
    }

    public void savingDataRAVEN(int opcion)
    {
        switch (opcion)
        {
            case 0:
                aspectoVisualRAVEN = true;
                break;
            case 1:
                personalidadGuionRAVEN = true;
                break;
            case 2:
                ambasCosasRAVEN = true;
                break;
        }
        charactersPanelsSelected.Remove(pregunta3_RAVEN);

        if (charactersPanelsSelected.Count == 0)
        {
            pregunta3_RAVEN.SetActive(false);
            pregunta4.SetActive(true);
            pregunta4.GetComponent<AudioSource>().Play();
        }
        else
        {
            pregunta3_RAVEN.SetActive(false);
            charactersPanelsSelected[0].SetActive(true);
            charactersPanelsSelected[0].GetComponent<AudioSource>().Play();
        }
    }

    public void savingDataROCON(int opcion)
    {
        switch (opcion)
        {
            case 0:
                aspectoVisualROCON = true;
                break;
            case 1:
                personalidadGuionROCON = true;
                break;
            case 2:
                ambasCosasROCON = true;
                break;
        }
        charactersPanelsSelected.Remove(pregunta3_ROCON);

        if (charactersPanelsSelected.Count == 0)
        {
            pregunta3_ROCON.SetActive(false);
            pregunta4.SetActive(true);
            pregunta4.GetComponent<AudioSource>().Play();
        }
        else
        {
            pregunta3_ROCON.SetActive(false);
            charactersPanelsSelected[0].SetActive(true);
            charactersPanelsSelected[0].GetComponent<AudioSource>().Play();
        }
    }

    public void savingDataMINIJEFE(int opcion)
    {
        switch (opcion)
        {
            case 0:
                aspectoVisualMINIJEFE = true;
                break;
            case 1:
                personalidadGuionMINIJEFE = true;
                break;
            case 2:
                ambasCosasMINIJEFE = true;
                break;
        }
        charactersPanelsSelected.Remove(pregunta3_MINIJEFE);

        if (charactersPanelsSelected.Count == 0)
        {
            pregunta3_MINIJEFE.SetActive(false);
            pregunta4.SetActive(true);
            pregunta4.GetComponent<AudioSource>().Play();
        }
        else
        {
            pregunta3_MINIJEFE.SetActive(false);
            charactersPanelsSelected[0].SetActive(true);
            charactersPanelsSelected[0].GetComponent<AudioSource>().Play();
        }
    }

    public void savingDataDETECTIVE(int opcion)
    {
        switch (opcion)
        {
            case 0:
                aspectoVisualDETECTIVE = true;
                break;
            case 1:
                personalidadGuionDETECTIVE = true;
                break;
            case 2:
                ambasCosasDETECTIVE = true;
                break;
        }
        charactersPanelsSelected.Remove(pregunta3_DETECTIVE);

        if (charactersPanelsSelected.Count == 0)
        {
            pregunta3_DETECTIVE.SetActive(false);
            pregunta4.SetActive(true);
            pregunta4.GetComponent<AudioSource>().Play();
        }
        else
        {
            pregunta3_DETECTIVE.SetActive(false);
            charactersPanelsSelected[0].SetActive(true);
            charactersPanelsSelected[0].GetComponent<AudioSource>().Play();
        }
    }

    public void activatePREGUNTA5(int opcion)
    {
        switch (opcion)
        {
            case 0:
                yesCosmetics = true;
                break;
            case 1:
                noCosmetics = true;
                break;
        }

        pregunta4.SetActive(false);
        pregunta5.SetActive(true);
        pregunta5.GetComponent<AudioSource>().Play();
    }

    public void activatePREGUNTA6(int opcion)
    {
        switch (opcion)
        {
            case 0:
                entendiCobro = true;
                break;
            case 1:
                noEntendiCobro = true;
                break;
        }

        pregunta5.SetActive(false);
        pregunta6.SetActive(true);
        pregunta6.GetComponent<AudioSource>().Play();
    }

    public void activatePREGUNTA7(int opcion)
    {
        switch (opcion)
        {
            case 0:
                noEntendiNormativas = true;
                break;
            case 1:
                noEntendiNormativas = true;
                break;
        }

        pregunta6.SetActive(false);
        pregunta7.SetActive(true);
        pregunta7.GetComponent<AudioSource>().Play();
    }

    public void activatePREGUNTA8(int opcion)
    {
        switch (opcion)
        {
            case 0:
                entendiCupones = true;
                break;
            case 1:
                noEntendiCupones = true;
                break;
        }

        pregunta7.SetActive(false);
        pregunta8.SetActive(true);
        pregunta8.GetComponent<AudioSource>().Play();
    }

    public void activatePREGUNTA9(int opcion)
    {
        switch (opcion)
        {
            case 0:
                mejorarCobrar = true;
                break;
            case 1:
                noTocarCobrar = true;
                break;
        }

        pregunta8.SetActive(false);
        pregunta9.SetActive(true);
        pregunta9.GetComponent<AudioSource>().Play();
    }

    public void activatePREGUNTA10()
    {
        Debug.Log("Pepote");
        sugerenciaCobro = entradaSugerenciaCobro.text;

        activatePREGUNTA10conDelay();
    }

    public void activatePREGUNTA10conDelay()
    {
        pregunta9.SetActive(false);
        pregunta10.SetActive(true);
        pregunta10.GetComponent<AudioSource>().Play();
    }

    public void activatePREGUNTA11(int opcion)
    {
        switch (opcion)
        {
            case 0:
                odioVictor = true;
                break;
            case 1:
                mehVictor = true;
                break;
            case 2:
                quieromasVictor = true;
                break;
            case 3:
                fangirlVictor = true;
                break;
        }

        pregunta10.SetActive(false);
        pregunta11.SetActive(true);
        pregunta11.GetComponent<AudioSource>().Play();
    }

    public void activatePREGUNTA12(int opcion)
    {
        switch (opcion)
        {
            case 0:
                odioMiguel = true;
                break;
            case 1:
                mehMiguel = true;
                break;
            case 2:
                quieromasMiguel = true;
                break;
            case 3:
                fangirlMiguel = true;
                break;
        }

        pregunta11.SetActive(false);
        pregunta12.SetActive(true);
        pregunta12.GetComponent<AudioSource>().Play();
    }

    public void activatePREGUNTA13(int opcion)
    {
        switch (opcion)
        {
            case 0:
                odioHumor = true;
                break;
            case 1:
                mehHumor = true;
                break;
            case 2:
                quieromasHumor = true;
                break;
            case 3:
                fangirlHumor = true;
                break;
        }

        pregunta12.SetActive(false);
        pregunta13.SetActive(true);
        pregunta13.GetComponent<AudioSource>().Play();
    }

    public void activatePREGUNTA14(int opcion)
    {
        switch (opcion)
        {
            case 0:
                masLore = true;
                break;
            case 1:
                noMasLore = true;
                break;
        }

        pregunta13.SetActive(false);
        pregunta14.SetActive(true);
        pregunta14.GetComponent<AudioSource>().Play();
    }

    public void activatePREGUNTA15()
    {
        sugerenciaMerchan = entradaSugerenciaMerchan.text;

        pregunta14.SetActive(false);
        pregunta15.SetActive(true);
        pregunta15.GetComponent<AudioSource>().Play();
    }

    public void activateOutro()
    {
        sugerenciaFinal = entradaSugerenciaFinal.text;

        pregunta15.SetActive(false);
        outro.SetActive(true);
        outro.GetComponent<AudioSource>().Play();
        outro.transform.GetChild(0).GetComponent<Animator>().Play("JacoboToTheLeft");

        string lineaCSV = GenerarLineaCSV();
        File.AppendAllText(csvPath, lineaCSV + "\n");
        Debug.Log($"[CSV LOG] Datos guardados en: {csvPath}");
    }

    public void GoToTheEnd()
    {
        DialogueManager.Instance.propinasNumber = 50;
        fadeToBlackObject.GetComponent<Animator>().SetBool("ToBlack", true);
        Invoke(nameof(ToTheCredits), fadeToblackClipTime);
    }

    public void ToTheCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    private bool GetBool(string fieldName)
    {
        var field = this.GetType().GetField(fieldName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
        if (field != null && field.FieldType == typeof(bool))
            return (bool)field.GetValue(this);
        return false;
    }


    public string GenerarLineaCSV()
    {
        List<string> csv = new List<string>();

        csv.Add(DialogueManager.Instance.propinasNumber + " monedas");
        csv.Add(DialogueManager.Instance.puntosElidora + " puntos");

        // PREGUNTA 1
        if (demoAburrida) csv.Add("demoAburrida");
        if (demoNormal) csv.Add("demoNormal");
        if (demoEntretenida) csv.Add("demoEntretenida");
        if (demoDivertida) csv.Add("demoDivertida");

        // La pregunta 2 no es necesaria porque la tres hace alusión al personaje seleccionado
        string[] nombres = { "ANTONIO", "ELVOG", "ELIDORA", "PIJUSMAGNUS", "RAVEN", "ROCON", "MINIJEFE", "DETECTIVE" };
        foreach (string nombre in nombres)
        {
            if (GetBool($"aspectoVisual{nombre}")) csv.Add($"aspectoVisual{nombre}");
            if (GetBool($"personalidadGuion{nombre}")) csv.Add($"personalidadGuion{nombre}");
            if (GetBool($"ambasCosas{nombre}")) csv.Add($"ambasCosas{nombre}");
        }

        // PREGUNTA 4
        if (yesCosmetics) csv.Add("yesCosmetics");
        if (noCosmetics) csv.Add("noCosmetics");

        // PREGUNTA 5
        if (entendiCobro) csv.Add("entendiCobro");
        if (noEntendiCobro) csv.Add("noEntendiCobro");

        // PREGUNTA 6
        if (entendiNormativas) csv.Add("entendiNormativas");
        if (noEntendiNormativas) csv.Add("noEntendiNormativas");

        // PREGUNTA 7
        if (entendiCupones) csv.Add("entendiCupones");
        if (noEntendiCupones) csv.Add("noEntendiCupones");

        // PREGUNTA 8
        if (mejorarCobrar) csv.Add("mejorarCobrar");
        if (noTocarCobrar) csv.Add("noTocarCobrar");

        // PREGUNTA 9
        csv.Add(sugerenciaCobro);

        // PREGUNTA 10
        if (odioVictor) csv.Add("odioVictor");
        if (mehVictor) csv.Add("mehVictor");
        if (quieromasVictor) csv.Add("quieromasVictor");
        if (fangirlVictor) csv.Add("fangirlVictor");

        // PREGUNTA 11
        if (odioMiguel) csv.Add("odioMiguel");
        if (mehMiguel) csv.Add("mehMiguel");
        if (quieromasMiguel) csv.Add("quieromasMiguel");
        if (fangirlMiguel) csv.Add("fangirlMiguel");

        // PREGUNTA 12
        if (odioHumor) csv.Add("odioHumor");
        if (mehHumor) csv.Add("mehHumor");
        if (quieromasHumor) csv.Add("quieromasHumor");
        if (fangirlHumor) csv.Add("fangirlHumor");

        // PREGUNTA 13
        if (masLore) csv.Add("masLore");
        if (noMasLore) csv.Add("noMasLore");

        // PREGUNTA 14
        csv.Add(sugerenciaMerchan);

        // PREGUNTA 15
        csv.Add(sugerenciaFinal);

        return string.Join(",", csv);
    }

}
