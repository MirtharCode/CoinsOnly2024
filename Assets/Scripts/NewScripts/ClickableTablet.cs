using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableTablet : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("¡Objeto 3D pulsado!");
        DialogueManager.Instance.clientManager.GetComponent<ClientManager>().DialogueButton();
    }
}
