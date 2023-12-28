using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyDMariano : MonoBehaviour
{
    [SerializeField] public bool a;
    [SerializeField] public GameObject gameManager;

    bool repetirunavez = false;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;
            //gameManager.GetComponent<GameManager>().leDinero.gameObject.SetActive(true);
            //gameManager.GetComponent<GameManager>().leDineroText.text = "65";
        }
    }
}
