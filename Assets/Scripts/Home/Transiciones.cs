using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transiciones : MonoBehaviour
{
    [SerializeField] public GameObject cursor;
    [SerializeField] public GameObject transBlack;
    [SerializeField] public bool imPlayingSAL;
    [SerializeField] public Data data;

    void Start()
    {
        GameObject newCursor = Instantiate(cursor, transform);
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        ShowGifts();
    }

    void Update()
    {

    }

    public void NextDayTransiciones()
    {
        FadeToBlack();
        if (data.day1Check) SceneManager.LoadScene("Day2_1");           // Si vienes de acabar el d�a uno, pasas al dos.
        else if (data.day2Check) SceneManager.LoadScene("Day3_1");      // Si vienes de acabar el d�a dos, pasas al tres.
        else if (data.day3Check) SceneManager.LoadScene("Day4");        // Si vienes de acabar el d�a tres, pasas al cuatro.
        else if (data.day4Check) SceneManager.LoadScene("Day5");        // Si vienes de acabar el d�a cuatro, pasas al quinto.

        else if (data.day5Check)
        {
            if (data.tipsPoints == 0) SceneManager.LoadScene("FinalMuyMalo");

            // Si acabas el juego habiendo obtenido +50 en uno o dos d�as, pasas al final malo.
            else if (data.tipsPoints == 1 || data.tipsPoints == 2) SceneManager.LoadScene("FinalMalo");

            // Si acabas el juego habiendo obtenido +50 en tres o cuatro d�as, pasas al final bueno.
            else if (data.tipsPoints == 3 || data.tipsPoints == 4) SceneManager.LoadScene("FinalBueno");

            // Si acabas el juego habiendo obtenido +50 en los cinco d�as...
            else if (data.tipsPoints == 5)
            {
                // ... pero no tienes 4 puntos de Detective, pasas al final muy bueno.
                if (data.detectivePoints < 4) SceneManager.LoadScene("FinalMuyBueno");

                // y tienes los 5 puntoss al menos tres veces con el detective, vas al final secreto.
                else if (data.tipsPoints == 5 && data.detectivePoints == 4) SceneManager.LoadScene("FinalSecreto");
            }
        }
        // Si acabas el juego sin haber obtenido +50 tips en ning�n d�a, pasas al final muy malo.

    }

    public void ShowGifts()
    {
        if (data.giftGeeraard) transform.GetChild(11).gameObject.SetActive(true);
        if (data.giftEnano) transform.GetChild(12).gameObject.SetActive(true);
        if (data.giftMano) transform.GetChild(5).gameObject.SetActive(true);
        if (data.giftElidora) transform.GetChild(19).gameObject.SetActive(true);
        if (data.giftElvog) transform.GetChild(6).gameObject.SetActive(true);
        if (data.giftMara) transform.GetChild(17).gameObject.SetActive(true);
        if (data.giftPetra) transform.GetChild(15).gameObject.SetActive(true);
        if (data.giftAntonio) transform.GetChild(10).gameObject.SetActive(true);
        if (data.giftGiovanni) transform.GetChild(16).gameObject.SetActive(true);
        if (data.giftCululu) transform.GetChild(9).gameObject.SetActive(true);
        if (data.giftSergio) transform.GetChild(8).gameObject.SetActive(true);
        if (data.giftTapicio) transform.GetChild(18).gameObject.SetActive(true);
        if (data.giftHandy) transform.GetChild(20).gameObject.SetActive(true);
        if (data.giftDenjirenji) transform.GetChild(13).gameObject.SetActive(true);
        if (data.giftRaven) transform.GetChild(7).gameObject.SetActive(true);
        if (data.day4Check || data.day5Check)
        {
            transform.GetChild(13).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    public void TravellingAnimation()
    {
        imPlayingSAL = true;
        GetComponent<Animator>().SetBool("PlayingSAL", true);

    }

    public void GoToSAL()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void FadeToBlack()
    {
        transform.GetChild(22).gameObject.GetComponent<Animator>().SetBool("ToBlack", true);
    }
}