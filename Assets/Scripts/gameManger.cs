using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class gameManger : MonoBehaviour
{
    public GameObject bobaFab;
    private GameObject currBoba;

    private GameObject straw;
    private FireBoba fire;
    private float startTime;

    //Scoring Variables
    public TextMeshProUGUI lives;
    private int gameLives = 10;
    public TextMeshProUGUI score;
    private int gameScore = 0;

    //Game Continutation:
    bool chargeBegan;
    private bool gameOver;
    public GameObject gameOverScr;
    public Button playAgainbtn;

    // Start is called before the first frame update
    void Start()
    {
        straw = GameObject.Find("Straw");
        fire = straw.GetComponentInChildren<FireBoba>();

        lives.SetText(gameLives.ToString());
        score.SetText(gameScore.ToString());

        currBoba = Instantiate(bobaFab);
        chargeBegan = false;

        gameOverScr.SetActive(false);
        playAgainbtn = gameOverScr.GetComponentInChildren<Button>();
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // float startTime = 0;
        // foreach(Touch touch in Input.touches) {
        // if (touch.phase == TouchPhase.Began) {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startTime = Time.time;
            chargeBegan = true;
            fire.startCharge();
        }

        // if (touch.phase == TouchPhase.Ended) {
        if (Input.GetKeyUp(KeyCode.Space) && chargeBegan)
        {
            float endTime = Time.time;
            shoot(endTime, startTime);
        }
        // }

        if (currBoba.GetComponent<bobaBall>().launched)
        {
            checkHit(currBoba.GetComponent<bobaBall>().hitObj);
            updateGame();
            checkGameOver();
        }
        
    }

    private void shoot(float end, float start)
    {
        fire.calculateCharge(end, start);
        fire.Shoot(currBoba);
        fire.endCharge();
        fire.fired = true;
        chargeBegan = false;
    }

    private void checkHit(GameObject hit)
    {
        if (hit != null)
        {

            if (currBoba.GetComponent<bobaBall>().hitObj.CompareTag("Bubble"))
            {
                if (currBoba.GetComponent<bobaBall>().hitObj.GetComponent<bubble>().containsStar)
                {
                    Debug.Log("Is scoring working?");
                    gameScore++;
                }
                else
                {
                    gameLives--;
                }
            }
            else
            {
                gameLives--;
            }
        }
        Debug.Log("Score: " + gameScore + " Game Lives" + gameLives);
    }

    private void updateGame()
    {
        lives.SetText(gameLives.ToString());
        score.SetText(gameScore.ToString());
        Destroy(currBoba);
        currBoba = Instantiate(bobaFab);
    }
    private void checkGameOver()
    {
        if(gameLives == 0)
        {
            gameOver = true;
            Time.timeScale = 0;
            gameOverScr.SetActive(true);
            playAgainbtn.onClick.AddListener(resetGame);
            Debug.Log("Game Over");
        }
    }

    private void resetGame()
    {
        gameLives = 10;
        lives.SetText(gameLives.ToString());
        gameScore = 0;
        score.SetText(gameScore.ToString());

        gameOver = false;
        Time.timeScale = 1;

        gameOverScr.SetActive(false);
    }
}
