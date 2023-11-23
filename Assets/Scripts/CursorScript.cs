using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    [SerializeField] private Vector3 hotspot = new Vector3(60, -65, 0);
    public Sprite clickedCursorImage, normalCursorImage;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        transform.position = Input.mousePosition + hotspot;

        if (Input.GetMouseButtonDown(0))
            CursorClicked();

        else if (Input.GetMouseButtonUp(0))
            CursorNormal();
    }

    private void CursorClicked()
    {
        image.sprite = clickedCursorImage;
    }

    private void CursorNormal()
    {
        image.sprite = normalCursorImage;
    }
}
