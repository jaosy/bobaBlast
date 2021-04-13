using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* Controls game logic
 */
public class gameManger : MonoBehaviour
{
    // Reference to GameObjects
    public GameObject bobaFab;
    private GameObject straw;

    // Reference to other scripts
    private FireBoba fire; // controls shooting
    private BobaMan ballManag; // boba script managing what it has hit
    public bobafaceanimation faceanim; // GameObject representing boba's face

    // Scoring variables
    public TextMeshProUGUI lives;
    private int gameLives = 5;
    public TextMeshProUGUI score;
    private int gameScore = 0;
    private float startTime;

    // Game continuation
    public GameObject gameOverScr;
    private Button playAgainbtn;

    // Tutorial screen
    public GameObject tutorialScr;
    private Button closeTutorialBtn;
    public Button openTutorialBtn;

    /* Called before the first frame updates, sets up the scoring system,
     * scripts and instantiates the boba
     */
    void Start()
    {
        // set up straw object and FireBoba script attached to it,
        // set up up BobaMan script
        straw = GameObject.Find("Straw");
        fire = straw.GetComponentInChildren<FireBoba>(); 
        ballManag = GetComponent<BobaMan>();

        // set lives/score text
        lives.SetText(gameLives.ToString());
        score.SetText(gameScore.ToString());

        // begin with game over screen deactivated, set up replay button
        gameOverScr.SetActive(false);
        playAgainbtn = gameOverScr.GetComponentInChildren<Button>();

        // begin with tutorial screen deactivated, set up close button
        tutorialScr.SetActive(false);
        closeTutorialBtn = tutorialScr.GetComponentInChildren<Button>();
    }

    /* Called once per frame, handles input and calls the methods that
     * respond to input e.g. charging, updating scores
     * Uncomment lines for Touch/TouchPhase to allow touch input on mobile
     */
    void Update()
    {
        // add listeners for tutorial buttons
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
        //}

        checkGameOver();
        }
        //}
    //}

    /* Handles score and lives variables updating depending on collisions,
       takes a list of GameObjects representing objects boba has collided
       with, compares object tags and updates score accordingly
     */
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
                // +3 extra points for popping bubbles with stars
                if (hit.GetComponent<bubble>().containsStar)
                {
                    gameScore+=3;
                    faceanim.smileFace();
                }
                // pop a normal bubble
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
            Time.timeScale = 0; // temporary pause
            gameOverScr.SetActive(true); 
            playAgainbtn.onClick.AddListener(resetGame); // call resetGame method if button clicked
            ballManag.removeAll(); // remove all bobas
            // Debug.Log("Game Over");
        }
    }

    /* Resets the game' lives and score variables and text */
    private void resetGame()
    {
        gameLives = 5;
        lives.SetText(gameLives.ToString());
        gameScore = 0;
        score.SetText(gameScore.ToString());

        Time.timeScale = 1; // restart time

        gameOverScr.SetActive(false);
    }

    /* Set the tutorial screen active */
    private void tutorialMode()
    {
        tutorialScr.SetActive(true);
    }

    /* Set the tutorial screen to not active */
    private void closeTutorialMode()
    {
        tutorialScr.SetActive(false);
    }
}