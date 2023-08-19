using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LampExplode : MonoBehaviour
{
    public bool isExplode = false;
    private SpriteRenderer spi;
    [SerializeField] private Sprite mainSpi;
    [SerializeField] private Sprite explodeSpi;
    public GameObject mainLight;
    private Animator anim;
    private Animator chaAnim;
    [SerializeField] private float endTime;

    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioSource audioS2;

    void Start()
    {
        spi = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        chaAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void Update()
    {
        if (MonsterAi.ai.lightBreak == true)
        {
            anim.SetTrigger("isGlitch");
            isExplode = true;
            audioS.Play();
        }

        Explode();
    }

    private void Explode()
    {
        if (isExplode == true)
        {
            StartCoroutine(Glitcher());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isExplode == true)
        {
            if (collision.CompareTag("UIitem"))
            {
                StopAllCoroutines();
                if (InvntoryManager.instance.getBulb == true)
                {
                    chaAnim.SetTrigger("isRoll");
                    spi.sprite = mainSpi;
                    isExplode = false;
                    mainLight.SetActive(true);
                    audioS2.Play();
                    InvntoryManager.instance.destroyBulb = true;
                }
            }
        } 
    }

    private IEnumerator Glitcher()
    {
        yield return new WaitForSeconds(endTime);
        spi.sprite = explodeSpi;
        mainLight.SetActive(false);
        MonsterAi.ai.lightBreak = false;
    }
}
