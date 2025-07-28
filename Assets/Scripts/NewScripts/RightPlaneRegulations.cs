using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightPlaneRegulations : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Derecha");
        
        for (int i = 0; i < DialogueManager.Instance.currentRegulationsBook.transform.childCount; i++) 
        {
            if (DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).name == DialogueManager.Instance.currentDay) 
            {
                if (DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(0).GetChild(0).gameObject.activeInHierarchy)     // SI EL PANEL DE MAGOS OSCUROS ESTÁ ACTIVO, QUIERE DECIR QUE ESTOY EN LA PÁGINA UNO
                {
                    // Por lo que al hacer click en el panel de la izquierda, me voy a la PÁGINA DOS
                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(0).GetChild(1).gameObject.SetActive(true);       // Activando el panel izquierdo de los Híbridos      
                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(0).GetChild(0).gameObject.SetActive(false);      // Desactivando el panel izquierdo de los Magos Oscuros

                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(1).GetChild(1).gameObject.SetActive(true);       // Activando el panel derecho de los Tecnópedos 
                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(1).GetChild(0).gameObject.SetActive(false);      // Desactivando el panel derecho de los Limbásticos
                }

                else if (DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(0).GetChild(1).gameObject.activeInHierarchy)     // SI EL PANEL DE HÍBRIDOS ESTÁ ACTIVO, QUIERE DECIR QUE ESTOY EN LA PÁGINA DOS
                {
                    // Por lo que al hacer click en el panel de la izquierda, me voy a la PÁGINA TRES
                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(0).GetChild(2).gameObject.SetActive(true);       // Activando el panel izquierdo de los Elementales
                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(0).GetChild(1).gameObject.SetActive(false);      // Desactivando el panel izquierdo de los Híbridos

                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(1).GetChild(1).gameObject.SetActive(false);       // Desactivando el panel derecho de los Tecnópedos
                }
            }
        }    
        
    }
}
