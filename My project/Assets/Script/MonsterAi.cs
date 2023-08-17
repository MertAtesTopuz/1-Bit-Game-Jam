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
    private float randomValue;
    public int startWait;
    private int value;
    private bool stopRand;
    private bool value0Check;


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
        if (isNight == true)
        {
            randomTime = Random.Range(10f, 20f);

            if (value == 0 && value0Check == false)
            {
                value0Check = true;
                // value = 0 olduğunda bunu value değeri değişene kadar yapıyo bunu engelle
                if (lightBreak == false)
                {
                    BoomLamb();
                }                
            }

            if (value == 1)
            {
                BoomCandle();
            }
        }
    }

    private void BoomLamb()
    {
        lightBreak = true;
        value0Check = false;
    }

    private void BoomCandle()
    {
        Debug.Log("candle boom");
    }

    private IEnumerator RandomTimeSelector()
    {
        yield return new WaitForSeconds(startWait);

        while (!stopRand)
        {
            value = Random.Range(0, 2);

            Debug.Log(value);
            
            yield return new WaitForSeconds(randomTime);
        }
    }
}
