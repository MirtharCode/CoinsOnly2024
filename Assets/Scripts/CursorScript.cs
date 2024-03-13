using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    [SerializeField] private Vector3 hotspot = new Vector3(60, -65, 0);
    public Sprite normalClickedCursorImage, normalCursorImage;
    public Sprite normalSmashedHammerImage, normalHammerImage;
    public Image image;

    public Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        image = GetComponent<Image>();

        currentScene = SceneManager.GetActiveScene();
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
        if (!currentScene.name.Contains("Whack"))
            image.sprite = normalClickedCursorImage;
        else image.sprite = normalSmashedHammerImage;

    }

    private void CursorNormal()
    {
        if (!currentScene.name.Contains("Whack"))
            image.sprite = normalCursorImage;
        else image.sprite = normalHammerImage;
    }
}
