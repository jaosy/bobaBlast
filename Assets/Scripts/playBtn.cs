using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playBtn : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Main");
    }
   

}
