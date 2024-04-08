using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] public HomeManager hM;
    void Start()
    {
        hM.ShowingText();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
