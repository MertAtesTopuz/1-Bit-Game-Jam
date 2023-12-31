using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Rendering.Universal;

public class TimeManager : MonoBehaviour
{
    public static int Minute { get; private set; }
    public static int Hour { get; private set; }
    public static int LightI { get; private set; }

    private float minuteToRealTime = 1f;
    private float timer;

    public Light2D mainLight;
    private bool lightTimer;

    [Header("UI")]
    public Image img;
    public TextMeshProUGUI txtPro;

    [Header("UIType")]
    public Sprite day;
    public Sprite night;
    public Color dayColor;
    public Color nightColor;

    void Start()
    {
        img.sprite = day;
        txtPro.color = dayColor;

        Minute = 0;
        Hour = 10;
        timer = minuteToRealTime;
    }

    void Update()
    {
        MainTimer();
        txtPro.text = Hour.ToString()+ ":" + Minute.ToString("00");
        
        ChangeSprite();
    }

    private void MainTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Minute++;
            if (lightTimer == true)
            {
                LightUpdater();
            }
            
            if (Minute > 60)
            {
                Hour++;
                Minute = 0;
            }
            timer = minuteToRealTime;
        }
    }

   private void ChangeSprite()
    {
        if (Hour == 10 && Minute == 5)
        {
            img.sprite = night;
            txtPro.color = nightColor;
            lightTimer = true;
            
        }
    }
    private void LightUpdater()
    {
            mainLight.intensity -= 0.1f;
        
            if (mainLight.intensity <= 0.05f)
            {
                mainLight.intensity = 0.05f;
                MonsterAi.ai.isNight = true;
            }
    }
}
