using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sal_Button : MonoBehaviour

{
    public GameObject valla;

    void Awake()
    {
        valla = GameObject.FindGameObjectWithTag("valla");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && gameObject.transform.GetChild(0).gameObject.activeInHierarchy)

        {
            gameObject.transform.GetComponent<AudioSource>().enabled = true;
            valla.transform.GetChild(0).gameObject.SetActive(false);
            valla.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
