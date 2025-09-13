using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    [SerializeField] public GameObject data;
    [SerializeField] public AnimationClip fadeToblackClip;
    [SerializeField] public float fadeToblackClipTime;
    [SerializeField] public Scene currentScene;
    public AudioSource audioSource;
    [SerializeField] public AudioClip bonesSound;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data");
        fadeToblackClipTime = fadeToblackClip.length;
        currentScene = SceneManager.GetActiveScene();
    }

    // TRANSICIÓN A NEGRO DEL MENÚ AL PRIMER DÍA
    public void FirstFadeToBlack()
    {
        GetComponent<Animator>().SetBool("ToBlack", true);

        //if (currentScene.name != "Home" || currentScene.name == "MenuInicial")
            Invoke(nameof(GoingToTheGame), fadeToblackClipTime);
    }

    public string GetCheckedDayNumber()
    {
        for (int i = 0; i <= 7; i++) // De momento solo hasta el día 7. En caso que se crearan más días habría que cambiar el número.
        {
            string fieldName = $"day{i:D2}Checked"; // Cojamos como ejemplo el "day04Checked"
            
            var field = typeof(Data).GetField(fieldName, BindingFlags.Instance | BindingFlags.Public);

            if (field != null && field.FieldType == typeof(bool))
            {
                bool value = (bool)field.GetValue(Data.instance);
                
                if (value)
                {
                    if (i < 7)
                    {
                        i++;
                        return i.ToString("D2"); // Si "day04Checked" es true, me devolvería "04".
                    }
                    
                    else
                        ResetData();
                }                   
            }
        }

        Data.instance.day00Checked = true;
        return "01";
    }

    public void GoingToTheGame()
    {
        if(currentScene.name != "MenuDemo")
        {
            DialogueManager.Instance.currentDay = GetCheckedDayNumber();

            if (Data.instance.initialCinematicDone)
                SceneManager.LoadScene("Day");
            else
                SceneManager.LoadScene("InitialCinematic");
        }

        else
        {
            SceneManager.LoadScene("S1");
        }
    }

    public void ResetData()
    {
        Data.instance.samuraiPagaMal = false;
        Data.instance.borrachoTriste = false;
        Data.instance.samuraiAyudado1 = false;
        Data.instance.samuraiAyudado2 = false;
        Data.instance.vecesSamuraiAyudado = 0;
        Data.instance.videoActivo = false;
        Data.instance.videoVisto = false;
        Data.instance.tipsPoints = 0;
        Data.instance.detectivePoints = 0;

        Data.instance.day00Checked = false;
        Data.instance.day01Checked = false;
        Data.instance.day02Checked = false;
        Data.instance.day03Checked = false;
        Data.instance.day04Checked = false;
        Data.instance.day05Checked = false;
        Data.instance.day06Checked = false;
        Data.instance.day07Checked = false;

        Data.instance.sePueTocar = false;
        Data.instance.yaSeFueCliente = false;
        Data.instance.tipsBetweenDays = 0;

        Data.instance.vecesCobradoCululu = 0;                 // Si le cobras 3 veces bien (día 1, 4 y 5), te llevas la foto de la cangumantis en pose sugerente
        Data.instance.vecesCobradoGiovanni = 0;               // Si le cobras 2 veces bien (día 1 y 2), te llevas un libro que es la bomba.
        Data.instance.vecesCobradaMara = 0;                   // Si le cobras 2 veces bien (día 1 y 2), te llevas una pata de la suerte.
        Data.instance.vecesCobradaTerry = 0;                   // Si le cobras 2 veces bien (día 2 y 4), eres un puto payaso.
        Data.instance.noCobrarSergioCobrarGeeraardD4 = 0;                   // No tienes que cobrar a Sergio en el día 4 y tienes que cobrar a Geerald en el día 4
        Data.instance.vecesCobradoAntonio = 0;                   // Tienes que cobrar a Antonio en el dia 4 y a Paxi en el dia 3
        Data.instance.vecesCobradoRaven = 0;
        Data.instance.numGnomosFinded = 0;
        Data.instance.nerviosusPagaLoQueDebe = false;        // Si le cobras (día 4) te da la globoespada.
        Data.instance.nerviosusTeDebePasta = false;          // Si no le cobras Gerardo el magias te dará su bella foto.
        Data.instance.slimeFostiados = false;                // Si le has dado hasta en el carnet de identidad a los slimes.
        Data.instance.slimeFail = false;                     // Si no llegaste a 50 puntos en el minijuego de Elidora.
        Data.instance.elidoraAcariciada = false;             // Si le metiste tremendo cebollazo al pedrolo de Elidora.
    }

    // TRANSICIÓN A NEGRO DE LA TIENDA A CASA / DE DENJIRENJI A TIENDA / DE ELIDORA A CASA
    public void FadeToBlackAnywhere()
    {
        GetComponent<Animator>().SetBool("ToBlack", true);

        if (currentScene.name.Contains("Denjirenji") && !Data.instance.doYouComeFromMinigameSelectorMenu)
        {
            GetComponent<Image>().enabled = true;   // Debido a que se desactiva al entrar al minijuego, ya que no quiero fade al entrar
            Invoke(nameof(BackToTheShop), fadeToblackClipTime);
        }

        else if (currentScene.name.Contains("Denjirenji") && Data.instance.doYouComeFromMinigameSelectorMenu)
        {
            Data.instance.doYouComeFromMinigameSelectorMenu = false;
            Invoke(nameof(CallingMenu), fadeToblackClipTime);
        }

        else if (currentScene.name.Contains("Elidora") && !Data.instance.doYouComeFromMinigameSelectorMenu)
        {
            GetComponent<Image>().enabled = true;   // Debido a que se desactiva al entrar al minijuego, ya que no quiero fade al entrar
            Invoke(nameof(BackToTheShop), fadeToblackClipTime);
        }

        else if (currentScene.name.Contains("Elidora") && Data.instance.doYouComeFromMinigameSelectorMenu)
        {
            Data.instance.doYouComeFromMinigameSelectorMenu = false;
            Invoke(nameof(CallingMenu), fadeToblackClipTime);
        }

        else
            Invoke(nameof(CallingNextday), fadeToblackClipTime);
    }

    public void CallingNextday()
    {
        data.GetComponent<Data>().uIManager.GetComponent<UIManager>().NextDay();
    }

    // TRANSICIÓN A NEGRO DE LOS FINALES A MENÚ INICIAL
    public void LastFadeToBlack()
    {
        GetComponent<Animator>().SetBool("ToBlack", true);
        Invoke(nameof(CallingMenu), fadeToblackClipTime);
    }
    public void CallingMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    // ENTRADA CLIENTE A CASA
    public void ClientEntrance()
    {
        if (currentScene.name == "Home")
            data.GetComponent<Data>().homeManager.SomeoneIsKnocking();
    }

    public void PlayBones()
    {
        audioSource.PlayOneShot(bonesSound);
    }

    public void BackToTheShop()
    {
        SceneManager.LoadScene("Day");
    }

    public void VolverDeGolpearSlimes()
    {
        SceneManager.LoadScene("Day");
    }

    public void VolverDeGolpearSlimesDemo()
    {
        SceneManager.LoadScene("DD");
    }
}
