using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("UIPages")]
    public GameObject settingsScreen;
    public GameObject creditsScreen;
    public GameObject mainScreen;
    public GameObject canvas;
    public bool timeControl;

    private Animator anim;

    void Start()
    {
        anim = canvas.GetComponent<Animator>();
    }

    public void Play()
    {
        StartCoroutine(TimerMTP());
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        StartCoroutine(TimerMTS());
    }

    public void set2Menu()
    {
        StartCoroutine(TimerSTM());
    }

    public void Creadits()
    {
        StartCoroutine(TimerMTC());
    }

    public void cre2Menu()
    {
        StartCoroutine(TimerCTM());
    }

    private IEnumerator TimerMTP()
    {
        anim.SetTrigger("isMTP");
        yield return new WaitForSeconds(1.1f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator TimerMTS()
    {
        anim.SetTrigger("isMTS");
        yield return new WaitForSeconds(1.1f);
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    private IEnumerator TimerSTM()
    {
        anim.SetTrigger("isSTM");
        yield return new WaitForSeconds(2.2f);
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }

    private IEnumerator TimerMTC()
    {
        anim.SetTrigger("isMTC");
        yield return new WaitForSeconds(1.1f);
        mainScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    private IEnumerator TimerCTM()
    {
        anim.SetTrigger("isCTM");
        yield return new WaitForSeconds(2.2f);
        mainScreen.SetActive(true);
        creditsScreen.SetActive(false);
    }
}
