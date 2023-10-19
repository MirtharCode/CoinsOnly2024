using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyDMariano : MonoBehaviour
{
    [SerializeField] public bool a;
    [SerializeField] public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM");
        gameManager.GetComponent<GameManager>().toyGrandote = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
