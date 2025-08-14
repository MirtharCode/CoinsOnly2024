using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuClientSound : MonoBehaviour
{
    [SerializeField] GameObject currentClient;
    public DialogueManager.DailyClientInfo currentDialogueClient;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //void Speak(string toneSound)
    //{
    //    string clientFolder = $"Sounds/Voices/{currentDialogueClient.name}";
    //    AudioClip[] allClips = Resources.LoadAll<AudioClip>(clientFolder);

    //    if (allClips.Length == 0)
    //    {
    //        Debug.LogWarning($"No se encontraron clips en la carpeta: {clientFolder}");
    //        return;
    //    }

    //    // Filtrar los que empiecen con el tipo (ej: "exclamative")
    //    var matchingClips = allClips.Where(clip => clip.name.StartsWith(toneSound, StringComparison.OrdinalIgnoreCase)).ToArray();

    //    if (matchingClips.Length == 0)
    //    {
    //        Debug.LogWarning($"No se encontraron clips que empiecen con '{toneSound}' en {clientFolder}");
    //        return;
    //    }

    //    // Elegir uno al azar
    //    AudioClip chosenClip = matchingClips[UnityEngine.Random.Range(0, matchingClips.Length)];

    //    // Reproducir
    //    var clientScript = currentClient.GetComponent<ClientScript>();
    //    clientScript.talkingSound.clip = chosenClip;
    //    clientScript.talkingSound.Play();
    //}
}
