using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewGnomeScript : MonoBehaviour
{
    [SerializeField] public GameObject canvas;
    public Animator animator;
    public bool showingDone;
    public bool leavingDone;

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("UI");
        animator = GetComponent<Animator>();
        DialogueManager.Instance.theGnomeIsFree = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GnomeFinded()
    {
        Data.instance.numGnomosFinded++;
        DialogueManager.Instance.theGnomeIsFree = false;

        if (Data.instance.numGnomosFinded == 1)
            Destroy(gameObject);
            

        else if (Data.instance.numGnomosFinded == 2)
            Destroy(gameObject);

        else if (Data.instance.numGnomosFinded == 3)
        {
            Data.instance.giftEnano = true;
            canvas.GetComponent<UIManager>().TrophyAchieved("Enano");
            Destroy(gameObject);
        }
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
        if (Data.instance.numGnomosFinded == 0)
            animator.SetBool("oneFleeing", true);

        else if (Data.instance.numGnomosFinded == 1)
            animator.SetBool("threeFleeing", true);

        else if (Data.instance.numGnomosFinded == 2)
        {
            animator.SetBool("fourFleeing", true);
            Data.instance.giftEnano = true;
            canvas.GetComponent<UIManager>().TrophyAchieved("Enano");
        }
    }

    public void CallingGoingHome()
    {
        DialogueManager.Instance.clientManager.GetComponent<ClientManager>().GoingHome(DialogueManager.Instance.currentDay);
    }
}
