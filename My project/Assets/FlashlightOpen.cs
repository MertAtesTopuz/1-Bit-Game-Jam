using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightOpen : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject flashlightSlider;
    private Slider slid;
    public GameObject mainLight;

    private void Start()
    {
        slid = flashlightSlider.GetComponent<Slider>();
    }

    void Update()
    {
        if (InvntoryManager.instance.flashlightSelected == true && InvntoryManager.instance.usableSlot == true)
        {
           flashlight.SetActive(true);
           flashlightSlider.SetActive(true);
        }
        else if (InvntoryManager.instance.flashlightSelected == false)
        {
           flashlight.SetActive(false);
           flashlightSlider.SetActive(false);
        }

        if (flashlightSlider.activeSelf == true)
        {
            slid.value -= Time.deltaTime / 100;
            if (slid.value == 0f)
            {
                mainLight.SetActive(false);
            }
            else
            {
                mainLight.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (InvntoryManager.instance.batterySelected == true)
        {
            slid.value = 1;
            InvntoryManager.instance.batterySelected = false;
            InvntoryManager.instance.destroyBattery = true;

        }
    }
}
