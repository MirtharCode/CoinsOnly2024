using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewGnomeScript : MonoBehaviour
{
    [SerializeField] public GameObject canvas;
    public Animator animator;

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("UI");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GnomeFinded()
    {
        Data.instance.numGnomosFinded++;
        DialogueManager.Instance.theGnomeIsFree = false;

        if (Data.instance.numGnomosFinded == 3)
        {
            Data.instance.giftEnano = true;
            canvas.GetComponent<UIManager>().TrophyAchieved("Enano");            
        }

        Destroy(gameObject);
    }

    public void GnomeShowing()
    {
        if (Data.instance.numGnomosFinded == 1)
            animator.SetBool("oneAppeared", true);

        else if (Data.instance.numGnomosFinded == 2)
            animator.SetBool("threeAppeared", true);

        else if (Data.instance.numGnomosFinded == 3)
        {
            animator.SetBool("fourAppeared", true);
            Data.instance.giftEnano = true;
            canvas.GetComponent<UIManager>().TrophyAchieved("Enano");
        }
    }

    public void GnomeFleeing()
    {
        if (DialogueManager.Instance.theGnomeIsFree)
        {
            if (DialogueManager.Instance.currentDay == "02")
                animator.SetBool("oneFleeing", true);

            else if (DialogueManager.Instance.currentDay == "04")
                animator.SetBool("threeFleeing", true);

            else if (DialogueManager.Instance.currentDay == "06")
            {
                DialogueManager.Instance.clientManager.GetComponent<ClientManager>().TutorialZoomIns(DialogueManager.Instance.zoomTargetCoupon);
                animator.SetBool("fourFleeing", true);
            }
        }        
    }

    public void CallingGoingHome()
    {
        DialogueManager.Instance.theGnomeIsFree = false;
        DialogueManager.Instance.clientManager.GetComponent<ClientManager>().GoingHome(DialogueManager.Instance.currentDay);
    }
}
