using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody), typeof(SpringJoint), typeof(Collider))]
public class NoCobrarCuerda : MonoBehaviour
{
    public Transform anchorPoint; 
    public float maxPullDistance = 3f;
    public float dragStrength = 15f;   

    private Rigidbody rb;
    private SpringJoint spring;
    private Camera cam;
    private bool isDragging = false;
    private bool hasFiredEvent = false;
    private bool canTouch = false;

    public GameObject Cameras;
    public GameObject ClientManager;

    public GameObject flechaTutorial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spring = GetComponent<SpringJoint>();
        cam = Camera.main;
        Cameras = GameObject.FindGameObjectWithTag("MainCamera");
        ClientManager = GameObject.FindGameObjectWithTag("UI");

        spring.connectedBody = null;
        spring.autoConfigureConnectedAnchor = false;
        spring.connectedAnchor = anchorPoint.position;
        spring.spring = 400f;      // fuerza del resorte
        spring.damper = 300f;       // amortiguación (para controlar rebote)
        spring.massScale = 1f;

        flechaTutorial.SetActive(false);
    }

    void OnMouseDown()
    {
        isDragging = true;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        hasFiredEvent = false;

        if (canTouch)
        {
            flechaTutorial.SetActive(true);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        rb.useGravity = true;

        flechaTutorial.SetActive(false);

        float dist = Vector3.Distance(transform.position, anchorPoint.position);
        if (dist >= maxPullDistance * 0.95f && !hasFiredEvent)
        {
            Cameras.GetComponent<EdgeScrollCamera>().ReturnToCenter();
            Cameras.GetComponent<CameraZoomManager>().ReturnToCenter();
            ClientManager.GetComponent<ClientManager>().NoWayJose();
            ClientManager.GetComponent<ClientManager>().TimeToCharge();
            hasFiredEvent = true;
        }
    }
    public void ActivateTouch()
    {
        canTouch = true;
    }
    public void DeactivateTouch()
    {
        canTouch = false;
    }
    void FixedUpdate()
    {
        if (isDragging && canTouch)
        {
            Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.WorldToScreenPoint(transform.position).z));
            Vector3 target = new Vector3(transform.position.x, Mathf.Min(mouseWorld.y, anchorPoint.position.y - maxPullDistance), transform.position.z);

            Vector3 forceDir = (target - transform.position);
            rb.AddForce(forceDir * dragStrength, ForceMode.Acceleration);
        }
    }
}
