using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        IfLookingAt();
    }




    public GameObject Object;

    GameObject Object_pom;

    public LayerMask worldLayer;
    
    public int EnergySum;
    void IfLookingAt()
    {
        bool raycast = Physics.Raycast(transform.position, transform.forward, out var hit, 3, worldLayer);
        bool spherecast = Physics.SphereCast(transform.position, 0.5f, transform.forward, out var hit2, 3, worldLayer);

        if (spherecast)
        {
            var obj2 = hit2.collider.gameObject;

            Object = obj2;
            Object_pom = Object;
            if(!Object.GetComponent <Outline>())
            {
                var outline = Object.AddComponent<Outline>();

                outline.OutlineMode = Outline.Mode.OutlineVisible;
                outline.OutlineColor = Color.white;
                outline.OutlineWidth = 15f;
            }
        }
        else if (raycast)
        {
            var obj = hit.collider.gameObject;

            Object = obj;
            Object_pom = Object;
            if (!Object.GetComponent<Outline>())
            {
                var outline = Object.AddComponent<Outline>();

                outline.OutlineMode = Outline.Mode.OutlineVisible;
                outline.OutlineColor = Color.white;
                outline.OutlineWidth = 15f;
            }
        }
        else
        {
            if (Object.GetComponent <Outline>())
                Destroy (Object.GetComponent <Outline>());
            Object = gameObject;
        }
    }


    [Header("HOLDING ENERGY")]

    public GameObject heldObj; //object which we pick up
    private Rigidbody heldObjRb; //rigidbody of object we pick up

    public GameObject player;
    public Transform holdPos;
    public Transform placePos;


    public void pickUpAnObject()
    {
        GameObject name_pom = Object;
        string name = name_pom.name;


        heldObj = GameObject.Find(name);
        heldObjRb = heldObj.GetComponent<Rigidbody>();
        heldObjRb.isKinematic = true;
        heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
        heldObj.transform.position = holdPos.transform.position;

        int Layer_pom = LayerMask.NameToLayer("Default");
            heldObj.layer = Layer_pom;
    }


    public void plceAnObject()
    {
        GameObject name_pom = Object;
        string name = name_pom.name;


        heldObj = GameObject.Find(name);
        heldObjRb = heldObj.GetComponent<Rigidbody>();
        int Layer_pom = LayerMask.NameToLayer("Default");
        heldObj.layer = Layer_pom;

    }
    public void dropAnObject()
    {
        int Layer_pom = LayerMask.NameToLayer("InteractableObjects");
        heldObj.layer = Layer_pom;

        heldObjRb.isKinematic = false;

        heldObj.transform.parent = null; //unparent object
        heldObj = null; //undefine game object
        
    }

    
}
