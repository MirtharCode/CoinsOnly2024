using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableTablet : MonoBehaviour, IPointerClickHandler
{
    public bool firstTimeClick = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (DialogueManager.Instance.currentDay == "01")
        {
            if (firstTimeClick)
                DialogueManager.Instance.clientManager.GetComponent<ClientManager>().DialogueButton();


            else
            {
                firstTimeClick = true;
                DialogueManager.Instance.clientManager.GetComponent<ClientManager>().ActivateTabletFirstTime();
                Invoke(nameof(ChangeTheFirstText), 1);
            }
        }

        else
            DialogueManager.Instance.clientManager.GetComponent<ClientManager>().DialogueButton();
    }

    public void CanIClick()
    {
        firstTimeClick = true;
    }

    public void ChangeTheFirstText()
    {
        DialogueManager.Instance.dialoguePanelFirstDialogueText.GetComponent<TextMeshProUGUI>().text =

            DialogueManager.Instance.clientManager.GetComponent<ClientManager>().currentDialogueClient.dialogueLines[DialogueManager.Instance.clientManager.GetComponent<ClientManager>().clientDialogueLineIndex-1].text;

        DialogueManager.Instance.dialoguePanelFirstDialogueText.GetComponent<TextMeshProUGUI>().fontSize = 90;
    }
}
