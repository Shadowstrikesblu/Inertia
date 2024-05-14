using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("SurvivalLevel");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
