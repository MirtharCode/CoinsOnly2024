using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToJacobo : MonoBehaviour
{
    public GameObject fadeToBlackObject;
    public GameObject BG_SAL;
    [SerializeField] public AnimationClip fadeToblackClip;
    [SerializeField] public float fadeToblackClipTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        SALSoonTransitions scriptRef = BG_SAL.GetComponent<SALSoonTransitions>();
        scriptRef.ActivarFadeOut();
        Invoke(nameof(PromoDone), 5);
    }

    public void PromoDone()
    {
        fadeToBlackObject.GetComponent<Animator>().SetBool("ToBlack", true);
        Invoke(nameof(ToJacobo), fadeToblackClipTime);
    }

    public void ToJacobo()
    {
        SceneManager.LoadScene("FM");
    }
}
