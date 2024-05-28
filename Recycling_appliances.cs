using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Recycling_appliances : MonoBehaviour
{
    GameObject UI;
    UIcode UI_script;

    Energy_usage Energy_script;

    GameObject Cash_sound_obj;
    AudioSource Cash_sound;

    GameObject PlayerObject;
    PlayerCam PlayerCamScript;

    void Start()
    {
        Cash_sound_obj = GameObject.Find("Sold_sound");
        Cash_sound = Cash_sound_obj.GetComponent<AudioSource>();

        UI = GameObject.Find("UI");
        UI_script = UI.GetComponent<UIcode>();

        Energy_script = this.GetComponent<Energy_usage>();

        PlayerObject = GameObject.Find("PlayerCam");
        PlayerCamScript = PlayerObject.GetComponent<PlayerCam>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "RecycleContainerCollider")
        {
            Cash_sound.Play();
            UI_script.Budget += (int)Mathf.Round(Energy_script.price * 0.33f);
            Debug.Log((int)Mathf.Round(Energy_script.price * 0.33f));
            UI_script.BudgetLabel.text = UI_script.Budget.ToString();
            UI_script.BudgetLabel2.text = UI_script.Budget.ToString();
            if (this.GetComponent<Lamp_Script>())
            {
                PlayerCamScript.dropAnObject();
                Destroy(this.GetComponent<Lamp_Script>());
                Destroy(this.GetComponent<Recycling_appliances>());
                int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
                this.gameObject.layer = LayerIgnoreRaycast;
            }
            else if (this.GetComponent<PickUpObjectScript>() && PlayerCamScript.heldObj != null)
            {
                Destroy(this.GetComponent<PlaceEqupimentScript>());
                PlayerCamScript.dropAnObject();
                Destroy(this.GetComponent<PickUpObjectScript>());
                Destroy(this.GetComponent<Recycling_appliances>());
                int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
                this.gameObject.layer = LayerIgnoreRaycast;
            }
        }
    }
}

