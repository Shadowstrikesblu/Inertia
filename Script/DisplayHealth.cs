using UnityEngine;
using UnityEngine.UI; // If you're using Text
// using TMPro; // Uncomment this line if you're using TextMeshProUGUI

public class DisplayHealth : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    private PlayerHealth playerHealth; // Reference to the PlayerHealth script
    private Text healthTextComponent; // If you're using Text
    // private TextMeshProUGUI healthTextComponent; // Uncomment this line if you're using TextMeshProUGUI

    void Start()
    {
        // Get the PlayerHealth script from the player GameObject
        playerHealth = player.GetComponent<PlayerHealth>();

        // Get the text component
        healthTextComponent = GetComponent<Text>(); // If you're using Text
        // healthTextComponent = GetComponent<TextMeshProUGUI>(); // Uncomment this line if you're using TextMeshProUGUI
    }

    void Update()
    {
        // Set the text to the player's health
        healthTextComponent.text = "" + playerHealth.maxHealth;
    }
}