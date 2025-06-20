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
        Invoke(nameof(ActivarButton), 20);
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
        fadeToBlackObject.GetComponent<Animator>().SetBool("ToBlack", true);
        Invoke(nameof(ToTheDemo), fadeToblackClipTime);
    }

    public void ToTheDemo()
    {
        SceneManager.LoadScene("DD");
    }
}
