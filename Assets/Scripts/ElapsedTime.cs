using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ElapsedTime : MonoBehaviour
{
    private float tot_seconds = 0;
    [SerializeField] private TextMeshProUGUI elapsedTime;
    private float minutes, seconds;
    private bool isPaused = false;
    [SerializeField] private TextMeshProUGUI pause;
    [SerializeField] private Button resume;
    [SerializeField] private Button saveExit;
    [SerializeField] private Image panel;

    private void Start()
    {
        pause.gameObject.SetActive(false);
        resume.gameObject.SetActive(false);
        saveExit.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            pause.gameObject.SetActive(true);
            resume.gameObject.SetActive(true);
            saveExit.gameObject.SetActive(true);
            panel.gameObject.SetActive(true);

        }
        else
        {
            isPaused = false;
        }
        if (isPaused==false)
        {
            tot_seconds += Time.deltaTime;
            minutes = Mathf.FloorToInt(tot_seconds / 60);
            seconds = Mathf.FloorToInt(tot_seconds % 60);

            // {0:00} minutes param - {1:00} seconds param
            elapsedTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }


        //elapsedTime.text = "" + seconds;
    }
    public void Resume()
    {
        pause.gameObject.SetActive(false);
        resume.gameObject.SetActive(false);
        saveExit.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
        isPaused = false;
    }
}
