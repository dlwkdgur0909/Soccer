using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject howToPlay;

    public void Tittle()
    {
        SceneManager.LoadScene(0);
    }

    public void InGame()
    {
        SceneManager.LoadScene(1);  
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);
    }
}
