using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
    [SerializeField] public HomeManager hM;

    void Start()
    {
        hM = GameObject.FindGameObjectWithTag("HM").GetComponent<HomeManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WakingUpText()
    {
        hM.dialoguePanel.gameObject.SetActive(true);
    }
}
