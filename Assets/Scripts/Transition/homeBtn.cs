using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class homeBtn : MonoBehaviour
{
   public void returnHome()
    {
        SceneManager.LoadScene("home_scr");
    }
}
