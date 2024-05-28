using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceEqupimentScript : MonoBehaviour
{
    public GameObject currentGameObj;
    float xRotation;

    GameObject PlayerObject;
    PlayerCam PlayerCamScript;

    GameObject PlayerObject_1;

    float playerHeight;
    LayerMask worldLayer_1;

    private void Start()
    {
        PlayerObject = GameObject.Find("PlayerCam");
        PlayerCamScript = PlayerObject.GetComponent<PlayerCam>();

        Vector3 sizeVec = GetComponent<Collider>().bounds.size;
        playerHeight = sizeVec.y;

        PlayerObject_1 = GameObject.Find("PlayerObj");

        xRotation = this.transform.rotation.y;
    }


    float scroll = 0;
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            xRotation += 45 * Time.deltaTime;

        }

        else if (Input.GetButton("Fire2"))
        {
            xRotation -= 45 * Time.deltaTime;
        }

        transform.rotation = Quaternion.Euler(0, xRotation, 0);

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            scroll += 0.05f;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // forward
        {
            scroll -= 0.05f;
        }


        this.transform.position = new Vector3(PlayerCamScript.placePos.transform.position.x, PlayerObject_1.transform.position.y  + scroll, PlayerCamScript.placePos.transform.position.z);

    }
}
