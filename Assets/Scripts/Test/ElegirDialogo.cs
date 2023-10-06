using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElegirDialogo : MonoBehaviour
{
    [SerializeField] float reputation;
    [SerializeField] GameObject answer, sir;
    [SerializeField] Sprite anger, unaware, happy;
    [SerializeField] TMP_Text answerText;
    [SerializeField] Image reputationNumber;

    private void Update()
    {
        gameObject.transform.GetChild(0).GetComponent<Slider>().value = reputation;
        ChangingReputation(0);
    }
    public void Option1()
    {
        Image clon = Instantiate(reputationNumber, gameObject.transform.GetChild(0).GetChild(0).transform.position, gameObject.transform.GetChild(0).GetChild(0).transform.rotation);
        clon.transform.SetParent(gameObject.transform.GetChild(0).transform);
        clon.transform.GetComponent<Image>().color = Color.red;
        answer.gameObject.SetActive(true);
        sir.gameObject.GetComponent<SpriteRenderer>().sprite = anger;
        answerText.text = "¡LA ATREVACIÓN!";
        ChangingReputation(-10);
    }

    public void Option2()
    {
        Image clon = Instantiate(reputationNumber, gameObject.transform.GetChild(0).GetChild(0).transform.position, gameObject.transform.GetChild(0).GetChild(0).transform.rotation);
        clon.transform.SetParent(gameObject.transform.GetChild(0).transform);
        clon.transform.GetComponent<Image>().color = Color.green;

        answer.gameObject.SetActive(true);
        sir.gameObject.GetComponent<SpriteRenderer>().sprite = happy;
        answerText.text = "Como mi nepe :D";
        ChangingReputation(10);
    }

    public void Option3()
    {
        Image clon = Instantiate(reputationNumber, gameObject.transform.GetChild(0).GetChild(0).transform.position, gameObject.transform.GetChild(0).GetChild(0).transform.rotation);
        clon.transform.SetParent(gameObject.transform.GetChild(0).transform);
        clon.transform.GetComponent<Image>().color = Color.yellow;

        answer.gameObject.SetActive(true);
        sir.gameObject.GetComponent<SpriteRenderer>().sprite = unaware;
        answerText.text = "En verdad coincide con mis gustos sexuales.";
        ChangingReputation(0);
    }

    public void ChangingReputation(int howMany)
    {
        reputation += howMany;

        if (reputation >= 100)
            reputation = 100;
        else if (reputation <= -100)
            reputation = -100;

    }
}
