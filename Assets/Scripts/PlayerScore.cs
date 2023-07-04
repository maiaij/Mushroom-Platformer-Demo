using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    SaveManager savePlayer;
    [SerializeField] GameObject theShrooms;
    List<bool> mushroomVis;
    public int playerScore=0;
    PlayerInfo play;
    private bool touching;
    private bool sally;
    Collider2D touch = new Collider2D();
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI lastMessage;
    [SerializeField] private TextMeshProUGUI finalTime;
    [SerializeField] private Button playAgain;
    [SerializeField] private Button mainMenu;
    [SerializeField] private Image panel;
    [SerializeField] GameObject checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        lastMessage.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
        savePlayer = new SaveManager();
        play = new PlayerInfo();
        if (MainMenu.isLoad==true)
        {
            savePlayer.LoadArmour(); 
            this.gameObject.transform.position = savePlayer.player.position;
            this.playerScore = savePlayer.player.shroomCount;
            this.theShrooms = savePlayer.player.theShrooms;
        }
        else
        {
            play.position = this.gameObject.transform.position;
            play.shroomCount = this.playerScore;
            play.theShrooms = this.theShrooms;
            savePlayer.SavePlayer(play);
        }

        scoreText.text = ": " + this.playerScore;
        touching = false;
        sally = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.S))
        {
            if (touching==true)
            {
                touch.gameObject.SetActive(false);
                Debug.Log(theShrooms.ToString());
                playerScore += 1;
                scoreText.text = ": " + playerScore;
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (sally == true)
            {
                if (this.playerScore<4)
                {
                    lastMessage.text = "Congratulations you found " + this.playerScore + " mushrooms! \n It only took you " + finalTime.text + "\n I'm sure you can find more next time!";
                }
                else if (this.playerScore>5 && this.playerScore<=9) 
                {
                    lastMessage.text = "Congratulations you found " + this.playerScore + " mushrooms! \n It only took you " + finalTime.text + "\n That's a lot of mushrooms! Thank you!";
                }
                else
                {
                    lastMessage.text = "Congratulations you found " + this.playerScore + " mushrooms! \n It only took you " + finalTime.text + "\n How did you manage that?";
                }
                lastMessage.gameObject.SetActive(true);
                panel.gameObject.SetActive(true);
                playAgain.gameObject.SetActive(true);
                mainMenu.gameObject.SetActive(true);
                finalTime.gameObject.SetActive(false);
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

                //play.position = checkpoint.transform.position;
                //play.shroomCount = playerScore;
                //play.theShrooms = theShrooms;

                play.position = this.gameObject.transform.position;
                play.shroomCount = this.playerScore;
                play.theShrooms = this.theShrooms;
                savePlayer.SavePlayer(play);
                //SceneManager.LoadScene("MainMenu");

        }
        if (gameObject.transform.position.y <= -30)
        {
            savePlayer.LoadArmour();
            this.gameObject.transform.position = checkpoint.transform.position;
            this.playerScore = savePlayer.player.shroomCount;
            this.theShrooms = savePlayer.player.theShrooms;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Mushroom"))
        {
            touching = true;
            touch = col; 
        }
        if (col.gameObject.CompareTag("Sally"))
        {
            sally = true;
            touch = col;
        }
        if (col.gameObject.CompareTag("Water"))
        {
            
            savePlayer.LoadArmour();
            //this.gameObject.transform.position = savePlayer.player.position;
            this.gameObject.transform.position = checkpoint.transform.position;
            this.playerScore = savePlayer.player.shroomCount;
            this.theShrooms = savePlayer.player.theShrooms;
        }

        if (col.gameObject.CompareTag("Respawn"))
        {
            Debug.Log(col.gameObject.name);
            checkpoint = col.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touching = false;
        sally = false;
    }
}
