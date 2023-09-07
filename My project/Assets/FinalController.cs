using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalController : MonoBehaviour
{
    public void BackToMenuBtn()
    {
        SceneManager.LoadScene(0);
    }
}
