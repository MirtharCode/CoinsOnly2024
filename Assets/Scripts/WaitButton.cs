using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().interactable = false;
    }

    void OnEnable()
    {
        StartCoroutine("TiempoEspera");
    }

    void OnDisable()
    {
        GetComponent<Button>().interactable = false;
    }

    public IEnumerator TiempoEspera()
    {
        yield return new WaitForSeconds(1f);

        GetComponent<Button>().interactable = true;

        yield return new WaitForSeconds(0.01f);
    }
}
