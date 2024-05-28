using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_switch_script : MonoBehaviour
{

    public GameObject currentGameObj;

    GameObject PlayerObject;
    PlayerCam PlayerCamScript;

    public GameObject Lamp;
    Light lt;

    public GameObject Light_bulb;
    Lamp_Script LampScript;

    GameObject child;

    private void Start()
    {
         PlayerObject = GameObject.Find("PlayerCam");
         PlayerCamScript = PlayerObject.GetComponent<PlayerCam>();

         lt = Lamp.GetComponent<Light>();

         LampScript = Light_bulb.GetComponent<Lamp_Script>();

        child = this.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (Lamp != PlayerObject)
        {
            lt = Lamp.GetComponent<Light>();
            LampScript = Light_bulb.GetComponent<Lamp_Script>();

            if (Input.GetKeyDown(KeyCode.E) && PlayerCamScript.Object == currentGameObj && lt.intensity != 0 && LampScript.state == "screwed")
            {
                lt.intensity = 0;
                StartCoroutine(Rotate(new Vector3(-80, 0, 0), 0.1f));
            }
            else if (Input.GetKeyDown(KeyCode.E) && PlayerCamScript.Object == currentGameObj && lt.intensity == 0 && LampScript.state == "screwed")
            {
                lt.intensity = 1;
                StartCoroutine(Rotate(new Vector3(80, 0, 0), 0.1f));
            }
        }

    }

    private IEnumerator Rotate(Vector3 angles, float duration)
    {
        Quaternion startRotation = child.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            child.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        child.transform.rotation = endRotation;
    }
}

