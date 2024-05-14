using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GoToMainMenuAfterDelay());
    }

    IEnumerator GoToMainMenuAfterDelay()
    {
        yield return new WaitForSeconds(10);

        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}