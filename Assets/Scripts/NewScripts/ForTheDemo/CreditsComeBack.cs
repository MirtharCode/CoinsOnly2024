using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsComeBack : MonoBehaviour
{

    public GameObject fadeToBlackObject;
    [SerializeField] public AnimationClip fadeToblackClip;
    [SerializeField] public float fadeToblackClipTime;

    // Start is called before the first frame update
    void Start()
    {
        fadeToblackClipTime = fadeToblackClip.length;        
        
        // En caso de ser una demo de Expo
        Invoke(nameof(ActivarButton), 20);
        
        // En caso de ser una demo para subir online
        //Invoke(nameof(EndTheDemo1), 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarButton()
    {
        GetComponent<Button>().enabled =true;
    }

    public void WelcomeAgain()
    {
        DialogueManager.Instance.chosenChecks.Clear();
        fadeToBlackObject.GetComponent<Animator>().SetBool("ToBlack", true);
        Invoke(nameof(RepeatTheDemo), fadeToblackClipTime);
    }

    public void RepeatTheDemo()
    {
        SceneManager.LoadScene("CC");
    }

    public void EndTheDemo1()
    {
        Debug.Log("Demo acabada");
        fadeToBlackObject.GetComponent<Animator>().SetBool("ToBlack", true);
        Invoke(nameof(EndTheDemo2), fadeToblackClipTime);
    }

    public void EndTheDemo2()
    {
        Application.Quit();
    }
}
