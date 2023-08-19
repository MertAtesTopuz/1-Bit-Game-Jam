using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaverLight : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (MonsterAi.ai.isNight == true && MonsterAi.ai.saver == false)
            {
                MonsterAi.ai.saver = true;
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (MonsterAi.ai.isNight == true && MonsterAi.ai.saver == false)
            {
                MonsterAi.ai.saver = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (MonsterAi.ai.isNight == true && MonsterAi.ai.saver == true)
            {
                MonsterAi.ai.saver = false;
            }
        }
    }
}
