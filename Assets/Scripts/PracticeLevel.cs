using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticeLevel : MonoBehaviour
{
    public static bool isLoad;
    public void LoadIntroLevel()
    {
        isLoad = false;
        SceneManager.LoadScene("IntroLevel");
    }

    public void LoadMainMenu()
    {
        isLoad = false;
        SceneManager.LoadScene("MainMenu");
    }
}
