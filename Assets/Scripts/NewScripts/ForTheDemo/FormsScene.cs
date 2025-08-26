using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
// using UnityEditor.Localization.Plugins.CSV;  ESTO DESCOMENTARLO PARA OBTENER DATA EN LOCAL
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class FormsScene : MonoBehaviour
{
    public string allClientChoices;
    public GameObject finalButton;

    public GameObject intro1, intro2, intro3;
    public GameObject pregunta1;
    public GameObject pregunta2;
    public GameObject pregunta3_GIOVANNI, pregunta3_GEERAARD, pregunta3_PETRA, pregunta3_PIJUSMAGNUS, pregunta3_RAVEN, pregunta3_ROCON, pregunta3_MINIJEFE, pregunta3_DETECTIVE;
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
    public bool elegidoGIOVANNI, elegidoGEERAARD, elegidoPETRA, elegidoPIJUSMAGNUS, elegidoRAVEN, elegidoROCON, elegidoMINIJEFE, elegidoDETECTIVE;

    // RESPUESTA PREGUNTA 3
    public bool aspectoVisualGIOVANNI, personalidadGuionGIOVANNI, ambasCosasGIOVANNI;
    public bool aspectoVisualGEERAARD, personalidadGuionGEERAARD, ambasCosasGEERAARD;
    public bool aspectoVisualPETRA, personalidadGuionPETRA, ambasCosasPETRA;
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

    // ESTA PARTE ES SOLO PARA TENER LA DATA LOCAL
    //private void Awake()
    //{
    //    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    //    string folderPath = Path.Combine(desktopPath, "MadridOtakuData");

    //    if (!Directory.Exists(folderPath))
    //        Directory.CreateDirectory(folderPath);

    //    csvPath = Path.Combine(folderPath, "DatosDelFormulario.csv");
    //}
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
                if (elegidoGIOVANNI)
                {
                    atLeastOne--;
                    elegidoGIOVANNI = false;
                    pregunta2.transform.GetChild(3).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton1");
                }

                else
                {
                    atLeastOne++;
                    elegidoGIOVANNI = true;
                    pregunta2.transform.GetChild(3).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton1selected");
                }

                break;

            case 1:
                if (elegidoGEERAARD)
                {
                    atLeastOne--;
                    elegidoGEERAARD = false;
                    pregunta2.transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton1");
                }

                else
                {
                    atLeastOne++;
                    elegidoGEERAARD = true;
                    pregunta2.transform.GetChild(4).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton1selected");
                }
                break;

            case 2:
                if (elegidoPETRA)
                {
                    atLeastOne--;
                    elegidoPETRA = false;
                    pregunta2.transform.GetChild(5).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton2");
                }

                else
                {
                    atLeastOne++;
                    elegidoPETRA = true;
                    pregunta2.transform.GetChild(5).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton2selected");
                }
                break;

            case 3:
                if (elegidoPIJUSMAGNUS)
                {
                    atLeastOne--;
                    elegidoPIJUSMAGNUS = false;
                    pregunta2.transform.GetChild(6).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton3");
                }

                else
                {
                    atLeastOne++;
                    elegidoPIJUSMAGNUS = true;
                    pregunta2.transform.GetChild(6).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton2selected");
                }
                break;

            case 4:
                if (elegidoRAVEN)
                {
                    atLeastOne--;
                    elegidoRAVEN = false;
                    pregunta2.transform.GetChild(7).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton4");
                }

                else
                {
                    atLeastOne++;
                    elegidoRAVEN = true;
                    pregunta2.transform.GetChild(7).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton4selected");
                }
                break;

            case 5:
                if (elegidoROCON)
                {
                    atLeastOne--;
                    elegidoROCON = false;
                    pregunta2.transform.GetChild(8).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton2");
                }

                else
                {
                    atLeastOne++;
                    elegidoROCON = true;
                    pregunta2.transform.GetChild(8).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton2selected");
                }
                break;

            case 6:
                if (elegidoMINIJEFE)
                {
                    atLeastOne--;
                    elegidoMINIJEFE = false;
                    pregunta2.transform.GetChild(9).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton3");
                }

                else
                {
                    atLeastOne++;
                    elegidoMINIJEFE = true;
                    pregunta2.transform.GetChild(9).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton2selected");
                }
                break;

            case 7:
                if (elegidoDETECTIVE)
                {
                    atLeastOne--;
                    elegidoDETECTIVE = false;
                    pregunta2.transform.GetChild(10).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton1");
                }

                else
                {
                    atLeastOne++;
                    elegidoDETECTIVE = true;
                    pregunta2.transform.GetChild(10).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/UI/Buttons/boton1selected");
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
        if (elegidoGIOVANNI)
            charactersPanelsSelected.Add(pregunta3_GIOVANNI);

        if (elegidoGEERAARD)
            charactersPanelsSelected.Add(pregunta3_GEERAARD);

        if (elegidoPETRA)
            charactersPanelsSelected.Add(pregunta3_PETRA);

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
                aspectoVisualGIOVANNI = true;
                break;
            case 1:
                personalidadGuionGIOVANNI = true;
                break;
            case 2:
                ambasCosasGIOVANNI = true;
                break;
        }
        charactersPanelsSelected.Remove(pregunta3_GIOVANNI);

        if (charactersPanelsSelected.Count == 0)
        {
            pregunta3_GIOVANNI.SetActive(false);
            pregunta4.SetActive(true);
            pregunta4.GetComponent<AudioSource>().Play();
        }

        else
        {
            pregunta3_GIOVANNI.SetActive(false);
            charactersPanelsSelected[0].SetActive(true);
            charactersPanelsSelected[0].GetComponent<AudioSource>().Play();
        }
    }

    public void savingDataELVOG(int opcion)
    {
        switch (opcion)
        {
            case 0:
                aspectoVisualGEERAARD = true;
                break;
            case 1:
                personalidadGuionGEERAARD = true;
                break;
            case 2:
                ambasCosasGEERAARD = true;
                break;
        }
        charactersPanelsSelected.Remove(pregunta3_GEERAARD);

        if (charactersPanelsSelected.Count == 0)
        {
            pregunta3_GEERAARD.SetActive(false);
            pregunta4.SetActive(true);
            pregunta4.GetComponent<AudioSource>().Play();
        }
        else
        {
            pregunta3_GEERAARD.SetActive(false);
            charactersPanelsSelected[0].SetActive(true);
            charactersPanelsSelected[0].GetComponent<AudioSource>().Play();
        }
    }

    public void savingDataELIDORA(int opcion)
    {
        switch (opcion)
        {
            case 0:
                aspectoVisualPETRA = true;
                break;
            case 1:
                personalidadGuionPETRA = true;
                break;
            case 2:
                ambasCosasPETRA = true;
                break;
        }
        charactersPanelsSelected.Remove(pregunta3_PETRA);

        if (charactersPanelsSelected.Count == 0)
        {
            pregunta3_PETRA.SetActive(false);
            pregunta4.SetActive(true);
            pregunta4.GetComponent<AudioSource>().Play();
        }
        else
        {
            pregunta3_PETRA.SetActive(false);
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
                entendiNormativas = true;
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

        //string lineaCSV = GenerarLineaCSV(); 
        //File.AppendAllText(csvPath, lineaCSV + "\n");
        //Debug.Log($"[CSV LOG] Datos guardados en: {csvPath}");

        EnviarRespuestas();
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

    #region CSV Local
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

    #endregion

    #region Rellenar Formulario GoogleForms

    public void EnviarRespuestas()
    {
        StartCoroutine(EnviarFormulario());
    }

    IEnumerator EnviarFormulario()
    {
        Debug.Log("Entro en EnviarFormulario");
        string url = "https://docs.google.com/forms/d/e/1FAIpQLSfiQHDFc3szwLrw9dfEr1NtFP7S0dkmjdQGGd9-h7jTfhAgmQ/formResponse";
        WWWForm form = new WWWForm();

        for (int i = 0; i < DialogueManager.Instance.chosenChecks.Count; i++) 
        {
            allClientChoices += " " + DialogueManager.Instance.chosenChecks[i];
        }

        form.AddField("entry.1723272062", allClientChoices);

        // ¿Cuántas monedas obtuvieron?
        form.AddField("entry.1683268102", DialogueManager.Instance.propinasNumber + " monedas.");

        //¿Cuántos puntos obtuvieron?
        form.AddField("entry.1736884450", DialogueManager.Instance.puntosElidora + " puntos.");


        // Pregunta 1 ¿QUÉ TE HA PARECIDO LA DEMO?
        if (demoAburrida) form.AddField("entry.1094213056", "demoAburrida");
        if (demoNormal) form.AddField("entry.1094213056", "demoNormal");
        if (demoEntretenida) form.AddField("entry.1094213056", "demoEntretenida");
        if (demoDivertida) form.AddField("entry.1094213056", "demoDivertida");

        // Pregunta 2 ¿Qué personaje te ha llamado más la atención?
        if (elegidoGIOVANNI) form.AddField("entry.1438596813", "Antonio");
        if (elegidoGEERAARD) form.AddField("entry.1438596813", "Elvog");
        if (elegidoPETRA) form.AddField("entry.1438596813", "Elidora");
        if (elegidoPIJUSMAGNUS) form.AddField("entry.1438596813", "PijusMagnus");
        if (elegidoRAVEN) form.AddField("entry.1438596813", "Rave-N");
        if (elegidoROCON) form.AddField("entry.1438596813", "Rocón");
        if (elegidoMINIJEFE) form.AddField("entry.1438596813", "Minijefe");
        if (elegidoDETECTIVE) form.AddField("entry.1438596813", "Detective");

        // Pregunta ¿Por qué te ha llamado la atención Antonio?
        if(aspectoVisualGIOVANNI) form.AddField("entry.1952071816", "Aspecto Visual");
        if(personalidadGuionGIOVANNI) form.AddField("entry.1952071816", "Personalidad - Guion");
        if(ambasCosasGIOVANNI) form.AddField("entry.1952071816", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Elvog?
        if (aspectoVisualGEERAARD) form.AddField("entry.1389972901", "Aspecto Visual");
        if (personalidadGuionGEERAARD) form.AddField("entry.1389972901", "Personalidad - Guion");
        if (ambasCosasGEERAARD) form.AddField("entry.1389972901", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Elidora?
        if (aspectoVisualPETRA) form.AddField("entry.1710944572", "Aspecto Visual");
        if (personalidadGuionPETRA) form.AddField("entry.1710944572", "Personalidad - Guion");
        if (ambasCosasPETRA) form.AddField("entry.1710944572", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Pijus Magnus?
        if (aspectoVisualPIJUSMAGNUS) form.AddField("entry.651419588", "Aspecto Visual");
        if (personalidadGuionPIJUSMAGNUS) form.AddField("entry.651419588", "Personalidad - Guion");
        if (ambasCosasPIJUSMAGNUS) form.AddField("entry.651419588", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Rave-N?
        if (aspectoVisualRAVEN) form.AddField("entry.1827119049", "Aspecto Visual");
        if (personalidadGuionRAVEN) form.AddField("entry.1827119049", "Personalidad - Guion");
        if (ambasCosasRAVEN) form.AddField("entry.1827119049", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Rocón?
        if (aspectoVisualROCON) form.AddField("entry.1007585413", "Aspecto Visual");
        if (personalidadGuionROCON) form.AddField("entry.1007585413", "Personalidad - Guion");
        if (ambasCosasROCON) form.AddField("entry.1007585413", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Minijefe?
        if (aspectoVisualMINIJEFE) form.AddField("entry.790698444", "Aspecto Visual");
        if (personalidadGuionMINIJEFE) form.AddField("entry.790698444", "Personalidad - Guion");
        if (ambasCosasMINIJEFE) form.AddField("entry.790698444", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Detective?
        if (aspectoVisualDETECTIVE) form.AddField("entry.2045557217", "Aspecto Visual");
        if (personalidadGuionDETECTIVE) form.AddField("entry.2045557217", "Personalidad - Guion");
        if (ambasCosasDETECTIVE) form.AddField("entry.2045557217", "Ambas cosas");

        // PREGUNTA 4 ¿Te gustaría que en la versión final hubiera cosméticos desbloqueables con las propinas?
        if (yesCosmetics) form.AddField("entry.377249181", "yesCosmetics");
        if (noCosmetics) form.AddField("entry.377249181", "noCosmetics");

        // PREGUNTA 5 ¿Entendiste el sistema de Cobrar al cliente/ Echar al cliente?
        if (entendiCobro) form.AddField("entry.395873814", "entendiCobro");
        if (noEntendiCobro) form.AddField("entry.395873814", "noEntendiCobro");

        // PREGUNTA 6 ¿Entendiste el sistema de Normativas?
        if (entendiNormativas) form.AddField("entry.543872395", "entendiNormativas");
        if (noEntendiNormativas) form.AddField("entry.543872395", "noEntendiNormativas");

        // PREGUNTA 7 ¿Entendiste el sistema de Cupones?
        if (entendiCupones) form.AddField("entry.376522869", "entendiCupones");
        if (noEntendiCupones) form.AddField("entry.376522869", "noEntendiCupones");

        // PREGUNTA 8 ¿Qué opinas de sumar los precios de productos?
        if (mejorarCobrar) form.AddField("entry.1665910031", "mejorarCobrar");
        if (noTocarCobrar) form.AddField("entry.1665910031", "noMejorarCobrar");

        // PREGUNTA 9 ¿Tienes alguna sugerencia respecto a todo lo referente a atender a los clientes? (Normativas, Cupones, Suma de productos, cobro)
        form.AddField("entry.1417983291", sugerenciaCobro);

        // Pregunta 10 ¿Cuánto te ha gustado el estilo artístico del juego?
        if (odioVictor) form.AddField("entry.560026815", "odioVictor");
        if (mehVictor) form.AddField("entry.560026815", "mehVictor");
        if (quieromasVictor) form.AddField("entry.560026815", "quieromasVictor");
        if (fangirlVictor) form.AddField("entry.560026815", "fangirlVictor");

        // Pregunta 11 ¿Cuánto te ha gustado la música del juego?
        if (odioMiguel) form.AddField("entry.282767731", "odioMiguel");
        if (mehMiguel) form.AddField("entry.282767731", "mehMiguel");
        if (quieromasMiguel) form.AddField("entry.282767731", "quieromasMiguel");
        if (fangirlMiguel) form.AddField("entry.282767731", "fangirlMiguel");

        // Pregunta 12 ¿Cuánto te ha gustado el humor del juego?
        if (odioHumor) form.AddField("entry.777237563", "odioHumor");
        if (mehHumor) form.AddField("entry.777237563", "mehHumor");
        if (quieromasHumor) form.AddField("entry.777237563", "quieromasHumor");
        if (fangirlHumor) form.AddField("entry.777237563", "fangirlHumor");

        // PREGUNTA 13 ¿Te interesaría saber más del lore del mundo/personajes/tienda?
        if (masLore) form.AddField("entry.1964521268", "masLore");
        if (noMasLore) form.AddField("entry.1964521268", "noMasLore");

        // PREGUNTA 14 ¿Querrías merch de algún tipo de los personajes? Si es así escribe qué te gustaría
        form.AddField("entry.1385663545", sugerenciaMerchan);

        // PREGUNTA 15 ¿Alguna última sugerencia que tengas?
        form.AddField("entry.1537365799", sugerenciaFinal);

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error al enviar: " + www.error);
        }
        else
        {
            Debug.Log("¡Formulario enviado!");
            finalButton.GetComponent<Button>().enabled = true;

        }
    }

    #endregion

}
