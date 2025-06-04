using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transiciones : MonoBehaviour
{
    [SerializeField] public GameObject cursor;
    [SerializeField] public GameObject transBlack;
    [SerializeField] public GameObject rodolfosNose;
    [SerializeField] public bool imPlayingSAL;
    [SerializeField] public Data data;
    [SerializeField] public FadeToBlack fTB;
    [SerializeField] public AnimationClip toBlackClip;

    void Start()
    {
        GameObject newCursor = Instantiate(cursor, transform);
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        fTB = GameObject.FindGameObjectWithTag("FadeBlack").GetComponent<FadeToBlack>();
        Data.instance.transiciones = gameObject.GetComponent<Transiciones>();
        ShowGifts();
        //fTB.FadeToBlackAnywhere();
    }

    void Update()
    {

    }

    public void NextDayTransiciones()
    {
        Debug.Log("Holi");

        //FTBRegular();
        if (data.day1Check) SceneManager.LoadScene("Day2_1");           // Si vienes de acabar el día uno, pasas al dos.
        else if (data.day2Check) SceneManager.LoadScene("Day3_1");      // Si vienes de acabar el día dos, pasas al tres.
        else if (data.day3Check) SceneManager.LoadScene("Day4");        // Si vienes de acabar el día tres, pasas al cuatro.
        else if (data.day4Check)
        {
            if (data.videoVisto)
                SceneManager.LoadScene("Day5");        // Si vienes de acabar el día cuatro, pasas al quinto.
            else
            {
                data.videoActivo = true;
                SceneManager.LoadScene("Home");
            }

        }

        else if (data.day5Check)
        {
            if (data.tipsPoints == 0) SceneManager.LoadScene("FinalMuyMalo");

            // Si acabas el juego habiendo obtenido +50 en uno o dos días, pasas al final malo.
            else if (data.tipsPoints == 1 || data.tipsPoints == 2) SceneManager.LoadScene("FinalMalo");

            // Si acabas el juego habiendo obtenido +50 en tres o cuatro días, pasas al final bueno.
            else if (data.tipsPoints == 3 || data.tipsPoints == 4) SceneManager.LoadScene("FinalBueno");

            // Si acabas el juego habiendo obtenido +50 en los cinco días...
            else if (data.tipsPoints == 5)
            {
                // ... pero no tienes 4 puntos de Detective, pasas al final muy bueno.
                if (data.detectivePoints < 4) SceneManager.LoadScene("FinalMuyBueno");

                // y tienes los 5 puntoss al menos tres veces con el detective, vas al final secreto.
                else if (data.tipsPoints == 5 && data.detectivePoints == 4) SceneManager.LoadScene("FinalSecreto");
            }
        }
        //Si acabas el juego sin haber obtenido + 50 tips en ningún día, pasas al final muy malo.
        Data.instance.GuardarDatos();
    }

    public void ShowGifts()
    {
        if (data.giftGeeraard) transform.GetChild(10).gameObject.SetActive(true);
        if (data.giftEnano) transform.GetChild(11).gameObject.SetActive(true);
        if (data.giftMano) transform.GetChild(4).gameObject.SetActive(true);
        if (data.giftElidora) transform.GetChild(18).gameObject.SetActive(true);
        if (data.giftElvog) transform.GetChild(5).gameObject.SetActive(true);
        if (data.giftMara) transform.GetChild(16).gameObject.SetActive(true);
        if (data.giftPetra) transform.GetChild(14).gameObject.SetActive(true);
        if (data.giftAntonio) transform.GetChild(9).gameObject.SetActive(true);
        if (data.giftGiovanni) transform.GetChild(15).gameObject.SetActive(true);
        if (data.giftCululu) transform.GetChild(8).gameObject.SetActive(true);
        if (data.giftSergio) transform.GetChild(7).gameObject.SetActive(true);
        if (data.giftTapicio)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(17).gameObject.SetActive(true);
            rodolfosNose.GetComponent<Animator>().SetTrigger("Resize");
        }
        if (data.giftHandy) transform.GetChild(19).gameObject.SetActive(true);
        if (data.giftDenjirenji) transform.GetChild(12).gameObject.SetActive(true);
        if (data.giftRaven) transform.GetChild(6).gameObject.SetActive(true);
        if (data.day4Check || data.day5Check)
        {
            transform.GetChild(13).gameObject.SetActive(true);
            //transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    public void TravellingAnimation()
    {
        if (data.GetComponent<Data>().sePueTocar)
        {
            imPlayingSAL = true;
            GetComponent<Animator>().SetBool("PlayingSAL", true);
        }
    }

    public void GoToSAL()
    {
        if (data.GetComponent<Data>().sePueTocar)
            SceneManager.LoadScene("LevelSelector");
    }

    public void GoToWhackASlime()
    {
        SceneManager.LoadScene("WhackAMole1");
    }

    public void FTBRegular()
    {
        if (data.GetComponent<Data>().sePueTocar)
        {
            data.GetComponent<Data>().yaSeFueCliente = false;
            float animTime;
            Animator anim = transform.GetChild(22).gameObject.GetComponent<Animator>();

            anim.SetBool("ToBlack", true);
            animTime = toBlackClip.length;

            Invoke(nameof(NextDayTransiciones), animTime);
        }
    }

    public void FTBSAL()
    {
        float animTime;
        Animator anim = transform.GetChild(22).gameObject.GetComponent<Animator>();

        anim.SetBool("ToBlack", true);
        animTime = toBlackClip.length;
    }
}