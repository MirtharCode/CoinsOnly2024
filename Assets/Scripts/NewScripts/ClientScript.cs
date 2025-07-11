using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ClientScript : MonoBehaviour
{

    [SerializeField] public ClientManager cM;
    public bool repetirunavez = false;
    public AudioSource talkingSound;
    public AudioClip lastSound;

    // Start is called before the first frame update
    void Start()
    {
        cM = GameObject.FindGameObjectWithTag("UI").GetComponent<ClientManager>();
        talkingSound = gameObject.GetComponent<AudioSource>();
        talkingSound.enabled = true;

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
            cM.Speaking(cM.currentDialogueClient.dialogueLines[0].tone);
        }
    }
}
