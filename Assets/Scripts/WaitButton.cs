using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaitButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().enabled = false;
        GetComponent<Image>().enabled = false;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        StartCoroutine("TiempoEspera");
    }

    void OnEnable()
    {
        GetComponent<Button>().enabled = false;
        GetComponent<Image>().enabled = false;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        StartCoroutine("TiempoEspera");
    }

    void OnDisable()
    {
        //GetComponent<Button>().interactable = false;
    }

    public IEnumerator TiempoEspera()
    {
        yield return new WaitForSeconds(1f);

        GetComponent<Button>().enabled = true;
        GetComponent<Image>().enabled = true;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;

        //yield return new WaitForSeconds(0.01f);
    }
}
