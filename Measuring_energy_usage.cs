using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Measuring_energy_usage : MonoBehaviour
{
    public GameObject currentGameObj;

    GameObject PlayerObject;
    PlayerCam PlayerCamScript;

    GameObject Utility;
    Energy_usage UtilityScript;

    public Dictionary<string, int> appliances_list = new Dictionary<string, int>()
    {

    };

    private void Start()
    {
        PlayerObject = GameObject.Find("PlayerCam");
        PlayerCamScript = PlayerObject.GetComponent<PlayerCam>();
    }

    public string message = "0";
    public string grading;

    public float overall_energy = 0;
    public float overall_price = 0;
    
    void Update()
    {
        Utility = PlayerCamScript.Object;
        UtilityScript = Utility.GetComponent<Energy_usage>();


        if (PlayerCamScript.Object == PlayerObject) // PlayerObject (Playercam) is deafult Object value
        {
            message = "0";
            grading = "none";
        }
        else
            GetName();
    }

    void GetName()
    {
        if (Utility.GetComponent<Energy_usage>())
        {
            message = UtilityScript.Price_per_year.ToString();
            grading = UtilityScript.Appliance_grading.ToString();
        }
    }

    public bool house_appliences_checker = false;
    public void Check_for_appliances_in_the_apartment()
    {
        if (appliances_list.ContainsKey("dishwasher") && appliances_list.ContainsKey("dryer") && appliances_list.ContainsKey("fridge")
            && appliances_list.ContainsKey("TV") && appliances_list.ContainsKey("washing_machine"))
        {
            if (appliances_list.ContainsKey("ac") && appliances_list["ac"] >= 2)
            {
                if (appliances_list.ContainsKey("light_bulb") && appliances_list["light_bulb"] >= 9)
                {
                    house_appliences_checker = true;
                }
                else
                {
                    house_appliences_checker = false;
                }
            }
            else
            {
                house_appliences_checker = false;
            }
        }
        else
        {
            house_appliences_checker = false;
        }


    }

}
