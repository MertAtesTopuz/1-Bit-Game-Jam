using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    private TimeManager timee;
    private SpriteRenderer spi;
    [SerializeField] private Sprite daySpi;
    [SerializeField] private Sprite nightSpi;

    void Start()
    {
        timee = GameObject.FindGameObjectWithTag("Time").GetComponent<TimeManager>();
        spi = GetComponent<SpriteRenderer>();
        spi.sprite = daySpi;
    }

    void Update()
    {
        if (timee.windowChange == true)
        {
            spi.sprite = nightSpi;
        }
    }
}
