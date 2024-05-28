using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_usage : MonoBehaviour
{

    GameObject PlayerObject;
    Measuring_energy_usage MeasuringEnergyScript;

    public float price;
    
    public string appliance_category; 

    public float Electricity_num;
    public float Price_per_year;

    public string Appliance_grading;


    void Start()
    {
        PlayerObject = GameObject.Find("PlayerCam");
        MeasuringEnergyScript = PlayerObject.GetComponent<Measuring_energy_usage>();
    }

    void OnTriggerEnter(Collider Hause_collider)
    {
        if (Hause_collider.name == "Hause_collider")
        {
            MeasuringEnergyScript.overall_energy += Electricity_num;
            MeasuringEnergyScript.overall_price += Price_per_year;

            if (!MeasuringEnergyScript.appliances_list.ContainsKey(appliance_category))
                MeasuringEnergyScript.appliances_list.Add(appliance_category, 1);
            else if (MeasuringEnergyScript.appliances_list.ContainsKey(appliance_category))
                MeasuringEnergyScript.appliances_list[appliance_category] += 1;
        }

    }

    void OnTriggerExit(Collider Hause_collider)
    {
        if (Hause_collider.name == "Hause_collider")
        {
            MeasuringEnergyScript.overall_energy -= Electricity_num;
            MeasuringEnergyScript.overall_price -= Price_per_year;

            if (MeasuringEnergyScript.appliances_list.ContainsKey(appliance_category) && MeasuringEnergyScript.appliances_list[appliance_category] == 1)
                MeasuringEnergyScript.appliances_list.Remove(appliance_category);
            else if (MeasuringEnergyScript.appliances_list.ContainsKey(appliance_category) && MeasuringEnergyScript.appliances_list[appliance_category] >= 1)
                MeasuringEnergyScript.appliances_list[appliance_category] -= 1;
        }
        
    }

}

