using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    public static bool isLoad;
    public void LoadMainMenu()
    {
        isLoad = false;
        SceneManager.LoadScene("MainMenu");
    }
}
