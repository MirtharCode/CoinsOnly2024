using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DemoFormsManager : MonoBehaviour
{
    public static DemoFormsManager DFInstance { get; private set; }

    public string allClientChoices;
    public GameObject finalButton;

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
    public string sugerenciaCobro = "";

    // RESPUESTA PREGUNTA 10
    public bool odioVictor, mehVictor, quieromasVictor, fangirlVictor;

    // RESPUESTA PREGUNTA 11
    public bool odioMiguel, mehMiguel, quieromasMiguel, fangirlMiguel;

    // RESPUESTA PREGUNTA 12
    public bool odioHumor, mehHumor, quieromasHumor, fangirlHumor;

    // RESPUESTA PREGUNTA 13
    public bool masLore, noMasLore;

    // RESPUESTA PREGUNTA 14
    public string sugerenciaMerchan="";

    // RESPUESTA PREGUNTA 15
    public string sugerenciaFinal = "";

    private void Awake()
    {
        if (DFInstance == null)
        {
            DFInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Rellenar Formulario GoogleForms

    public void EnviarRespuestas()
    {
        StartCoroutine(EnviarFormulario());
    }

    IEnumerator EnviarFormulario()
    {
        Debug.Log("Entro en EnviarFormulario");
        WWWForm form = new WWWForm();

        string url = "https://docs.google.com/forms/d/e/1FAIpQLSfiQHDFc3szwLrw9dfEr1NtFP7S0dkmjdQGGd9-h7jTfhAgmQ/formResponse";

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
        else if (demoNormal) form.AddField("entry.1094213056", "demoNormal");
        else if (demoEntretenida) form.AddField("entry.1094213056", "demoEntretenida");
        else if (demoDivertida) form.AddField("entry.1094213056", "demoDivertida");

        // Pregunta 2 ¿Qué personaje te ha llamado más la atención?
        if (elegidoANTONIO) form.AddField("entry.1438596813", "Antonio");
        if (elegidoELVOG) form.AddField("entry.1438596813", "Elvog");
        if (elegidoELIDORA) form.AddField("entry.1438596813", "Elidora");
        if (elegidoPIJUSMAGNUS) form.AddField("entry.1438596813", "PijusMagnus");
        if (elegidoRAVEN) form.AddField("entry.1438596813", "Rave-N");
        if (elegidoROCON) form.AddField("entry.1438596813", "Rocón");
        if (elegidoMINIJEFE) form.AddField("entry.1438596813", "Minijefe");
        if (elegidoDETECTIVE) form.AddField("entry.1438596813", "Detective");

        // Pregunta ¿Por qué te ha llamado la atención Antonio?
        if (aspectoVisualANTONIO) form.AddField("entry.1952071816", "Aspecto Visual");
        else if (personalidadGuionANTONIO) form.AddField("entry.1952071816", "Personalidad - Guion");
        else if (ambasCosasANTONIO) form.AddField("entry.1952071816", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Elvog?
        if (aspectoVisualELVOG) form.AddField("entry.1389972901", "Aspecto Visual");
        else if (personalidadGuionELVOG) form.AddField("entry.1389972901", "Personalidad - Guion");
        else if (ambasCosasELVOG) form.AddField("entry.1389972901", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Elidora?
        if (aspectoVisualELIDORA) form.AddField("entry.1710944572", "Aspecto Visual");
        else if (personalidadGuionELIDORA) form.AddField("entry.1710944572", "Personalidad - Guion");
        else if (ambasCosasELIDORA) form.AddField("entry.1710944572", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Pijus Magnus?
        if (aspectoVisualPIJUSMAGNUS) form.AddField("entry.651419588", "Aspecto Visual");
        else if (personalidadGuionPIJUSMAGNUS) form.AddField("entry.651419588", "Personalidad - Guion");
        else if (ambasCosasPIJUSMAGNUS) form.AddField("entry.651419588", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Rave-N?
        if (aspectoVisualRAVEN) form.AddField("entry.1827119049", "Aspecto Visual");
        else if (personalidadGuionRAVEN) form.AddField("entry.1827119049", "Personalidad - Guion");
        else if (ambasCosasRAVEN) form.AddField("entry.1827119049", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Rocón?
        if (aspectoVisualROCON) form.AddField("entry.1007585413", "Aspecto Visual");
        else if (personalidadGuionROCON) form.AddField("entry.1007585413", "Personalidad - Guion");
        else if (ambasCosasROCON) form.AddField("entry.1007585413", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Minijefe?
        if (aspectoVisualMINIJEFE) form.AddField("entry.790698444", "Aspecto Visual");
        else if (personalidadGuionMINIJEFE) form.AddField("entry.790698444", "Personalidad - Guion");
        else if (ambasCosasMINIJEFE) form.AddField("entry.790698444", "Ambas cosas");

        // Pregunta ¿Por qué te ha llamado la atención Detective?
        if (aspectoVisualDETECTIVE) form.AddField("entry.2045557217", "Aspecto Visual");
        else if (personalidadGuionDETECTIVE) form.AddField("entry.2045557217", "Personalidad - Guion");
        else if (ambasCosasDETECTIVE) form.AddField("entry.2045557217", "Ambas cosas");

        // PREGUNTA 4 ¿Te gustaría que en la versión final hubiera cosméticos desbloqueables con las propinas?
        if (yesCosmetics) form.AddField("entry.377249181", "yesCosmetics");
        else if (noCosmetics) form.AddField("entry.377249181", "noCosmetics");

        // PREGUNTA 5 ¿Entendiste el sistema de Cobrar al cliente/ Echar al cliente?
        if (entendiCobro) form.AddField("entry.395873814", "entendiCobro");
        else if (noEntendiCobro) form.AddField("entry.395873814", "noEntendiCobro");

        // PREGUNTA 6 ¿Entendiste el sistema de Normativas?
        if (entendiNormativas) form.AddField("entry.543872395", "entendiNormativas");
        else if (noEntendiNormativas) form.AddField("entry.543872395", "noEntendiNormativas");

        // PREGUNTA 7 ¿Entendiste el sistema de Cupones?
        if (entendiCupones) form.AddField("entry.376522869", "entendiCupones");
        else if (noEntendiCupones) form.AddField("entry.376522869", "noEntendiCupones");

        // PREGUNTA 8 ¿Qué opinas de sumar los precios de productos?
        if (mejorarCobrar) form.AddField("entry.1665910031", "mejorarCobrar");
        else if (noTocarCobrar) form.AddField("entry.1665910031", "noTocarCobrar");

        // PREGUNTA 9 ¿Tienes alguna sugerencia respecto a todo lo referente a atender a los clientes? (Normativas, Cupones, Suma de productos, cobro)
        form.AddField("entry.1417983291", sugerenciaCobro);

        // Pregunta 10 ¿Cuánto te ha gustado el estilo artístico del juego?
        if (odioVictor) form.AddField("entry.560026815", "odioVictor");
        else if (mehVictor) form.AddField("entry.560026815", "mehVictor");
        else if (quieromasVictor) form.AddField("entry.560026815", "quieromasVictor");
        else if (fangirlVictor) form.AddField("entry.560026815", "fangirlVictor");

        // Pregunta 11 ¿Cuánto te ha gustado la música del juego?
        if (odioMiguel) form.AddField("entry.282767731", "odioMiguel");
        else if (mehMiguel) form.AddField("entry.282767731", "mehMiguel");
        else if (quieromasMiguel) form.AddField("entry.282767731", "quieromasMiguel");
        else if (fangirlMiguel) form.AddField("entry.282767731", "fangirlMiguel");

        // Pregunta 12 ¿Cuánto te ha gustado el humor del juego?
        if (odioHumor) form.AddField("entry.777237563", "odioHumor");
        else if (mehHumor) form.AddField("entry.777237563", "mehHumor");
        else if (quieromasHumor) form.AddField("entry.777237563", "quieromasHumor");
        else if (fangirlHumor) form.AddField("entry.777237563", "fangirlHumor");

        // PREGUNTA 13 ¿Te interesaría saber más del lore del mundo/personajes/tienda?
        if (masLore) form.AddField("entry.1964521268", "masLore");
        else if (noMasLore) form.AddField("entry.1964521268", "noMasLore");

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
