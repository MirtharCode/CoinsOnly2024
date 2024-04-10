using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    [SerializeField] public GameObject data;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeToBlackAnywhere()
    {
        GetComponent<Animator>().SetBool("ToBlack", true);
    }

    public void ClientEntrance()
    {
        data.GetComponent<Data>().homeManager.SomeoneIsKnocking();
    }
}
