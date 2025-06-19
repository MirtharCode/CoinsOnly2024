using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class ClientManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speakerRaceTextBox;
    [SerializeField] TextMeshProUGUI speakerTextBox;
    [SerializeField] TextMeshProUGUI dialogueTextBox;
    [SerializeField] GameObject musicBox;
    [SerializeField] public string lastRaceMusic = "Desconocida";
    [SerializeField] public string lastNameMusic;
    [SerializeField] GameObject currentClient;
    [SerializeField] Image miniImage;
    [SerializeField] public Transform showUpPoint;


    private float timer = .5f;

    public DialogueManager.DailyClientInfo currentDialogueClient;
    private int clientDialogueLineIndex = 0;
    private bool dialogueReady = false;
    private bool showingDialogue = false;
    public bool iWantToBelieve = false;
    public bool noWayJose = false;
    private bool cobrasteBien = false;
    private bool cobrasteMal = false;
    private bool teTocaBronca = false;
    private bool meVoyAMinijuego = false;

    public string selectedSuspect;

    [SerializeField] private Material grayscaleMaterial;


    private void Start()
    {
        StartMusicSetup();
        Invoke(nameof(StartNextClient), timer);
    }
    void Update()
    {      

        if (!dialogueReady && DialogueManager.Instance.IsReady)
        {
            dialogueReady = true;
            Debug.Log("Diálogos listos.");
        }
    }

    public void Speaking(string toneSound)
    {
        string clientFolder = $"Sounds/Voices/{currentDialogueClient.name}";
        AudioClip[] allClips = Resources.LoadAll<AudioClip>(clientFolder);

        if (allClips.Length == 0)
        {
            Debug.LogWarning($"No se encontraron clips en la carpeta: {clientFolder}");
            return;
        }

        // Filtrar los que empiecen con el tipo (ej: "exclamative")
        var matchingClips = allClips.Where(clip => clip.name.StartsWith(toneSound, StringComparison.OrdinalIgnoreCase)).ToArray();

        if (matchingClips.Length == 0)
        {
            Debug.LogWarning($"No se encontraron clips que empiecen con '{toneSound}' en {clientFolder}");
            return;
        }

        // Elegir uno al azar
        AudioClip chosenClip = matchingClips[UnityEngine.Random.Range(0, matchingClips.Length)];

        // Reproducir
        var clientScript = currentClient.GetComponent<ClientScript>();
        clientScript.talkingSound.clip = chosenClip;
        clientScript.talkingSound.Play();
    }

    void StartNextClient()
    {
        CSVExporter.Instance.StartClientTimer();
        DialogueManager.Instance.jefePanel.GetComponent<Image>().enabled = false;
        DialogueManager.Instance.jefePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;

        if (DialogueManager.Instance.dailyCustomers.Count == 0 && SceneManager.GetActiveScene().name != "DD")
        {
            StartCoroutine(FadeFromGrayscale(grayscaleMaterial, 2f));
        }

        if (DialogueManager.Instance.dailyCustomers.Count == 0)
        {
            Debug.Log("Todos los clientes han sido atendidos.");
            CSVExporter.Instance.FinalizeSession();
            return;
        }


        currentDialogueClient = DialogueManager.Instance.dailyCustomers[0];
        clientDialogueLineIndex = 0;

        CharacterShowUp(DialogueManager.Instance.clientPrefab);
        ChangingSprite(currentDialogueClient.race, currentDialogueClient.name, currentDialogueClient.dialogueLines[0].mood);
        ChangingMiniSprite(currentDialogueClient.name);

        if (currentDialogueClient.name == "Detective")
            StartCoroutine(FadeToGrayscale(grayscaleMaterial, 2f));


        showingDialogue = true;
        MostrarDialogoActual();
        ChangeTheMusic(currentDialogueClient.race, currentDialogueClient.name);
    }

    #region MÚSICA

    public void StartMusicSetup()
    {
        // Activar música base
        AudioSource baseTrack = musicBox.GetComponent<AudioSource>();
        baseTrack.volume = 0.5f;
        baseTrack.loop = true;
        baseTrack.Play();

        // Silenciar y reproducir en background todos los hijos
        foreach (Transform child in musicBox.transform)
        {
            AudioSource track = child.GetComponent<AudioSource>();
            track.volume = 0f;
            track.loop = true;
            track.Play(); // Reproduce pero no se escucha hasta que haga FadeIn
        }

        musicBox.transform.GetChild(5).GetComponent<AudioSource>().Stop();
    }
    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0f, t / duration);
            yield return null;
        }

        audioSource.volume = 0f;
    }

    private IEnumerator FadeIn(AudioSource audioSource, float duration, float targetVolume = .33f)
    {
        audioSource.volume = 0f;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0f, targetVolume, t / duration);
            yield return null;
        }

        audioSource.volume = targetVolume;
    }

    public void ChangeTheMusic(string currentRace, string currentName)
    {
        float fadeDuration = 1.5f;

        if (currentRace == lastRaceMusic && lastNameMusic != "Detective")
            return;

        // Guardamos la raza actual como la nueva activa
        lastRaceMusic = currentRace;
        lastNameMusic = currentName;

        if (currentRace != "Desconocida")
        {
            for (int i = 0; i < musicBox.transform.childCount; i++)
            {
                Transform child = musicBox.transform.GetChild(i);
                AudioSource src = child.GetComponent<AudioSource>();

                if (child.name == currentRace)
                    StartCoroutine(FadeIn(src, fadeDuration));
                else
                    StartCoroutine(FadeOut(src, fadeDuration));
            }

        }
        else
        {
            // Esto solo pasa en la demo de MadridOtaku
            if (currentDialogueClient.name == "Mikujefe" && currentDialogueClient.clientID == "clientFINAL" && DialogueManager.Instance.currentSceneName == "DD")
            {
                StartCoroutine(FadeIn(musicBox.GetComponent<AudioSource>(), fadeDuration));
                StartCoroutine(FadeOut(musicBox.transform.GetChild(5).GetComponent<AudioSource>(), fadeDuration));
                StartCoroutine(FadeFromGrayscale(grayscaleMaterial, 2f));
            }
            else if (currentDialogueClient.name == "Detective")
            {
                StartCoroutine(FadeOut(musicBox.GetComponent<AudioSource>(), fadeDuration));

                for (int i = 0; i <= 4; i++)
                    StartCoroutine(FadeOut(musicBox.transform.GetChild(i).GetComponent<AudioSource>(), fadeDuration));

                // La pista 5 solo la reproducimos si existe
                if (musicBox.transform.childCount > 5)
                {
                    AudioSource special = musicBox.transform.GetChild(5).GetComponent<AudioSource>();
                    special.Play();
                    StartCoroutine(FadeIn(special, fadeDuration));
                }
            }
        }
    }

    #endregion

    public void DialogueButton()
    {
        if (dialogueReady && showingDialogue)
        {
            if (currentDialogueClient.dialogueLines[clientDialogueLineIndex - 1].type == "minigame")
            {
                meVoyAMinijuego = true;
                showingDialogue = false;
                DialogueManager.Instance.lastSceneWithDialogues = SceneManager.GetActiveScene().name;

                FinishCurrentClient();               
            }

            else if (clientDialogueLineIndex >= currentDialogueClient.dialogueLines.Count)
            {
                showingDialogue = false;
                FinishCurrentClient();
            }

            else if (clientDialogueLineIndex == currentDialogueClient.dialogueLines.Count - 1 && currentDialogueClient.name == "Detective")
                MostrarPanelDetective();

            else
                MostrarDialogoActual();
        }

        else if (cobrasteBien || cobrasteMal)
        {
            showingDialogue = false;
            FinishCurrentClient();
        }
    }

    public void GoingToMinigame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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

            if (clientDialogueLineIndex != 0)
                Speaking(line.tone);

            ChangingSprite(currentDialogueClient.race, currentDialogueClient.name, line.mood);

            clientDialogueLineIndex++;
        }

        else
        {
            speakerRaceTextBox.text = currentDialogueClient.race;
            speakerTextBox.text = currentDialogueClient.name;

            if (iWantToBelieve)
            {
                dialogueTextBox.text = currentDialogueClient.tickResponse[0].text;
                Speaking(currentDialogueClient.tickResponse[0].tone);
                ChangingSprite(currentDialogueClient.race, currentDialogueClient.name, currentDialogueClient.tickResponse[0].mood);
            }

            else if (noWayJose)
            {
                dialogueTextBox.text = currentDialogueClient.crossResponse[0].text;
                Speaking(currentDialogueClient.crossResponse[0].tone);
                ChangingSprite(currentDialogueClient.race, currentDialogueClient.name, currentDialogueClient.crossResponse[0].mood);
            }

            iWantToBelieve = false;
            noWayJose = false;
        }

    }

    #region DETECTIVE

    void MostrarPanelDetective()
    {
        DialogueManager.Instance.detectivePanel.SetActive(true);
        DialogueManager.Instance.detectivePanel.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/MiniImages/{currentDialogueClient.suspects[0]}");
        DialogueManager.Instance.detectivePanel.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/MiniImages/{currentDialogueClient.suspects[1]}");
        DialogueManager.Instance.detectivePanel.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/MiniImages/{currentDialogueClient.suspects[2]}");
        DialogueManager.Instance.dialoguePanel.GetComponent<Button>().enabled = false;
    }

    public void SetSelectedSuspectFromButton(GameObject button)
    {
        Image img = button.GetComponent<Image>();

        if (img != null && img.sprite != null)
        {
            selectedSuspect = img.sprite.name;
            Debug.Log("Sospechoso seleccionado: " + selectedSuspect);
        }
        else
        {
            Debug.LogWarning("No se encontró un Image o Sprite válido en el botón.");
        }

        DialogueManager.Instance.areYouSurePanel.SetActive(true);
    }

    public void MatchingSuspect()
    {
        if (selectedSuspect == currentDialogueClient.correctAnswer)
        {
            // CORRECTO!!!
        }

        else
        {
            // INCORRECTO
        }

        DialogueManager.Instance.areYouSurePanel.SetActive(false);
        DialogueManager.Instance.detectivePanel.SetActive(false);
        DialogueManager.Instance.dialoguePanel.GetComponent<Button>().enabled = true;
        speakerTextBox.text = currentDialogueClient.name;
        MostrarDialogoActual();

    }

    public void IChangeMyMind()
    {
        DialogueManager.Instance.areYouSurePanel.SetActive(false);
        selectedSuspect = "";
    }

    #endregion


    public void TesteoBurro()
    {
        cobrasteBien = false;
        cobrasteMal = false;
        Destroy(currentClient);

        if (DialogueManager.Instance.dailyCustomers.Count > 0)
            DialogueManager.Instance.dailyCustomers.RemoveAt(0);

        #region PARTE DEL DESPLEGABLE DE LOS PRECIOS Y NORMATIVAS QUE SE CAMBIARÁ
        DialogueManager.Instance.dropDownPanelPrecios.gameObject.SetActive(false);
        DialogueManager.Instance.dropDownPanelNormativas.gameObject.SetActive(false);
        #endregion

        StartNextClient();
    }

    void FinishCurrentClient()
    {
        DialogueManager.Instance.HideText();

        if (currentDialogueClient.numberOfProducts == 0 || cobrasteBien || cobrasteMal)
        {
            CSVExporter.Instance.StopClientTimer();
            if (currentClient != null)
                currentClient.GetComponent<BoxCollider2D>().enabled = false;

            cobrasteBien = false;
            cobrasteMal = false;

            #region PARTE DEL DESPLEGABLE DE LOS PRECIOS Y NORMATIVAS QUE SE CAMBIARÁ
            DialogueManager.Instance.dropDownPanelPrecios.gameObject.SetActive(false);
            DialogueManager.Instance.dropDownPanelNormativas.gameObject.SetActive(false);
            #endregion

            if (!teTocaBronca)
            {
                Destroy(currentClient, 1);

                if (DialogueManager.Instance.dailyCustomers.Count > 0)
                    DialogueManager.Instance.dailyCustomers.RemoveAt(0);

                if (!meVoyAMinijuego)             
                    Invoke(nameof(StartNextClient), 1);

                else
                    GoingToMinigame(currentDialogueClient.name);            
            }

            else
            {
                teTocaBronca = false;

                if (currentDialogueClient.bossComplainsCheckWrong != "")
                    StartCoroutine(BossCalling(currentDialogueClient.bossComplainsCheckWrong));
                else
                    StartCoroutine(BossCalling(currentDialogueClient.bossComplainsByeWrong));

                Destroy(currentClient, 1);

                if (DialogueManager.Instance.dailyCustomers.Count > 0)
                    DialogueManager.Instance.dailyCustomers.RemoveAt(0);


                Invoke(nameof(StartNextClient), 2.5f);
            }
        }

        else
            ShowProducts(currentDialogueClient, currentDialogueClient.numberOfProducts);
    }

    public void LaVoluntad(float cantidad)
    {
        DialogueManager.Instance.propinasNumber += cantidad;

        if (DialogueManager.Instance.propinasNumber <= 0)
        {
            DialogueManager.Instance.propinasNumber = 0;
            DialogueManager.Instance.lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{0}");
        }

        else if (DialogueManager.Instance.propinasNumber > 0 && DialogueManager.Instance.propinasNumber <= 10)
            DialogueManager.Instance.lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{10}");

        else if (DialogueManager.Instance.propinasNumber > 10 && DialogueManager.Instance.propinasNumber <= 20)
            DialogueManager.Instance.lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{20}");

        else if (DialogueManager.Instance.propinasNumber > 20 && DialogueManager.Instance.propinasNumber <= 30)
            DialogueManager.Instance.lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{30}");

        else if (DialogueManager.Instance.propinasNumber > 30 && DialogueManager.Instance.propinasNumber <= 40)
            DialogueManager.Instance.lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{40}");

        else if (DialogueManager.Instance.propinasNumber > 40 && DialogueManager.Instance.propinasNumber <= 50)
            DialogueManager.Instance.lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{50}");

        else if (DialogueManager.Instance.propinasNumber > 50 && DialogueManager.Instance.propinasNumber <= 60)
            DialogueManager.Instance.lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{60}");

        else if (DialogueManager.Instance.propinasNumber > 60 && DialogueManager.Instance.propinasNumber <= 70)
            DialogueManager.Instance.lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{70}");

        else if (DialogueManager.Instance.propinasNumber > 70 && DialogueManager.Instance.propinasNumber <= 80)
            DialogueManager.Instance.lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{80}");

        else if (DialogueManager.Instance.propinasNumber > 80 && DialogueManager.Instance.propinasNumber <= 90)
            DialogueManager.Instance.lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{90}");

        else if (DialogueManager.Instance.propinasNumber > 90 && DialogueManager.Instance.propinasNumber <= 100)
            DialogueManager.Instance.lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{100}");

        else if (DialogueManager.Instance.propinasNumber > 100)
        {
            DialogueManager.Instance.propinasNumber = 100;
            DialogueManager.Instance.lesPropinas.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TipJar/{100}");
        }
        DialogueManager.Instance.lePropinasText.text = "" + DialogueManager.Instance.propinasNumber;

    }

    public IEnumerator BossCalling(string bossComplain)
    {
        DialogueManager.Instance.phone.gameObject.GetComponent<Animator>().SetBool("LlamaJefe", true);

        yield return new WaitForSeconds(.5f);

        DialogueManager.Instance.phone.gameObject.GetComponent<Animator>().SetBool("LlamaJefe", false);

        DialogueManager.Instance.jefePanel.GetComponent<Image>().enabled = true;
        DialogueManager.Instance.jefePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        DialogueManager.Instance.textoJefe.text = bossComplain;
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
        DialogueManager.Instance.buttonCobrar.SetActive(true);
        DialogueManager.Instance.buttonNoCobrar.SetActive(true);
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

        if (currentDialogueClient.hasCoupon)
        {
            Sprite loadedCoupon = Resources.Load<Sprite>($"Sprites/Coupons/{client.couponRace}/{client.couponType}");

            if (loadedCoupon == null)
                Debug.LogError($"¡No se pudo cargar el sprite en: Sprites/Coupons/{client.couponRace}/{client.couponType}!");

            else
            {
                DialogueManager.Instance.couponPlace.GetComponent<Image>().sprite = loadedCoupon;
                DialogueManager.Instance.couponPlace.GetComponent<Image>().enabled = true;
            }
        }
    }

    public void TimeToCharge()
    {
        if (iWantToBelieve)
        {
            LaVoluntad(currentDialogueClient.tipsIfCheck);

            if (currentDialogueClient.correctChoice == "TICK")
                cobrasteBien = true;

            else
            {
                cobrasteMal = true;
                teTocaBronca = true;
            }

        }

        else if (noWayJose)
        {
            LaVoluntad(currentDialogueClient.tipsIfBye);

            if (currentDialogueClient.correctChoice == "CROSS")
                cobrasteBien = true;

            else
            {
                cobrasteMal = true;
                teTocaBronca = true;
            }
        }

        DialogueManager.Instance.ShowText();
        MostrarDialogoActual();
        DialogueManager.Instance.leDinero.SetActive(false);
        DialogueManager.Instance.buttonCobrar.SetActive(false);
        DialogueManager.Instance.buttonNoCobrar.SetActive(false);
        DialogueManager.Instance.centralProduct.GetComponent<Image>().enabled = false;
        DialogueManager.Instance.rightProduct.GetComponent<Image>().enabled = false;
        DialogueManager.Instance.leftProduct.GetComponent<Image>().enabled = false;
        DialogueManager.Instance.couponPlace.GetComponent<Image>().enabled = false;

    }

    public void IWantToBelieve()
    {
        iWantToBelieve = true;
    }

    public void NoWayJose()
    {
        noWayJose = true;
    }

    public IEnumerator FadeToGrayscale(Material mat, float duration)
    {
        float t = 0;
        while (t < duration)
        {
            mat.SetFloat("_Lerp", t / duration);
            t += Time.deltaTime;
            yield return null;
        }
        mat.SetFloat("_Lerp", 1f);
    }

    IEnumerator FadeFromGrayscale(Material mat, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            float amount = 1f - (t / duration);
            mat.SetFloat("_Lerp", amount);
            t += Time.deltaTime;
            yield return null;
        }
        mat.SetFloat("_Lerp", 0f);
    }

    #region CÓDIGO ANTIGUO REFERENTE A LOS DESPLEGABLES DE NORMATIVAS Y PRECIOS QUE CAMBIARÁN
    public void OpenListPrecios()
    {
        if (DialogueManager.Instance.listOpenPrecios)
        {
            DialogueManager.Instance.buttonCobrar.SetActive(true);
            DialogueManager.Instance.buttonNoCobrar.SetActive(true);
            DialogueManager.Instance.dropDownPanelPrecios.transform.position = DialogueManager.Instance.position2Precios.transform.position;
            DialogueManager.Instance.botonDesplegadoPrecios.SetActive(true);
            DialogueManager.Instance.botonPlegadoPrecios.SetActive(false);
            DialogueManager.Instance.listOpenPrecios = false;
        }

        else
        {
            DialogueManager.Instance.buttonCobrar.SetActive(false);
            DialogueManager.Instance.buttonNoCobrar.SetActive(false);
            DialogueManager.Instance.dropDownPanelPrecios.transform.position = DialogueManager.Instance.position1Precios.transform.position;
            DialogueManager.Instance.botonDesplegadoPrecios.SetActive(false);
            DialogueManager.Instance.botonPlegadoPrecios.SetActive(true);
            DialogueManager.Instance.listOpenPrecios = true;
        }
    }

    public void OpenListNormativas()
    {
        if (DialogueManager.Instance.listOpenNormativas)
        {
            DialogueManager.Instance.buttonCobrar.SetActive(true);
            DialogueManager.Instance.buttonNoCobrar.SetActive(true);
            DialogueManager.Instance.dropDownPanelNormativas.transform.position = DialogueManager.Instance.position2Normativas.transform.position;
            DialogueManager.Instance.botonDesplegadoNormativas.SetActive(true);
            DialogueManager.Instance.botonPlegadoNormativas.SetActive(false);
            DialogueManager.Instance.listOpenNormativas = false;
        }

        else
        {
            DialogueManager.Instance.buttonCobrar.SetActive(false);
            DialogueManager.Instance.buttonNoCobrar.SetActive(false);
            DialogueManager.Instance.dropDownPanelNormativas.transform.position = DialogueManager.Instance.position1Normativas.transform.position;
            DialogueManager.Instance.botonDesplegadoNormativas.SetActive(false);
            DialogueManager.Instance.botonPlegadoNormativas.SetActive(true);
            DialogueManager.Instance.listOpenNormativas = true;
        }
    }

    public void RetrocederRaza()
    {
        DialogueManager.Instance.razaSeleccionada = (DialogueManager.Instance.razaSeleccionada - 1 + DialogueManager.Instance.razasNormas.Length) % DialogueManager.Instance.razasNormas.Length;

        DialogueManager.Instance.textoRaza.text = DialogueManager.Instance.razasNormas[DialogueManager.Instance.razaSeleccionada];

        if (DialogueManager.Instance.textoRaza.text == "Magos Oscuros")
        {
            DialogueManager.Instance.panelMagos.SetActive(true);
            DialogueManager.Instance.panelElementales.SetActive(false);
            DialogueManager.Instance.panelHibridos.SetActive(false);
            DialogueManager.Instance.panelLimbasticos.SetActive(false);
            DialogueManager.Instance.panelTecnopedos.SetActive(false);
        }

        else if (DialogueManager.Instance.textoRaza.text == "Elementales")
        {
            DialogueManager.Instance.panelMagos.SetActive(false);
            DialogueManager.Instance.panelElementales.SetActive(true);
            DialogueManager.Instance.panelHibridos.SetActive(false);
            DialogueManager.Instance.panelLimbasticos.SetActive(false);
            DialogueManager.Instance.panelTecnopedos.SetActive(false);
        }

        else if (DialogueManager.Instance.textoRaza.text == "Híbridos")
        {
            DialogueManager.Instance.panelMagos.SetActive(false);
            DialogueManager.Instance.panelElementales.SetActive(false);
            DialogueManager.Instance.panelHibridos.SetActive(true);
            DialogueManager.Instance.panelLimbasticos.SetActive(false);
            DialogueManager.Instance.panelTecnopedos.SetActive(false);
        }

        else if (DialogueManager.Instance.textoRaza.text == "Limbásticos")
        {
            DialogueManager.Instance.panelMagos.SetActive(false);
            DialogueManager.Instance.panelElementales.SetActive(false);
            DialogueManager.Instance.panelHibridos.SetActive(false);
            DialogueManager.Instance.panelLimbasticos.SetActive(true);
            DialogueManager.Instance.panelTecnopedos.SetActive(false);
        }

        else if (DialogueManager.Instance.textoRaza.text == "Tecno P2")
        {
            DialogueManager.Instance.panelMagos.SetActive(false);
            DialogueManager.Instance.panelElementales.SetActive(false);
            DialogueManager.Instance.panelHibridos.SetActive(false);
            DialogueManager.Instance.panelLimbasticos.SetActive(false);
            DialogueManager.Instance.panelTecnopedos.SetActive(true);
        }
    }

    public void AvanzarRaza()
    {
        DialogueManager.Instance.razaSeleccionada = (DialogueManager.Instance.razaSeleccionada + 1) % DialogueManager.Instance.razasNormas.Length;

        DialogueManager.Instance.textoRaza.text = DialogueManager.Instance.razasNormas[DialogueManager.Instance.razaSeleccionada];

        if (DialogueManager.Instance.textoRaza.text == "Magos Oscuros")
        {
            DialogueManager.Instance.panelMagos.SetActive(true);
            DialogueManager.Instance.panelElementales.SetActive(false);
            DialogueManager.Instance.panelHibridos.SetActive(false);
            DialogueManager.Instance.panelLimbasticos.SetActive(false);
            DialogueManager.Instance.panelTecnopedos.SetActive(false);
        }

        else if (DialogueManager.Instance.textoRaza.text == "Elementales")
        {
            DialogueManager.Instance.panelMagos.SetActive(false);
            DialogueManager.Instance.panelElementales.SetActive(true);
            DialogueManager.Instance.panelHibridos.SetActive(false);
            DialogueManager.Instance.panelLimbasticos.SetActive(false);
            DialogueManager.Instance.panelTecnopedos.SetActive(false);
        }

        else if (DialogueManager.Instance.textoRaza.text == "Híbridos")
        {
            DialogueManager.Instance.panelMagos.SetActive(false);
            DialogueManager.Instance.panelElementales.SetActive(false);
            DialogueManager.Instance.panelHibridos.SetActive(true);
            DialogueManager.Instance.panelLimbasticos.SetActive(false);
            DialogueManager.Instance.panelTecnopedos.SetActive(false);
        }

        else if (DialogueManager.Instance.textoRaza.text == "Limbásticos")
        {
            DialogueManager.Instance.panelMagos.SetActive(false);
            DialogueManager.Instance.panelElementales.SetActive(false);
            DialogueManager.Instance.panelHibridos.SetActive(false);
            DialogueManager.Instance.panelLimbasticos.SetActive(true);
            DialogueManager.Instance.panelTecnopedos.SetActive(false);
        }

        else if (DialogueManager.Instance.textoRaza.text == "Tecno P2")
        {
            DialogueManager.Instance.panelMagos.SetActive(false);
            DialogueManager.Instance.panelElementales.SetActive(false);
            DialogueManager.Instance.panelHibridos.SetActive(false);
            DialogueManager.Instance.panelLimbasticos.SetActive(false);
            DialogueManager.Instance.panelTecnopedos.SetActive(true);
        }
    }
    #endregion
}
