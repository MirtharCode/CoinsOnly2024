using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;

public class ClientManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speakerRaceTextBox;
    [SerializeField] TextMeshProUGUI speakerTextBox;
    [SerializeField] TextMeshProUGUI dialogueTextBoxFirst;
    [SerializeField] TextMeshProUGUI dialogueTextBoxOther;
    [SerializeField] GameObject musicBox;
    [SerializeField] public string lastRaceMusic = "Desconocida";
    [SerializeField] public string lastNameMusic;
    [SerializeField] GameObject currentClient;
    [SerializeField] Image miniImage;
    [SerializeField] public Transform showUpPoint;


    private float timer = .5f;

    public DialogueManager.DailyClientInfo currentDialogueClient;
    [SerializeField] public int clientDialogueLineIndex = 0;
    private bool dialogueReady = false;
    private bool showingDialogue = false;
    public bool iWantToBelieve = false;
    public bool noWayJose = false;
    private bool cobrasteBien = false;
    private bool cobrasteMal = false;
    private bool teTocaBronca = false;
    private bool meVoyAMinijuego = false;
    //private bool imBW = false;

    public bool day03client5DenjirenjiMinigameChecked;
    public bool day05client6DenjirenjiMinigameChecked;
    public bool day04client6ElidoraMinigameChecked;
    public bool day05client4AltChecked;
    public bool day06client3DialogueChangedChecked;
    public bool day06client7DialogueChangedChecked;
    public bool day06client8DialogueChangedChecked;
    public bool day07client5AltChecked;
    public bool day07client7DialogueChangedChecked;
    public bool day07client10AltChecked;

    public string selectedSuspect;

    [SerializeField] private Material grayscaleMaterial;

    // MENSAJES DE LOS TROFEOS
    private static readonly Dictionary<string, string> TrophyMessages = new Dictionary<string, string>
{
    { "Antonio", "¡Gafas Otaku \nDesbloqueadas!" },
    { "Cululu", "¡Foto Tinder \nDesbloqueada!" },
    { "Denjirenji", "¡Katana \nLáser \nDesbloqueada!" },
    { "Elidora", "¡Mc Moco \nDesbloqueado!" },
    { "Elvog", "¡Flores \nen Vodka \nDesbloqueadas!" },
    { "Manomo", "¡Elena Nito \nDesbloqueado!" },
    { "Geeraard", "¡Foto to wapa \nDesbloqueada!" },
    { "Giovanni", "¡Libro Gordo \nDesbloqueado!" },
    { "Terry", "¡Traje \nde los \nDomingos \nDesbloqueado!" },
    { "Manolo", "¡El sellaso \nDesbloqueado!" },
    { "Mara", "¡Trozo de \nex-marido \nDesbloqueado!" },
    { "Petra", "¡Mapa de \nAlbacete \nDesbloqueado!" },
    { "RaveN", "¡Disco de \nlos Mojinos \nDesbloqueado!" },
    { "Sergio", "¡La \nGloboespada \nDesbloqueada!" },
    { "Tapicio", "¡El GOTY \nDesbloqueado!" }

};


    private void Start()
    {
        RegulationsActivate();

        if (DialogueManager.Instance.currentDay != "01")
        {
            DialogueManager.Instance.mainCam.GetComponent<Animator>().enabled = false;
            DialogueManager.Instance.mainCam.transform.GetChild(0).gameObject.SetActive(false);
            DialogueManager.Instance.dialoguePanelFirst.gameObject.SetActive(false);

            speakerRaceTextBox = DialogueManager.Instance.dialoguePanelOtherRaceText.GetComponent<TextMeshProUGUI>();
            speakerTextBox = DialogueManager.Instance.dialoguePanelOtherNameText.GetComponent<TextMeshProUGUI>();
            StartMusicSetup();
            Invoke(nameof(StartNextClient), timer);


            if ((int.Parse(DialogueManager.Instance.currentDay) == 2))
                DialogueManager.Instance.gnomeFog1.SetActive(true);

            if ((int.Parse(DialogueManager.Instance.currentDay) >= 4))
            {
                DialogueManager.Instance.zoomTargetCoupon.SetActive(true);

                if (DialogueManager.Instance.currentDay == "04")
                {
                    ShowCouponInfo("toother");
                    DialogueManager.Instance.gnomeFog2.SetActive(true);
                }

                else if (DialogueManager.Instance.currentDay == "05")
                    ShowCouponInfo("geomery");
                else if (DialogueManager.Instance.currentDay == "06")
                    ShowCouponInfo("drakerry");
                else if (DialogueManager.Instance.currentDay == "07")
                    ShowCouponInfo("dogelle");
            }
        }

        else
        {
            speakerRaceTextBox = DialogueManager.Instance.dialoguePanelFirstRaceText.GetComponent<TextMeshProUGUI>();
            speakerTextBox = DialogueManager.Instance.dialoguePanelFirstNameText.GetComponent<TextMeshProUGUI>();
            DialogueManager.Instance.dialoguePanelOther.gameObject.SetActive(false);
            StartMusicSetup();
            StartNextClient();
            DialogueManager.Instance.dialoguePanelFirstDialogueText.GetComponent<TextMeshProUGUI>().text = "¡CÓGEME!";
            DialogueManager.Instance.dialoguePanelFirstDialogueText.GetComponent<TextMeshProUGUI>().fontSize = 220;
        }
    }
    void Update()
    {
        if (!dialogueReady && DialogueManager.Instance.IsReady)
        {
            dialogueReady = true;
            Debug.Log("Diálogos listos.");
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            DialogueManager.Instance.racePanel.GetComponent<RacePanelScript>().PlayPanelAnimation(1);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            DialogueManager.Instance.racePanel.GetComponent<RacePanelScript>().PlayPanelAnimation(-1);
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
        AltDialogues(DialogueManager.Instance.currentDay);
        DialogueManager.Instance.LaVoluntad(0);
        DialogueManager.Instance.jefePanel.GetComponent<Image>().enabled = false;
        DialogueManager.Instance.jefePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;

        //if (DialogueManager.Instance.dailyCustomers.Count == 0 && SceneManager.GetActiveScene().name != "DD" && imBW)
        //{
        //    imBW = false;
        //    DialogueManager.Instance.bAndWShader.GetComponent<ScreenEffectFader>().FadeOut();
        //}

        if (DialogueManager.Instance.dailyCustomers.Count == 0)
        {
            dialogueReady = false;
            Debug.Log("Todos los clientes han sido atendidos.");
            DialogueManager.Instance.lastSceneWithDialogues = "";

            if (!DialogueManager.Instance.theGnomeIsFree)
                GoingHome(DialogueManager.Instance.currentDay);
            else
            {
                int diaActual;

                if (!int.TryParse(DialogueManager.Instance.currentDay, out diaActual))
                {
                    Debug.LogError($"Nombre de escena inválido: {DialogueManager.Instance.currentDay}");
                    return;
                }
                DialogueManager.Instance.gnomeMinigameCanvas.transform.GetChild(diaActual - 2).GetComponent<NewGnomeScript>().GnomeFleeing();
            }


            //SceneManager.LoadScene("FM");
            return;
        }


        currentDialogueClient = DialogueManager.Instance.dailyCustomers[0];
        clientDialogueLineIndex = 0;

        CharacterShowUp(DialogueManager.Instance.clientPrefab);
        ChangingSprite(currentDialogueClient.race, currentDialogueClient.name, currentDialogueClient.dialogueLines[0].mood);

        if (currentDialogueClient.name == "Detective")
            StartCoroutine(nameof(DialogueManager.Instance.ChangeSaturation));


        showingDialogue = true;
        MostrarDialogoActual();
        ChangeTheMusic(currentDialogueClient.race, currentDialogueClient.name);
    }

    private IEnumerator ChangeSaturation()
    {
        float startValue = 15f;
        float endValue = -100f;
        float duration = 1.5f;

        if (DialogueManager.Instance.postPro_Profile.TryGet(out ColorAdjustments color))
        {
            float elapsed = 0f;
            float initial = startValue;
            color.saturation.value = initial;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duration;
                color.saturation.value = Mathf.Lerp(initial, endValue, t);
                yield return null;
            }
        }
    }

    #region MÚSICA

    public void StartMusicSetup()
    {
        // Activar música base
        AudioSource baseTrack = musicBox.GetComponent<AudioSource>();
        baseTrack.volume = 0.1f;
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

    private IEnumerator FadeIn(AudioSource audioSource, float duration, float targetVolume = .17f)
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
            //if (currentDialogueClient.name == "Mikujefe" && currentDialogueClient.clientID == "clientFINAL" && DialogueManager.Instance.currentDay == "DD")
            //{
            //    StartCoroutine(FadeIn(musicBox.GetComponent<AudioSource>(), fadeDuration));
            //    StartCoroutine(FadeOut(musicBox.transform.GetChild(5).GetComponent<AudioSource>(), fadeDuration));
            //    StartCoroutine(FadeFromGrayscale(grayscaleMaterial, 2f));
            //}
            if (currentDialogueClient.name == "Detective")
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
            if (currentDialogueClient.dialogueLines[clientDialogueLineIndex - 1].extra.Contains("camera"))
            {
                if (currentDialogueClient.dialogueLines[clientDialogueLineIndex - 1].extra == "cameraPrices")
                    TutorialZoomIns(DialogueManager.Instance.zoomTargetPrices);

                else if (currentDialogueClient.dialogueLines[clientDialogueLineIndex - 1].extra == "cameraRegulations")
                    TutorialZoomIns(DialogueManager.Instance.zoomTargetRegulations);

                else if (currentDialogueClient.dialogueLines[clientDialogueLineIndex - 1].extra == "cameraCoupons")
                    TutorialZoomIns(DialogueManager.Instance.zoomTargetCoupon);
            }

            if (currentDialogueClient.dialogueLines[clientDialogueLineIndex - 1].type == "mgIN")
            {
                meVoyAMinijuego = true;
                showingDialogue = false;
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

    public void GoingToMinigame(string sceneName, string day)
    {
        DialogueManager.Instance.lastSceneWithDialogues = DialogueManager.Instance.currentDay;

        if (sceneName == "Denjirenji")
            SceneManager.LoadScene(sceneName + day);

        else
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
            speakerTextBox.text = currentDialogueClient.name.ToUpper();

            ChangingDialogue(line.text);

            if (clientDialogueLineIndex != 0)
                Speaking(line.tone);

            ChangingSprite(currentDialogueClient.race, currentDialogueClient.name, line.mood);

            if (line.extra == "collectable")
                TrophyAchieved(currentDialogueClient.name);

            if (line.type == "gnome")
            {
                DialogueManager.Instance.theGnomeIsFree = true;
                GnomeOut(DialogueManager.Instance.currentDay);
            }

            clientDialogueLineIndex++;
        }

        else
        {
            speakerRaceTextBox.text = currentDialogueClient.race;
            speakerTextBox.text = currentDialogueClient.name;

            if (iWantToBelieve)
            {
                ChangingDialogue(currentDialogueClient.tickResponse[0].text);
                Speaking(currentDialogueClient.tickResponse[0].tone);
                ChangingSprite(currentDialogueClient.race, currentDialogueClient.name, currentDialogueClient.tickResponse[0].mood);

                if (currentDialogueClient.tickResponse[0].extra == "collectable")
                    TrophyAchieved(currentDialogueClient.name);
            }

            else if (noWayJose)
            {
                ChangingDialogue(currentDialogueClient.crossResponse[0].text);
                Speaking(currentDialogueClient.crossResponse[0].tone);
                ChangingSprite(currentDialogueClient.race, currentDialogueClient.name, currentDialogueClient.crossResponse[0].mood);

                if (currentDialogueClient.crossResponse[0].extra == "collectable")
                    TrophyAchieved(currentDialogueClient.name);
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
        DialogueManager.Instance.dialoguePanelOther.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
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
        string eleccionDetective;

        if (selectedSuspect == currentDialogueClient.correctAnswer)
        {
            eleccionDetective = DialogueManager.Instance.currentDay + currentDialogueClient.name + "YES";
        }

        else
        {
            eleccionDetective = DialogueManager.Instance.currentDay + currentDialogueClient.name + "NOP";
        }

        DialogueManager.Instance.chosenChecks.Add(eleccionDetective);
        DialogueManager.Instance.areYouSurePanel.SetActive(false);
        DialogueManager.Instance.detectivePanel.SetActive(false);
        DialogueManager.Instance.dialoguePanelOther.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
        speakerTextBox.text = currentDialogueClient.name;
        MostrarDialogoActual();
    }

    public void IChangeMyMind()
    {
        DialogueManager.Instance.areYouSurePanel.SetActive(false);
        selectedSuspect = "";
    }

    #endregion

    void FinishCurrentClient()
    {
        DialogueManager.Instance.HideText();

        if (currentDialogueClient.numberOfProducts == 0 || cobrasteBien || cobrasteMal)
        {
            if (currentClient != null)
            {
                currentClient.GetComponent<BoxCollider2D>().enabled = false;

                //if (currentDialogueClient.dialogueLines[clientDialogueLineIndex - 1].type == "gnome")
                //{
                //    DialogueManager.Instance.theGnomeIsFree = true;
                //    GnomeOut(DialogueManager.Instance.currentDay);
                //}

            }

            cobrasteBien = false;
            cobrasteMal = false;

            if (!teTocaBronca)
            {
                if (DialogueManager.Instance.dailyCustomers.Count > 0 && !meVoyAMinijuego)
                {
                    Destroy(currentClient, 2);
                    DialogueManager.Instance.dailyCustomers.RemoveAt(0);
                    Invoke(nameof(StartNextClient), 1);
                }

                else
                    GoingToMinigame(currentDialogueClient.name, DialogueManager.Instance.currentDay);
            }

            else
            {
                teTocaBronca = false;

                if (currentDialogueClient.bossComplainsCheckWrong != "")
                    StartCoroutine(BossCalling(currentDialogueClient.bossComplainsCheckWrong));
                else
                    StartCoroutine(BossCalling(currentDialogueClient.bossComplainsByeWrong));

                Destroy(currentClient, 2);

                if (DialogueManager.Instance.dailyCustomers.Count > 0)
                    DialogueManager.Instance.dailyCustomers.RemoveAt(0);


                Invoke(nameof(StartNextClient), 2.5f);
            }
            ControlarMovimientoTablet("Bloquear");
        }

        else
        {
            ControlarMovimientoTablet("Bloquear");
            ShowProducts(currentDialogueClient, currentDialogueClient.numberOfProducts);
            RacePanelUP();
        }

    }

    public IEnumerator BossCalling(string bossComplain)
    {
        // Ya no existe el teléfono
        //DialogueManager.Instance.phone.gameObject.GetComponent<Animator>().SetBool("LlamaJefe", true);

        yield return new WaitForSeconds(.5f);

        //DialogueManager.Instance.phone.gameObject.GetComponent<Animator>().SetBool("LlamaJefe", false);

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

    //public void ChangingMiniSprite(string clientName)
    //{
    //    Sprite loaded = Resources.Load<Sprite>($"Sprites/MiniImages/{clientName}");

    //    if (loaded == null)
    //        Debug.LogError($"¡No se pudo cargar el sprite en: Sprites/MiniImages/{clientName}!");

    //    else
    //        miniImage.sprite = loaded;
    //}

    public void CharacterShowUp(GameObject character)
    {
        currentClient = Instantiate(character, showUpPoint);
    }

    public void ShowProducts(DialogueManager.DailyClientInfo client, int numProducts)
    {
        DialogueManager.Instance.leDinero.SetActive(true);
        DialogueManager.Instance.buttonCobrar.GetComponent<CobrarCuerda>().ActivateTouch();
        DialogueManager.Instance.buttonNoCobrar.GetComponent<NoCobrarCuerda>().ActivateTouch();
        DialogueManager.Instance.leDineroSymbol.SetActive(true);
        DialogueManager.Instance.leDineroText.gameObject.SetActive(true);
        DialogueManager.Instance.leDineroText.text = client.clientMoney.ToString();
        DialogueManager.Instance.mainCam.GetComponent<EdgeScrollCamera>().ReturnToMove();
        DialogueManager.Instance.mainCam.GetComponent<CameraZoomManager>().ReturnToMove();

        Sprite loaded1 = Resources.Load<Sprite>($"Sprites/Products/{client.productTypes[2]}");

        if (loaded1 == null)
            Debug.LogError($"¡No se pudo cargar el sprite en: Sprites/Products/{client.productTypes[2]}!");

        else
        {
            DialogueManager.Instance.centralProduct.GetComponent<SpriteRenderer>().sprite = loaded1;
            DialogueManager.Instance.centralProduct.GetComponent<SpriteRenderer>().enabled = true;

            if (numProducts > 1)
            {
                Sprite loaded2 = Resources.Load<Sprite>($"Sprites/Products/{client.productTypes[1]}");

                if (loaded2 == null)
                    Debug.LogError($"¡No se pudo cargar el sprite en: Sprites/Products/{client.productTypes[1]}!");

                else
                {
                    DialogueManager.Instance.rightProduct.GetComponent<SpriteRenderer>().sprite = loaded2;
                    DialogueManager.Instance.rightProduct.GetComponent<SpriteRenderer>().enabled = true;

                    if (numProducts == 3)
                    {
                        Sprite loaded3 = Resources.Load<Sprite>($"Sprites/Products/{client.productTypes[0]}");

                        if (loaded3 == null)
                            Debug.LogError($"¡No se pudo cargar el sprite en: Sprites/Products/{client.productTypes[0]}!");

                        else
                        {
                            DialogueManager.Instance.leftProduct.GetComponent<SpriteRenderer>().sprite = loaded3;
                            DialogueManager.Instance.leftProduct.GetComponent<SpriteRenderer>().enabled = true;
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
                DialogueManager.Instance.couponPlace.GetComponent<SpriteRenderer>().sprite = loadedCoupon;
                DialogueManager.Instance.couponPlace.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    public void TimeToCharge()
    {
        string eleccionCliente = "";
        RacePanelDOWN();

        if (iWantToBelieve)
        {
            DialogueManager.Instance.LaVoluntad(currentDialogueClient.tipsIfCheck);

            if (currentDialogueClient.correctChoice == "TICK")
            {
                cobrasteBien = true;

                eleccionCliente = DialogueManager.Instance.currentDay + currentDialogueClient.name + "YES";
            }


            else
            {
                cobrasteMal = true;
                teTocaBronca = true;

                eleccionCliente = DialogueManager.Instance.currentDay + currentDialogueClient.name + "NOP";
            }

        }

        else if (noWayJose)
        {
            DialogueManager.Instance.LaVoluntad(currentDialogueClient.tipsIfBye);

            if (currentDialogueClient.correctChoice == "CROSS")
            {
                cobrasteBien = true;

                eleccionCliente = DialogueManager.Instance.currentDay + currentDialogueClient.name + "YES";
            }


            else
            {
                cobrasteMal = true;
                teTocaBronca = true;

                eleccionCliente = DialogueManager.Instance.currentDay + currentDialogueClient.name + "NOP";
            }
        }

        DialogueManager.Instance.chosenChecks.Add(eleccionCliente);

        ControlarMovimientoTablet("Activar");

        DialogueManager.Instance.ShowText();
        MostrarDialogoActual();
        DialogueManager.Instance.leDinero.SetActive(false);
        DialogueManager.Instance.buttonCobrar.GetComponent<CobrarCuerda>().DeactivateTouch();
        DialogueManager.Instance.buttonNoCobrar.GetComponent<NoCobrarCuerda>().DeactivateTouch();
        DialogueManager.Instance.leDineroSymbol.SetActive(false);
        DialogueManager.Instance.leDineroText.gameObject.SetActive(false);
        DialogueManager.Instance.centralProduct.GetComponent<SpriteRenderer>().enabled = false;
        DialogueManager.Instance.rightProduct.GetComponent<SpriteRenderer>().enabled = false;
        DialogueManager.Instance.leftProduct.GetComponent<SpriteRenderer>().enabled = false;
        DialogueManager.Instance.couponPlace.GetComponent<SpriteRenderer>().enabled = false;

    }

    public void IWantToBelieve()
    {
        iWantToBelieve = true;
    }

    public void NoWayJose()
    {
        noWayJose = true;
    }

    public void GoingHome(string sceneName)
    {
        DialogueManager.Instance.propinasNumber = 0; // Seteo en 0 el número de propinas para el día siguiente

        int diaActual;

        if (!int.TryParse(sceneName, out diaActual))
        {
            Debug.LogError($"Nombre de escena inválido: {sceneName}");
            return;
        }

        string diaPasado = (diaActual - 1).ToString("D2");

        // Construir el nombre del bool según el nombre de la escena
        string boolToActivate = $"day{sceneName}Checked";
        string boolToDeactivate = $"day{diaPasado}Checked";

        // Obtener el campo por reflexión
        FieldInfo field01 = typeof(Data).GetField(boolToDeactivate, BindingFlags.Instance | BindingFlags.Public);
        FieldInfo field02 = typeof(Data).GetField(boolToActivate, BindingFlags.Instance | BindingFlags.Public);

        if (field01 != null && field01.FieldType == typeof(bool))
        {
            field01.SetValue(Data.instance, false);
            Debug.Log($" Activado: {boolToDeactivate}");
        }
        else
            Debug.LogWarning($" No se encontró el bool llamado '{boolToActivate}' en Data");

        if (field02 != null && field02.FieldType == typeof(bool))
        {
            field02.SetValue(Data.instance, true);
            Debug.Log($" Activado: {boolToActivate}");
        }
        else
            Debug.LogWarning($" No se encontró el bool llamado '{boolToActivate}' en Data");

        DialogueManager.Instance.currentDay = (diaActual + 1).ToString("D2");
        // Cargar la escena Home
        SceneManager.LoadScene("Home");
    }

    public void AltDialogues(string day)
    {
        switch (day)
        {
            case "01":
                break;

            case "02":
                break;

            case "03":
                if (!day03client5DenjirenjiMinigameChecked)
                {
                    if (Data.instance.samuraiAyudado1)
                    {
                        for (int i = 0; i < DialogueManager.Instance.dailyCustomers.Count; i++)
                        {
                            if (DialogueManager.Instance.dailyCustomers[i].clientID == "clientFIVE")
                            {
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Clear();
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Add(DialogueManager.Instance.dailyCustomers[i].mgGoodResponse[0]);
                                day03client5DenjirenjiMinigameChecked = true;
                            }
                        }
                    }

                    else if (Data.instance.meExplotasteElCulo1)
                    {
                        for (int i = 0; i < DialogueManager.Instance.dailyCustomers.Count; i++)
                        {
                            if (DialogueManager.Instance.dailyCustomers[i].clientID == "clientFIVE")
                            {
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Clear();
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Add(DialogueManager.Instance.dailyCustomers[i].mgBadResponse[0]);
                                day03client5DenjirenjiMinigameChecked = true;
                            }
                        }
                    }
                }
                break;

            case "04":

                if (!day04client6ElidoraMinigameChecked)
                {
                    if (Data.instance.slimeFail)
                    {
                        for (int i = 0; i < DialogueManager.Instance.dailyCustomers.Count; i++)
                        {
                            if (DialogueManager.Instance.dailyCustomers[i].clientID == "clientSIX")
                            {
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Clear();
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Add(DialogueManager.Instance.dailyCustomers[i].mgBadResponse[0]);
                                day04client6ElidoraMinigameChecked = true;
                            }
                        }
                    }

                    else if (Data.instance.slimeFostiados)
                    {
                        for (int i = 0; i < DialogueManager.Instance.dailyCustomers.Count; i++)
                        {
                            if (DialogueManager.Instance.dailyCustomers[i].clientID == "clientSIX")
                            {
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Clear();
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Add(DialogueManager.Instance.dailyCustomers[i].mgGoodResponse[0]);
                                day04client6ElidoraMinigameChecked = true;
                            }
                        }
                    }

                    else if (Data.instance.elidoraAcariciada)
                    {
                        for (int i = 0; i < DialogueManager.Instance.dailyCustomers.Count; i++)
                        {
                            if (DialogueManager.Instance.dailyCustomers[i].clientID == "clientSIX")
                            {
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Clear();
                                string dialogueChanged = "¡Casi me abollas el cerebro!¡Escucho borroso!¡NUNCA TE LO PERDONARÉ CARMONA!";
                                DialogueManager.Instance.dailyCustomers[i].mgBadResponse[0].text = dialogueChanged;
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Add(DialogueManager.Instance.dailyCustomers[i].mgBadResponse[0]);
                                day04client6ElidoraMinigameChecked = true;
                            }
                        }
                    }
                }
                break;

            case "05":

                if (!day05client4AltChecked)
                {
                    for (int i = 0; i < DialogueManager.Instance.chosenChecks.Count; i++)
                    {
                        if (DialogueManager.Instance.chosenChecks[i] == "05SergioYES")
                        {
                            for (int j = 0; j < DialogueManager.Instance.dailyCustomers.Count; j++)
                            {
                                if (DialogueManager.Instance.dailyCustomers[j].clientID == "clientFOURalt")
                                    DialogueManager.Instance.dailyCustomers.Remove(DialogueManager.Instance.dailyCustomers[j]);
                            }

                            day05client4AltChecked = true;
                        }

                        else if (DialogueManager.Instance.chosenChecks[i] == "05SergioNOP")
                        {
                            for (int j = 0; j < DialogueManager.Instance.dailyCustomers.Count; j++)
                            {
                                if (DialogueManager.Instance.dailyCustomers[j].clientID == "clientFOUR")
                                    DialogueManager.Instance.dailyCustomers.Remove(DialogueManager.Instance.dailyCustomers[j]);
                            }

                            day05client4AltChecked = true;
                        }
                    }
                }

                if (!day05client6DenjirenjiMinigameChecked)
                {
                    if (Data.instance.samuraiAyudado2)
                    {
                        for (int i = 0; i < DialogueManager.Instance.dailyCustomers.Count; i++)
                        {
                            if (DialogueManager.Instance.dailyCustomers[i].clientID == "clientSIX")
                            {
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Clear();
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Add(DialogueManager.Instance.dailyCustomers[i].mgGoodResponse[0]);

                                if (!Data.instance.samuraiAyudado1)
                                {
                                    string dialogueChanged = "Aún tengo secuelas de la otra vez, pero agradezco tu esfuerzo en esta ocasión.";
                                    DialogueManager.Instance.dailyCustomers[i].dialogueLines[0].text = dialogueChanged;
                                    DialogueManager.Instance.dailyCustomers[i].dialogueLines[0].extra = "";
                                }

                                day05client6DenjirenjiMinigameChecked = true;
                            }
                        }
                    }

                    else if (Data.instance.meExplotasteElCulo2)
                    {
                        for (int i = 0; i < DialogueManager.Instance.dailyCustomers.Count; i++)
                        {
                            if (DialogueManager.Instance.dailyCustomers[i].clientID == "clientSIX")
                            {
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Clear();
                                DialogueManager.Instance.dailyCustomers[i].dialogueLines.Add(DialogueManager.Instance.dailyCustomers[i].mgBadResponse[0]);
                                day05client6DenjirenjiMinigameChecked = true;
                            }
                        }
                    }
                }
                break;

            case "06":

                if (!day06client3DialogueChangedChecked)
                {
                    for (int i = 0; i < DialogueManager.Instance.chosenChecks.Count; i++)
                    {
                        if (DialogueManager.Instance.chosenChecks[i] == "02CululuYES" || DialogueManager.Instance.chosenChecks[i] == "04CululuYES")
                        {
                            Data.instance.vecesCobradoCululu++;

                            day06client3DialogueChangedChecked = true;
                        }
                    }

                    if (Data.instance.vecesCobradoCululu == 2)
                    {
                        string dialogueChanged = "Gracias amigo, ahora que quiero olvidarla, toma esta foto de ella, no la necesitaré más.";
                        DialogueManager.Instance.dailyCustomers[3].tickResponse[0].text = dialogueChanged;
                    }
                }

                else if (!day06client7DialogueChangedChecked)
                {
                    for (int i = 0; i < DialogueManager.Instance.chosenChecks.Count; i++)
                    {
                        if (DialogueManager.Instance.chosenChecks[i] == "02Rave-NYES" || DialogueManager.Instance.chosenChecks[i] == "03Rave-NYES")
                        {
                            Data.instance.vecesCobradoRaven++;

                            day06client7DialogueChangedChecked = true;
                        }
                    }

                    if (Data.instance.vecesCobradoRaven == 2)
                    {
                        string dialogueChanged = "¡Eres el mejor! Creo que necesitas un poco de mi magia, coge este disco de mi grupo favorito, ¡TE ENCANTARÁ!";
                        DialogueManager.Instance.dailyCustomers[7].tickResponse[0].text = dialogueChanged;
                    }
                }

                else if (!day06client8DialogueChangedChecked)
                {
                    for (int i = 0; i < DialogueManager.Instance.chosenChecks.Count; i++)
                    {
                        if (DialogueManager.Instance.chosenChecks[i] == "02TerryNOP" || DialogueManager.Instance.chosenChecks[i] == "04TerryNOP")
                        {
                            Data.instance.vecesCobradaTerry++;

                            day06client8DialogueChangedChecked = true;
                        }
                    }

                    if (Data.instance.vecesCobradaTerry == 2)
                    {
                        string dialogueChanged = "De verdad que eres el mejor, puede que no te haya visto en muchas fiestas, pero creo que este traje te sentará bien.";
                        DialogueManager.Instance.dailyCustomers[8].tickResponse[0].text = dialogueChanged;
                    }
                }
                break;

            case "07":
                if (!day07client5AltChecked)
                {
                    for (int i = 0; i < DialogueManager.Instance.chosenChecks.Count; i++)
                    {
                        if (DialogueManager.Instance.chosenChecks[i] == "05ElvogYES")
                        {
                            for (int j = 0; j < DialogueManager.Instance.dailyCustomers.Count; j++)
                            {
                                if (DialogueManager.Instance.dailyCustomers[j].clientID == "clientFIVEalt")
                                    DialogueManager.Instance.dailyCustomers.Remove(DialogueManager.Instance.dailyCustomers[j]);
                            }

                            day07client5AltChecked = true;
                        }

                        else if (DialogueManager.Instance.chosenChecks[i] == "05ElvogNOP")
                        {
                            for (int j = 0; j < DialogueManager.Instance.dailyCustomers.Count; j++)
                            {
                                if (DialogueManager.Instance.dailyCustomers[j].clientID == "clientFIVE")
                                    DialogueManager.Instance.dailyCustomers.Remove(DialogueManager.Instance.dailyCustomers[j]);
                            }

                            day07client5AltChecked = true;
                        }
                    }
                }

                else if (!day07client7DialogueChangedChecked)
                {
                    for (int i = 0; i < DialogueManager.Instance.chosenChecks.Count; i++)
                    {
                        if (DialogueManager.Instance.chosenChecks[i] == "01MaraYES" || DialogueManager.Instance.chosenChecks[i] == "04MaraNOP")
                        {
                            Data.instance.vecesCobradaMara++;

                            day07client7DialogueChangedChecked = true;
                        }
                    }

                    if (Data.instance.vecesCobradaMara == 2)
                    {
                        string dialogueChanged = "De verdad que eres el mejor, puede que no te haya visto en muchas fiestas, pero creo que este traje te sentará bien.";
                        DialogueManager.Instance.dailyCustomers[7].tickResponse[0].text = dialogueChanged;
                    }

                    else
                        DialogueManager.Instance.dailyCustomers[7].tickResponse[4].text = "";
                }

                else if (!day07client10AltChecked)
                {
                    for (int i = 0; i < DialogueManager.Instance.chosenChecks.Count; i++)
                    {
                        if (DialogueManager.Instance.chosenChecks[i] == "06PatxiYES")
                        {
                            for (int j = 0; j < DialogueManager.Instance.dailyCustomers.Count; j++)
                            {
                                if (DialogueManager.Instance.dailyCustomers[j].clientID == "clientTENalt")
                                    DialogueManager.Instance.dailyCustomers.Remove(DialogueManager.Instance.dailyCustomers[j]);
                            }

                            day07client10AltChecked = true;
                        }

                        else if (DialogueManager.Instance.chosenChecks[i] == "06PatxiNOP")
                        {
                            for (int j = 0; j < DialogueManager.Instance.dailyCustomers.Count; j++)
                            {
                                if (DialogueManager.Instance.dailyCustomers[j].clientID == "clientNOP")
                                    DialogueManager.Instance.dailyCustomers.Remove(DialogueManager.Instance.dailyCustomers[j]);
                            }

                            day07client10AltChecked = true;
                        }
                    }
                }
                break;

        }
    }

    public void GnomeOut(string day)
    {
        switch (day)
        {
            case "02":
                DialogueManager.Instance.gnomeMinigameCanvas.transform.GetChild(0).gameObject.SetActive(true);
                DialogueManager.Instance.gnomeMinigameCanvas.transform.GetChild(0).GetComponent<Animator>().SetBool("oneAppeared", true);
                break;

            case "04":
                DialogueManager.Instance.gnomeMinigameCanvas.transform.GetChild(1).gameObject.SetActive(true);
                DialogueManager.Instance.gnomeMinigameCanvas.transform.GetChild(1).GetComponent<Animator>().SetBool("threeAppeared", true);
                break;

            case "06":
                DialogueManager.Instance.gnomeMinigameCanvas.transform.GetChild(2).gameObject.SetActive(true);
                break;
        }
    }

    #region CÓDIGO ANTIGUO REFERENTE A LOS DESPLEGABLES DE NORMATIVAS Y PRECIOS QUE CAMBIARÁN

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

    public void TrophyAchieved(string trophyName)
    {
        DialogueManager.Instance.uITrophies.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/TrophyImages/{trophyName}");

        #region ACTIVAR EL BOOLEANO DEL TROFEO EN DATA A TRAVÉS DE REFLEXIÓN

        string fieldName = "gift" + trophyName;

        var dataType = typeof(Data);
        var field = dataType.GetField(fieldName);

        if (field != null && field.FieldType == typeof(bool))
            field.SetValue(Data.instance, true);
        else
            Debug.LogWarning($"No boolean field named '{fieldName}' found in Data.");
        #endregion

        #region PONER EN LA UI EL MENSAJE DEL TROFEO USANDO EL DICCIONARIO DE TROFEOS

        if (TrophyMessages.TryGetValue(trophyName, out string message))
            DialogueManager.Instance.uITrophies.transform.GetChild(1).GetComponent<TMP_Text>().text = message;

        else
            Debug.LogWarning($"Trophy name '{trophyName}' no reconocido.");

        #endregion

        DialogueManager.Instance.uITrophies.GetComponent<Animator>().SetTrigger("TrophyShow");
        Data.instance.GuardarDatos();
    }

    public void ActivateTabletFirstTime()
    {
        DialogueManager.Instance.dialoguePanelFirst.transform.SetParent(DialogueManager.Instance.mainCam.transform);
        DialogueManager.Instance.dialoguePanelFirst.GetComponent<Animator>().enabled = true;
        DialogueManager.Instance.dialoguePanelFirst.GetComponent<Animator>().SetBool("TabletTaken", true);
    }

    public void ChangingDialogue(string text)
    {
        if (DialogueManager.Instance.currentDay == "01")
        {
            dialogueTextBoxFirst.text = text;
            RaceFontAndSizeText(dialogueTextBoxFirst);
        }

        else
        {
            dialogueTextBoxOther.text = text;
            RaceFontAndSizeText(dialogueTextBoxOther);
        }
    }

    public void RaceFontAndSizeText(TextMeshProUGUI textBox)
    {
        string race = currentDialogueClient.race;

        string path = $"Fonts/{race}";
        TMP_FontAsset[] fonts = Resources.LoadAll<TMP_FontAsset>(path);

        if (fonts != null && fonts.Length > 0)
            textBox.font = fonts[0];
        else
            Debug.LogWarning($"No se encontró ninguna fuente en la carpeta: {path}");

        switch (race)
        {
            case "Elementales":
                textBox.fontSize = 70;
                break;

            case "Híbridos":
                textBox.fontSize = 120;
                break;

            case "Limbásticos":
                textBox.fontSize = 100;
                break;

            case "Magos Oscuros":
                textBox.fontSize = 80;
                break;

            case "Tecnópedos":
                textBox.fontSize = 70;
                break;

            case "Desconocida":
                textBox.fontSize = 85;
                break;

            default:
                print("Incorrect intelligence level.");
                break;
        }
    }

    public void RacePanelUP()
    {
        for (int i = 0; i < DialogueManager.Instance.racePanel.transform.childCount; i++)
        {
            if (DialogueManager.Instance.racePanel.transform.GetChild(i).name == currentDialogueClient.race)
                DialogueManager.Instance.racePanel.transform.GetChild(i).gameObject.SetActive(true);

            else
                DialogueManager.Instance.racePanel.transform.GetChild(i).gameObject.SetActive(false);
        }

        DialogueManager.Instance.racePanel.GetComponent<RacePanelScript>().PlayPanelAnimation(1);
    }

    public void RacePanelDOWN()
    {
        DialogueManager.Instance.racePanel.GetComponent<RacePanelScript>().PlayPanelAnimation(-1);
    }

    public void ShowCouponInfo(string couponName)
    {
        for (int i = 0; i < DialogueManager.Instance.couponInfoContainer.transform.childCount; i++)
        {
            if (DialogueManager.Instance.couponInfoContainer.transform.GetChild(i).name == couponName)
                DialogueManager.Instance.couponInfoContainer.transform.GetChild(i).gameObject.SetActive(true);
            else
                DialogueManager.Instance.couponInfoContainer.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void RegulationsActivate()
    {
        for (int i = 0; i < DialogueManager.Instance.currentRegulationsBook.transform.childCount; i++)
        {
            if (DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).name == DialogueManager.Instance.currentDay)
                DialogueManager.Instance.currentRegulationsBook.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void GoingToSecondPage(GameObject day)
    {
        day.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        day.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);

        day.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
        day.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
    }

    public void GoingToThirdPage(GameObject day)
    {
        day.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        day.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);

        day.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
    }

    public void ReturnToSecondPage(GameObject day)
    {
        day.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
        day.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);

        day.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
    }

    public void ReturnToFirstPage(GameObject day)
    {
        day.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        day.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);

        day.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
        day.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(false);
    }

    // Funciones que se llamarían cuando los textos tengan la parte de tutorial que cambian la cámara
    public void TutorialZoomIns(GameObject zoomInWhat)
    {
        DialogueManager.Instance.mainCam.GetComponent<CameraZoomManager>().EnterZoomMode(zoomInWhat.GetComponent<ZoomTargetInfo>());
        DialogueManager.Instance.tutorialZoomIn = true;

        if (DialogueManager.Instance.currentDay != "01")
            DialogueManager.Instance.dialoguePanelOther.SetActive(false);
        else
            DialogueManager.Instance.dialoguePanelFirst.SetActive(false);

        Invoke(nameof(CallingZoomOut), 2);
    }

    public void CallingZoomOut()
    {
        DialogueManager.Instance.mainCam.GetComponent<CameraZoomManager>().ExitZoomMode();
    }

    public void ControlarMovimientoTablet(string accion)
    {
        DialogueManager.Instance.mainCam.GetComponent<CameraZoomManager>().ReturnToInitialPose();

        GameObject panel = DialogueManager.Instance.currentDay == "01"
            ? DialogueManager.Instance.dialoguePanelFirst
            : DialogueManager.Instance.dialoguePanelOther;

        TabletMover mover = panel.GetComponent<TabletMover>();

        string nombreMetodo = accion + "Movimiento";

        var metodo = typeof(TabletMover).GetMethod(nombreMetodo);
        metodo.Invoke(mover, null);
    }
}
