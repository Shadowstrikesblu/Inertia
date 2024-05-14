using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText; // The TextMeshProUGUI object
    [SerializeField] float elapsedTime; // Two minutes in seconds



    private void Update()
    {
        // Display the time remaining
        // timerText.text = "Time remaining: " + timeRemaining;
        elapsedTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (elapsedTime <= 0)
        {
            SceneManager.LoadScene("GoodJobScene");
        }
    }
}