using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VoucherIndicator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private void Start()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //GetComponent<Animator>().SetTrigger("Up");
        GetComponent<Image>().color = Color.blue;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        //GetComponent<Animator>().SetTrigger("Down");
        GetComponent<Image>().color = Color.green;
    }
}