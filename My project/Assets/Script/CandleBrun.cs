using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CandleBrun : MonoBehaviour
{
    public bool isBurn = false;
    private SpriteRenderer spi;
    [SerializeField] private Sprite mainSpi;
    [SerializeField] private Sprite burnSpi;
    public GameObject light;
    private Animator anim;
    public AudioSource auidioS;
    public AudioSource auidioS2;
    public float soundWait;

    void Start()
    {
        spi = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
       
    }

    private void Update()
    {
        if(MonsterAi.ai.candleBreak == true)
        {
            StartCoroutine(SoundTimer());
        }

        NotBurn();
    }

    private void NotBurn()
    {
        if (isBurn == false)
        {
            spi.sprite = mainSpi;
            light.SetActive(false);
            StopCoroutine(SoundTimer());
            anim.SetBool("isBurn", false);
            MonsterAi.ai.candleBreak = false;
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
                    auidioS2.Play();
                    anim.SetBool("isBurn", true);
                    InvntoryManager.instance.destroyMatch= true;
                }
            }
        }
    }

    IEnumerator SoundTimer()
    {
        auidioS.Play();
        yield return new WaitForSeconds(soundWait);
        isBurn = false;
    }
}
