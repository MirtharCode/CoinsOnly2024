using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody), typeof(SpringJoint), typeof(Collider))]
public class CobrarCuerda : MonoBehaviour
{
    public Transform anchorPoint; 
    public float maxPullDistance = 3f; 
    public float dragStrength = 15f;   

    public event Action CobrarCliente;

    private Rigidbody rb;
    private SpringJoint spring;
    private Camera cam;
    private bool isDragging = false;
    private bool hasFiredEvent = false;

    public GameObject Cameras;
    public GameObject ClientManager;

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
        spring.spring = 400f;      
        spring.damper = 300f;       
        spring.massScale = 1f;
    }

    void OnMouseDown()
    {
        isDragging = true;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        hasFiredEvent = false;
    }

    void OnMouseUp()
    {
        isDragging = false;
        rb.useGravity = true;

        float dist = Vector3.Distance(transform.position, anchorPoint.position);
        if (dist >= maxPullDistance * 0.95f && !hasFiredEvent)
        {
            print("Te cobro macho");
            Cameras.GetComponent<EdgeScrollCamera>().ReturnToCenter();
            Cameras.GetComponent<CameraZoomManager>().ReturnToCenter();
            ClientManager.GetComponent<ClientManager>().IWantToBelieve();
            ClientManager.GetComponent<ClientManager>().TimeToCharge();
            hasFiredEvent = true;
        }
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.WorldToScreenPoint(transform.position).z));
            Vector3 target = new Vector3(transform.position.x, Mathf.Min(mouseWorld.y, anchorPoint.position.y - maxPullDistance), transform.position.z);

            Vector3 forceDir = (target - transform.position);
            rb.AddForce(forceDir * dragStrength, ForceMode.Acceleration);
        }
    }
}
