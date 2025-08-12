using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeDay : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public float maxPullDistance = 200f; 
    public UnityEvent onMaxPull; 

    private RectTransform rectTransform;
    private Vector2 startPos;
    private bool isDragging = false;
    private bool hasFiredEvent = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        hasFiredEvent = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        Vector2 dragPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out dragPos
        );

        float clampedY = Mathf.Max(dragPos.y, startPos.y - maxPullDistance);
        rectTransform.anchoredPosition = new Vector2(startPos.x, clampedY);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        rectTransform.anchoredPosition = startPos; 

        float dist = startPos.y - rectTransform.anchoredPosition.y;
        if (dist >= maxPullDistance * 0.95f && !hasFiredEvent)
        {
            onMaxPull?.Invoke();
            hasFiredEvent = true;
        }
    }
}