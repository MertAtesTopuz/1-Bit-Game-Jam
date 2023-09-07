using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PnlControl : MonoBehaviour
{
    public GameObject stopPnl;
    public GameObject losePnl;
    private TimeManager time;
    // [System.Obsolete]

    private void Start()
    {
        time = GameObject.FindGameObjectWithTag("Time").GetComponent<TimeManager>();
    }

    private void Update()
    {
        if (time.winBool == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void BackToMenuBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void ContiniueBtn()
    {
        Time.timeScale = 1.0f;
        stopPnl.SetActive(false);
    }

    public void StopBtn()
    {
        Time.timeScale = 0.0f;
        stopPnl.SetActive(true);
    }

    public void RepeatBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void kaybettin()
    {
        Time.timeScale = 0.0f;
        losePnl.SetActive(true);
    }
}
