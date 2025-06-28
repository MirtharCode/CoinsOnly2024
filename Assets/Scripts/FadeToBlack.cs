using System.Collections;
using System.Collections.Generic;
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

        if (currentScene.name == "MenuInicial")
            GetComponent<Animator>().SetTrigger("PumPum");
    }

    // TRANSICIÓN A NEGRO DEL MENÚ AL PRIMER DÍA
    public void FirstFadeToBlack()
    {
        GetComponent<Animator>().SetBool("ToBlack", true);

        //if (currentScene.name != "Home" || currentScene.name == "MenuInicial")
            Invoke(nameof(CallingFirstDay), fadeToblackClipTime);
    }

    public void CallingFirstDay()
    {
        if(data.GetComponent<Data>().day0Check)
            SceneManager.LoadScene("Day1");

        else if(data.GetComponent<Data>().day1Check)
            SceneManager.LoadScene("Day2_1");

        else if (data.GetComponent<Data>().day2Check)
            SceneManager.LoadScene("Day3_1");

        else if (data.GetComponent<Data>().day3Check)
            SceneManager.LoadScene("Day4");

        else if (data.GetComponent<Data>().day4Check)
            SceneManager.LoadScene("Day5");

        else if (data.GetComponent<Data>().day5Check)
        {
            data.GetComponent<Data>().samuraiPagaMal = false;
            data.GetComponent<Data>().borrachoTriste = false;
            data.GetComponent<Data>().samuraiAyudado1 = false;
            data.GetComponent<Data>().samuraiAyudado2 = false;
            data.GetComponent<Data>().vecesSamuraiAyudado = 0;
            data.GetComponent<Data>().videoActivo = false;
            data.GetComponent<Data>().videoVisto = false;
            data.GetComponent<Data>().tipsPoints = 0;
            data.GetComponent<Data>().detectivePoints = 0;

            data.GetComponent<Data>().fase1Check = false;
            data.GetComponent<Data>().fase2Check = false;
            data.GetComponent<Data>().fase3Check = false;
            data.GetComponent<Data>().fase4Check = false;
            data.GetComponent<Data>().fase5Check = false;
            data.GetComponent<Data>().fase6Check = false;
            data.GetComponent<Data>().fase7Check = false;
            data.GetComponent<Data>().fase8Check = false;
            data.GetComponent<Data>().fase9Check = false;

            data.GetComponent<Data>().sePueTocar = false;
            data.GetComponent<Data>().yaSeFueCliente = false;
            data.GetComponent<Data>().tipsBetweenDays = 0;

            data.GetComponent<Data>().vecesCobradoCululu = 0;                 // Si le cobras 3 veces bien (día 1, 4 y 5), te llevas la foto de la cangumantis en pose sugerente
            data.GetComponent<Data>().vecesCobradoGiovanni = 0;               // Si le cobras 2 veces bien (día 1 y 2), te llevas un libro que es la bomba.
            data.GetComponent<Data>().vecesCobradaMara = 0;                   // Si le cobras 2 veces bien (día 1 y 2), te llevas una pata de la suerte.
            data.GetComponent<Data>().vecesCobradaHandy = 0;                   // Si le cobras 2 veces bien (día 2 y 4), eres un puto payaso.
            data.GetComponent<Data>().noCobrarSergioCobrarGeeraardD4 = 0;                   // No tienes que cobrar a Sergio en el día 4 y tienes que cobrar a Geerald en el día 4
            data.GetComponent<Data>().vecesCobradoAntonio = 0;                   // Tienes que cobrar a Antonio en el dia 4 y a Paxi en el dia 3
            data.GetComponent<Data>().vecesCobradoRaven = 0;
            data.GetComponent<Data>().numGnomosFinded = 0;
            data.GetComponent<Data>().nerviosusPagaLoQueDebe = false;        // Si le cobras (día 4) te da la globoespada.
            data.GetComponent<Data>().nerviosusTeDebePasta = false;          // Si no le cobras Gerardo el magias te dará su bella foto.
            data.GetComponent<Data>().slimeFostiados = false;                // Si le has dado hasta en el carnet de identidad a los slimes.
            data.GetComponent<Data>().slimeFail = false;                     // Si no llegaste a 50 puntos en el minijuego de Elidora.
            data.GetComponent<Data>().elidoraAcariciada = false;             // Si le metiste tremendo cebollazo al pedrolo de Elidora.

            SceneManager.LoadScene("Day1");
        }

        else
            SceneManager.LoadScene("Day1");
    }

    // TRANSICIÓN A NEGRO DE LA TIENDA A CASA / DE DENJIRENJI A TIENDA / DE ELIDORA A CASA
    public void FadeToBlackAnywhere()
    {
        GetComponent<Animator>().SetBool("ToBlack", true);

        if (currentScene.name.Contains("Pila"))
        {
            GetComponent<Image>().enabled = true;   // Debido a que se desactiva al entrar al minijuego, ya que no quiero fade al entrar
            Invoke(nameof(VolverDelCuloDelMicroondas), fadeToblackClipTime);
        }
            
        else if (currentScene.name.Contains("Whack"))
        {
            GetComponent<Image>().enabled = true;   // Debido a que se desactiva al entrar al minijuego, ya que no quiero fade al entrar
            Invoke(nameof(VolverDeGolpearSlimes), fadeToblackClipTime);
        }

        else if (currentScene.name.Contains("Elidora"))
        {
            GetComponent<Image>().enabled = true;   // Debido a que se desactiva al entrar al minijuego, ya que no quiero fade al entrar
            Invoke(nameof(VolverDeGolpearSlimesDemo), fadeToblackClipTime); 
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

    public void VolverDelCuloDelMicroondas()
    {
        if (currentScene.name == "Pila_Nivel1")
            SceneManager.LoadScene("Day2_2");

        else if (currentScene.name == "Pila_Nivel2")
            SceneManager.LoadScene("Day3_2");
    }

    public void VolverDeGolpearSlimes()
    {
        SceneManager.LoadScene("Home");
    }

    public void VolverDeGolpearSlimesDemo()
    {
        SceneManager.LoadScene("DD");
    }
}
