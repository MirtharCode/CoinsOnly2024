using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transiciones : MonoBehaviour
{
    [SerializeField] public GameObject cursor;
    [SerializeField] public Animator anim;
    [SerializeField] public GameObject data;

    void Start()
    {
        GameObject newCursor = Instantiate(cursor, transform);
        anim = GetComponent<Animator>();
        data = GameObject.FindGameObjectWithTag("Data");
        ShowGifts();
    }

    void Update()
    {

    }

    public void NextDayTransiciones()
    {
        if (data.GetComponent<Data>().day1Check) SceneManager.LoadScene("Day2_1");         // Si vienes de acabar el día uno, pasas al dos.
        else if (data.GetComponent<Data>().day2Check) SceneManager.LoadScene("Day3_1");    // Si vienes de acabar el día dos, pasas al tres.
        else if (data.GetComponent<Data>().day3Check) SceneManager.LoadScene("Day4");    // Si vienes de acabar el día tres, pasas al cuatro.
        else if (data.GetComponent<Data>().day4Check) SceneManager.LoadScene("Day5");    // Si vienes de acabar el día cuatro, pasas al quinto.

        else if (data.GetComponent<Data>().day5Check && data.GetComponent<Data>().tipsPoints == 0) SceneManager.LoadScene(9);       // Si acabas el juego sin haber obtenido +50 tips en ningún día, pasas al final muy malo.        

        else if (data.GetComponent<Data>().day5Check &&
            (data.GetComponent<Data>().tipsPoints == 1 || data.GetComponent<Data>().tipsPoints == 2)) SceneManager.LoadScene(10);   // Si acabas el juego habiendo obtenido +50 en uno o dos días, pasas al final malo.

        else if (data.GetComponent<Data>().day5Check &&
            (data.GetComponent<Data>().tipsPoints == 3 || data.GetComponent<Data>().tipsPoints == 4)) SceneManager.LoadScene(11);   // Si acabas el juego habiendo obtenido +50 en tres o cuatro días, pasas al final bueno.

        else if (data.GetComponent<Data>().day5Check && data.GetComponent<Data>().tipsPoints == 5
        && data.GetComponent<Data>().detectivePoints == 4) SceneManager.LoadScene(13);           // Si acabas el juego habiendo obtenido +50 en los cinco días, y aparte aciertas al mmenos tres veces con el detective, vas al final secreto.


        else if (data.GetComponent<Data>().day5Check && data.GetComponent<Data>().tipsPoints == 5) SceneManager.LoadScene(12);      // Si acabas el juego habiendo obtenido +50 en los cinco días, pasas al final muy bueno.

    }

    public void ShowGifts()
    {
        if (data.GetComponent<Data>().giftGeeraard) transform.GetChild(10).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftEnano) transform.GetChild(11).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftMano) transform.GetChild(4).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftElidora) transform.GetChild(18).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftElvog) transform.GetChild(5).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftMara) transform.GetChild(16).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftPetra) transform.GetChild(14).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftAntonio) transform.GetChild(9).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftGiovanni) transform.GetChild(15).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftCululu) transform.GetChild(8).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftSergio) transform.GetChild(7).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftTapicio) transform.GetChild(17).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftHandy) transform.GetChild(19).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftDenjirenji) transform.GetChild(12).gameObject.SetActive(true);
        if (data.GetComponent<Data>().giftRaven) transform.GetChild(6).gameObject.SetActive(true);
        if (data.GetComponent<Data>().day4Check || data.GetComponent<Data>().day5Check)
        {
            transform.GetChild(13).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
        }

    }
}