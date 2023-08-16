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

    void Start()
    {
        spi = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isExplode = true;
        }

        Explode();
    }

    private void Explode()
    {
        if (isExplode == true)
        {
            spi.sprite = explodeSpi;
            light.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isExplode == true)
        {
            if (collision.CompareTag("UIitem"))
            {
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
}
