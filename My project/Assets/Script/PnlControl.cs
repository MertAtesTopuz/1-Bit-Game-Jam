using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PnlControl : MonoBehaviour
{
    public GameObject stopPnl;
    // [System.Obsolete]

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
}
