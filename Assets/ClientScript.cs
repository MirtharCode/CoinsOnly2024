using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClientScript : MonoBehaviour
{

    [SerializeField] public GameObject uIManager;
    public bool repetirunavez = false;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.FindGameObjectWithTag("UI");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trampilla" && repetirunavez == false)
        {
            repetirunavez = true;

            DialogueManager.Instance.GetComponent<DialogueManager>().ShowText();
        }
    }
}
