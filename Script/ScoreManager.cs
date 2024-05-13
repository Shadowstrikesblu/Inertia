using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance
    [SerializeField] TextMeshProUGUI scoreText; // The TextMeshProUGUI object

    public int score = 0; // The player's score

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
    public void Update()
    {
        scoreText.text = "Score: " + score;
    }
}