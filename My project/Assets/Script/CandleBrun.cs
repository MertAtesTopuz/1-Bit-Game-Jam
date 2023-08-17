using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleBrun : MonoBehaviour
{
    public bool isBurn = false;
    private SpriteRenderer spi;
    [SerializeField] private Sprite mainSpi;
    [SerializeField] private Sprite burnSpi;
    public GameObject light;
    private Animator anim;

    void Start()
    {
        spi = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            isBurn = false;
        }

        NotBurn();
    }

    private void NotBurn()
    {
        if (isBurn == false)
        {
            spi.sprite = mainSpi;
            light.SetActive(false);
            anim.SetBool("isBurn", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBurn == false)
        {
            if (collision.CompareTag("UIitem"))
            {
                if (InvntoryManager.instance.getMatch == true)
                {
                    spi.sprite = burnSpi;
                    isBurn = true;
                    light.SetActive(true);
                    anim.SetBool("isBurn", true);
                    InvntoryManager.instance.destroyMatch= true;

                }
            }
        }
    }
}
