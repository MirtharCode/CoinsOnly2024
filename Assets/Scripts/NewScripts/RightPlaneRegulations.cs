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
                if (DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(0).GetChild(0).gameObject.activeInHierarchy)     // SI EL PANEL DE MAGOS OSCUROS EST� ACTIVO, QUIERE DECIR QUE ESTOY EN LA P�GINA UNO
                {
                    // Por lo que al hacer click en el panel de la izquierda, me voy a la P�GINA DOS
                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(0).GetChild(1).gameObject.SetActive(true);       // Activando el panel izquierdo de los H�bridos      
                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(0).GetChild(0).gameObject.SetActive(false);      // Desactivando el panel izquierdo de los Magos Oscuros

                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(1).GetChild(1).gameObject.SetActive(true);       // Activando el panel derecho de los Tecn�pedos 
                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(1).GetChild(0).gameObject.SetActive(false);      // Desactivando el panel derecho de los Limb�sticos
                }

                else if (DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(0).GetChild(1).gameObject.activeInHierarchy)     // SI EL PANEL DE H�BRIDOS EST� ACTIVO, QUIERE DECIR QUE ESTOY EN LA P�GINA DOS
                {
                    // Por lo que al hacer click en el panel de la izquierda, me voy a la P�GINA TRES
                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(0).GetChild(2).gameObject.SetActive(true);       // Activando el panel izquierdo de los Elementales
                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(0).GetChild(1).gameObject.SetActive(false);      // Desactivando el panel izquierdo de los H�bridos

                    DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).GetChild(1).GetChild(1).gameObject.SetActive(false);       // Desactivando el panel derecho de los Tecn�pedos
                }
            }
        }    
        
    }
}
