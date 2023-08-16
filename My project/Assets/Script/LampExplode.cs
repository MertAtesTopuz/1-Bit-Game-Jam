using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampExplode : MonoBehaviour
{
    public bool isExplode = false;
    private SpriteRenderer spi;
    [SerializeField] private Sprite mainSpi;
    [SerializeField] private Sprite explodeSpi;
    public GameObject light;
    private Animator anim;
    [SerializeField] private float endTime;
    [SerializeField] private float endtime2;

    void Start()
    {
        spi = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        endtime2 -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("isGlitch");
            isExplode = true;
            
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
                    spi.sprite = mainSpi;
                    isExplode = false;
                    light.SetActive(true);
                    InvntoryManager.instance.destroyBulb = true;
                }
            }
        } 
    }

    private IEnumerator Glitcher()
    {
        yield return new WaitForSeconds(endTime);
        spi.sprite = explodeSpi;
        light.SetActive(false);
    }
}
