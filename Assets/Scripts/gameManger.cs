﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManger : MonoBehaviour
{
    public GameObject bobaFab;
    private BobaMan ballManag;
    public bobafaceanimation faceanim;

    private GameObject straw;
    private FireBoba fire;
    private float startTime;

    //Scoring Variables
    public TextMeshProUGUI lives;
    private int gameLives = 5;
    public TextMeshProUGUI score;
    private int gameScore = 0;

    //Game Continutation:
    private bool gameOver;
    public GameObject gameOverScr;
    private Button playAgainbtn;

    // Tutorial screen
    public GameObject tutorialScr;
    private Button closeTutorialBtn;
    public Button openTutorialBtn;

    /* Called before the first frame updates, sets up the scoring system,
     * scripts and instantiates the boab
     */
    void Start()
    {
        straw = GameObject.Find("Straw");
        fire = straw.GetComponentInChildren<FireBoba>();
        ballManag = GetComponent<BobaMan>();

        lives.SetText(gameLives.ToString());
        score.SetText(gameScore.ToString());

        gameOverScr.SetActive(false);
        playAgainbtn = gameOverScr.GetComponentInChildren<Button>();
        gameOver = false;

        tutorialScr.SetActive(false);
        closeTutorialBtn = tutorialScr.GetComponentInChildren<Button>();
    }

    /* Called once per frame, handles input and calls the methods that
     * respond to input e.g. charging, updating scores
     * Uncomment lines for Touch/TouchPhase to allow touch input on mobile
     */
    void Update()
    {
        openTutorialBtn.onClick.AddListener(tutorialMode);
        closeTutorialBtn.onClick.AddListener(closeTutorialMode);

        //foreach(Touch touch in Input.touches) {
        //if (touch.phase == TouchPhase.Began) {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startTime = Time.time;
            fire.startCharge();
        }

        //if ((touch.phase == TouchPhase.Ended) && chargeBegan) {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            float endTime = Time.time;
            GameObject newBall = ballManag.newBall();
            fire.Shoot(newBall, endTime, startTime);
            fire.endCharge();
        }
        // }

        checkGameOver();
        }
        //}
    //}

    /* Handles score and lives variables updating depending on collisions */
    public void checkHits(List<GameObject> hits)
    {
        foreach(GameObject hit in hits)
        {
            if (hit.CompareTag("Wall"))
            {
                --gameLives;
                faceanim.sadFace();
            }
            if (hit.CompareTag("Bubble"))
            {
                if (hit.GetComponent<bubble>().containsStar)
                {
                    gameScore+= 3;
                    faceanim.smileFace();
                }
                else
                {
                    gameScore++;
                    faceanim.happyFace();
                }
            }
        }
        updateScore();
        // Debug.Log("Score: " + gameScore + " Game Lives" + gameLives);
    }

    public void loseLife()
    {
        --gameLives;
        updateScore();
    }
    /* Updates UI elements to display the right score and lives left */
    private void updateScore()
    {
        lives.SetText(gameLives.ToString());
        score.SetText(gameScore.ToString());
    }

    /* Handles game over logic and screen transitions */
    private void checkGameOver()
    {
        if(gameLives <= 0)
        {
            gameOver = true;
            Time.timeScale = 0;
            gameOverScr.SetActive(true);
            playAgainbtn.onClick.AddListener(resetGame);
            ballManag.removeAll();
            // Debug.Log("Game Over");
        }
    }

    /* Resets the game if player chooses to do so */
    private void resetGame()
    {
        gameLives = 5;
        lives.SetText(gameLives.ToString());
        gameScore = 0;
        score.SetText(gameScore.ToString());

        gameOver = false;
        Time.timeScale = 1;

        gameOverScr.SetActive(false);
    }

    private void tutorialMode()
    {
        tutorialScr.SetActive(true);
    }

    private void closeTutorialMode()
    {
        tutorialScr.SetActive(false);
    }
}