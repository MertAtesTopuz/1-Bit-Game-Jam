using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAi : MonoBehaviour
{
    public static MonsterAi ai;

    public bool lightBreak;
    public bool candleBreak;
    public bool isNight;

    private float randomTime;
    public int startWait;
    private int value;
    private bool stopRand;
    public float rand0Stopper;
    public float rand1Stopper;

    public float lightTimer = 0;
    public float lightTimeSetter = 3;

    public float candleTimer = 0;
    public float candleTimeSetter = 3;

    public bool saver = true;

    private void Awake()
    {
        ai = this;
    }

    private void Start()
    {
        StartCoroutine(RandomTimeSelector());
    }

    void Update()
    {
        lightTimer -= Time.deltaTime;
        candleTimer -= Time.deltaTime;
        if (isNight == true)
        {
            randomTime = Random.Range(10f, 20f);

            if (value == 0)
            {
                value = 3;
                lightTimer = lightTimeSetter;
            }
            else if(value == 1)
            {
                value = 3;
                candleTimer = candleTimeSetter;
            }

            if (saver == false)
            {
                
                StartCoroutine(KillPlayer());
            }
        }

        if (saver == true)
        {
            StopCoroutine(KillPlayer());
        }
        if (lightTimer >= 2f)
        {
            BoomLamb();
        }

        if (candleTimer >= 2f)
        {
            BoomCandle();
        }
    }

    private void BoomLamb()
    {
        lightBreak = true;
    }

    private void BoomCandle()
    {
        candleBreak = true;
    }

    private IEnumerator RandomTimeSelector()
    {
        yield return new WaitForSeconds(startWait);

        while (!stopRand)
        {
            value = Random.Range(0, 2);
            if (value == 0)
            {
                rand0Stopper++;
                if (rand0Stopper >= 3)
                {
                    value = 1;
                    rand0Stopper = 0;
                }
            }

            if (value == 1)
            {
                rand1Stopper++;
                if (rand1Stopper >= 3)
                {
                    value = 0;
                    rand1Stopper = 0;
                }
            }

            Debug.Log(value);
            
            yield return new WaitForSeconds(randomTime);
        }
    }

    private IEnumerator KillPlayer()
    {
        yield return new WaitForSeconds(10f);
        if (saver == false)
        {
            Time.timeScale = 0;
        }
    }
}
