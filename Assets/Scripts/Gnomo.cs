using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnomo : MonoBehaviour
{
    [SerializeField] public GameObject gameManager;
    [SerializeField] public GameObject canvas;

    Animator animator;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM");
        canvas = GameObject.FindGameObjectWithTag("UI");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void GnomoFinded()
    {
        Data.instance.numGnomosFinded++;
        animator.SetBool("Pick", false);
    }

    public void ShowUpGnomoAnim()
    {
        animator.SetBool("Pick", true);
    }
}
