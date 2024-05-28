using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjectScript : MonoBehaviour
{

    public GameObject currentGameObj;
    float xRotation;

    private GameObject Spawn_point;


    GameObject PlayerObject;
    PlayerCam PlayerCamScript;
    private void Start()
    {
        PlayerObject = GameObject.Find("PlayerCam");
        PlayerCamScript = PlayerObject.GetComponent<PlayerCam>();

        Spawn_point = GameObject.Find("SpawnPoint");
    }

    bool doIhaveAnObject = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerCamScript.Object == currentGameObj && PlayerCamScript.heldObj == null && !doIhaveAnObject)
        {
            PlayerCamScript.plceAnObject();
            PlayerCamScript.heldObj.AddComponent<PlaceEqupimentScript>();
            doIhaveAnObject = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && PlayerCamScript.heldObj != null && doIhaveAnObject)
        {
            if (PlayerCamScript.heldObj.GetComponent<PlaceEqupimentScript>())
                    {
                        Destroy(PlayerCamScript.heldObj.GetComponent<PlaceEqupimentScript>());
                    }
            PlayerCamScript.dropAnObject();
            doIhaveAnObject = false;
        }

        if (PlayerCamScript.Object != currentGameObj && this.gameObject.GetComponent<Outline>())
            Destroy(this.gameObject.GetComponent<Outline>());
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.name == "UnderTheMapCheck")
        {
            currentGameObj.transform.position = Spawn_point.transform.position;
        }
        
    }
}
