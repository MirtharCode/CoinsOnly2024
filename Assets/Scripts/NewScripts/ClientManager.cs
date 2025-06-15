using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClientManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speakerRaceTextBox;
    [SerializeField] TextMeshProUGUI speakerTextBox;
    [SerializeField] TextMeshProUGUI dialogueTextBox;
    [SerializeField] GameObject currentClient;
    [SerializeField] Image miniImage;
    [SerializeField] public Transform showUpPoint;

    private float timer = 0.3f;
    private bool firstShow = false;

    private DialogueManager.DailyClientInfo currentDialogueClient;
    private int clientDialogueLineIndex = 0;
    private bool dialogueReady = false;
    private bool showingDialogue = false;
    public bool iWantToBelieve = false;
    public bool noWayJose = false;
    private bool cobrasteBien = false;
    private bool cobrasteMal = false;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && !firstShow)
        {
            firstShow = true;
            StartNextClient();
        }

        if (!dialogueReady && DialogueManager.Instance.IsReady)
        {
            dialogueReady = true;
            Debug.Log("Diálogos listos.");
        }
    }

    void StartNextClient()
    {
        if (DialogueManager.Instance.dailyCustomers.Count == 0)
        {
            Debug.Log("Todos los clientes han sido atendidos.");
            return;
        }

        currentDialogueClient = DialogueManager.Instance.dailyCustomers[0];
        clientDialogueLineIndex = 0;

        CharacterShowUp(DialogueManager.Instance.clientPrefab);
        ChangingSprite(currentDialogueClient.race, currentDialogueClient.name, currentDialogueClient.dialogueLines[0].mood);
        ChangingMiniSprite(currentDialogueClient.name);

        showingDialogue = true;
        MostrarDialogoActual();
    }

    public void DialogueButton()
    {
        if (dialogueReady && showingDialogue)
        {

            if (clientDialogueLineIndex >= currentDialogueClient.dialogueLines.Count)
            {
                showingDialogue = false;
                FinishCurrentClient();
            }

            else
                MostrarDialogoActual();
        }

        else if (cobrasteBien || cobrasteMal)
        {
            showingDialogue = false;
            FinishCurrentClient();
        }
    }

    void MostrarDialogoActual()
    {
        if (!cobrasteBien && !cobrasteMal)
        {
            if (currentDialogueClient == null || currentDialogueClient.dialogueLines.Count == 0)
            {
                Debug.LogWarning("Cliente o líneas de diálogo no válidas.");
                return;
            }

            // Prevenir que se intente acceder fuera de rango
            if (clientDialogueLineIndex >= currentDialogueClient.dialogueLines.Count)
            {
                Debug.Log("Diálogo terminado para este cliente.");
                return;
            }

            var line = currentDialogueClient.dialogueLines[clientDialogueLineIndex];

            speakerRaceTextBox.text = currentDialogueClient.race;
            speakerTextBox.text = currentDialogueClient.name;
            dialogueTextBox.text = line.text;
            ChangingSprite(currentDialogueClient.race, currentDialogueClient.name, line.mood);

            clientDialogueLineIndex++;
        }

        else
        {
            speakerRaceTextBox.text = currentDialogueClient.race;
            speakerTextBox.text = currentDialogueClient.name;

            if (iWantToBelieve)
            {
                dialogueTextBox.text = currentDialogueClient.tickResponse;

                // IMPORTANTE TENGO QUE METERLE MOOD A LAS TICK Y CROSS RESPUESTAS            
                //ChangingSprite(currentDialogueClient.race, currentDialogueClient.name, tickResponse.mood);
            }

            else if (noWayJose)
            {
                dialogueTextBox.text = currentDialogueClient.crossResponse;

                // IMPORTANTE TENGO QUE METERLE MOOD A LAS TICK Y CROSS RESPUESTAS            
                //ChangingSprite(currentDialogueClient.race, currentDialogueClient.name, tickResponse.mood);
            }

            iWantToBelieve = false;
            noWayJose = false;
        }
    }


    void FinishCurrentClient()
    {
        DialogueManager.Instance.HideText();

        if (currentDialogueClient.numberOfProducts == 0 || cobrasteBien || cobrasteMal)
        {
            if (currentClient != null)
                currentClient.GetComponent<BoxCollider2D>().enabled = false;

            cobrasteBien = false;
            cobrasteMal = false;
            Destroy(currentClient, 1);

            if (DialogueManager.Instance.dailyCustomers.Count > 0)
                DialogueManager.Instance.dailyCustomers.RemoveAt(0);

            #region PARTE DEL DESPLEGABLE DE LOS PRECIOS Y NORMATIVAS QUE SE CAMBIARÁ
            DialogueManager.Instance.dropDownPanelPrecios.gameObject.SetActive(false);
            DialogueManager.Instance.dropDownPanelNormativas.gameObject.SetActive(false);
            #endregion

            Invoke(nameof(StartNextClient), 1);
        }

        else
        {
            Debug.Log("A mi me tienes que cobrar zanguango");
            ShowProducts(currentDialogueClient, currentDialogueClient.numberOfProducts);
        }
    }

    void ChangingSprite(string clientRace, string clientName, string clientMood)
    {
        Sprite loaded = Resources.Load<Sprite>($"Sprites/Clients/{clientRace}/{clientName}/{clientMood}");

        if (loaded == null)
            Debug.LogError($"¡No se pudo cargar el sprite en: Sprites/Clients/{clientRace}/{clientName}/{clientMood}!");

        else
            currentClient.GetComponent<SpriteRenderer>().sprite = loaded;
    }

    public void ChangingMiniSprite(string clientName)
    {
        Sprite loaded = Resources.Load<Sprite>($"Sprites/MiniImages/{clientName}");

        if (loaded == null)
            Debug.LogError($"¡No se pudo cargar el sprite en: Sprites/MiniImages/{clientName}!");

        else
            miniImage.sprite = loaded;
    }

    public void CharacterShowUp(GameObject character)
    {
        currentClient = Instantiate(character, showUpPoint);
    }

    public void ShowProducts(DialogueManager.DailyClientInfo client, int numProducts)
    {
        DialogueManager.Instance.leDinero.SetActive(true);
        DialogueManager.Instance.leDineroText.text = client.clientMoney.ToString();

        Sprite loaded1 = Resources.Load<Sprite>($"Sprites/Products/{client.productTypes[2]}");

        if (loaded1 == null)
            Debug.LogError($"¡No se pudo cargar el sprite en: Sprites/Products/{client.productTypes[2]}!");

        else
        {
            DialogueManager.Instance.centralProduct.GetComponent<Image>().sprite = loaded1;
            DialogueManager.Instance.centralProduct.GetComponent<Image>().enabled = true;

            if (numProducts > 1)
            {
                Sprite loaded2 = Resources.Load<Sprite>($"Sprites/Products/{client.productTypes[1]}");

                if (loaded2 == null)
                    Debug.LogError($"¡No se pudo cargar el sprite en: Sprites/Products/{client.productTypes[1]}!");

                else
                {
                    DialogueManager.Instance.rightProduct.GetComponent<Image>().sprite = loaded2;
                    DialogueManager.Instance.rightProduct.GetComponent<Image>().enabled = true;

                    if (numProducts == 3)
                    {
                        Sprite loaded3 = Resources.Load<Sprite>($"Sprites/Products/{client.productTypes[0]}");

                        if (loaded3 == null)
                            Debug.LogError($"¡No se pudo cargar el sprite en: Sprites/Products/{client.productTypes[0]}!");

                        else
                        {
                            DialogueManager.Instance.leftProduct.GetComponent<Image>().sprite = loaded3;
                            DialogueManager.Instance.leftProduct.GetComponent<Image>().enabled = true;
                        }
                    }
                }
            }
        }                  
    }

    public void TimeToCharge()
    {
        if (iWantToBelieve)
        {
            if (currentDialogueClient.correctChoice == "TICK")
                cobrasteBien = true;

            else
                cobrasteMal = true;
        }

        else if (noWayJose)
        {
            if (currentDialogueClient.correctChoice == "CROSS")
                cobrasteBien = true;

            else
                cobrasteMal = true;
        }

        DialogueManager.Instance.ShowText();
        MostrarDialogoActual();
        DialogueManager.Instance.leDinero.SetActive(false);
        DialogueManager.Instance.centralProduct.GetComponent<Image>().enabled = false;
        DialogueManager.Instance.rightProduct.GetComponent<Image>().enabled = false;
        DialogueManager.Instance.leftProduct.GetComponent<Image>().enabled = false;

    }

    public void IWantToBelieve()
    {
        iWantToBelieve = true;
    }

    public void NoWayJose()
    {
        noWayJose = true;
    }
}
