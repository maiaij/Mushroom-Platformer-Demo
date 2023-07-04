using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("DemoLevel");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
