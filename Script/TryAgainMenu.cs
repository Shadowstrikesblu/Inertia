using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void TryAgain()
    {
        SceneManager.LoadScene("SurvivalLevel");
    }
    public void ReturnToGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
