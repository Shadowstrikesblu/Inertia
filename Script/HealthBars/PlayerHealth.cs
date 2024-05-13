using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    private float health;
    public float maxHealth = 100;
    [Header("Health Bar ")]
    public float chipSpeed = 2f;
    private float lerpTimer;
    public Image FrontHealthBar;
    public Image BackHealthBar;
    public TextMeshPro healthText;

    [Header("Damage Overlay")]
    public Image damageOverlay;

    [SerializeField] AudioSource audioSource; // The AudioSource component
    [SerializeField] AudioClip damageSound; // The sound to play when the player gets damaged
    public float duration = 2;
    public float fadeSpeed = 1.5f;

    public float durationTimer;

    [Header("Health Regen")]

    public Image healOverlay;

    public float regenDuration = 2;

    public float regenFadeSpeed = 1.5f;

    public float healdurationTimer;
    void Start()
    {
        health = maxHealth;
        damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 0);
        healOverlay.color = new Color(healOverlay.color.r, healOverlay.color.g, healOverlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if (damageOverlay.color.a > 0)
        {
            if (health < 30)
            {
                return;
            }
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAplha = damageOverlay.color.a;
                tempAplha -= fadeSpeed * Time.deltaTime;
                damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, tempAplha);
            }
        }
        if (healOverlay.color.a > 0)
        {
            healdurationTimer += Time.deltaTime;
            if (healdurationTimer > regenDuration)
            {
                float tempAplha = healOverlay.color.a;
                tempAplha -= regenFadeSpeed * Time.deltaTime;
                healOverlay.color = new Color(healOverlay.color.r, healOverlay.color.g, healOverlay.color.b, tempAplha);
            }
        }
        // UpdateTextUI();
    }
    // public void UpdateTextUI()
    // {
    //     healthText.text = "health " + health;
    // }
    public void UpdateHealthUI()
    {
        // Debug.Log("health: " + health);
        float fillF = FrontHealthBar.fillAmount;
        float fillB = BackHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            FrontHealthBar.fillAmount = hFraction;
            BackHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            BackHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            BackHealthBar.color = Color.green;
            BackHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            FrontHealthBar.fillAmount = Mathf.Lerp(fillF, BackHealthBar.fillAmount, percentComplete);
        }

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        durationTimer = 0f;
        damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 1);
        audioSource.PlayOneShot(damageSound);
    }

    public void RestoreHealth(float restore)
    {
        health += restore;
        lerpTimer = 0f;
        durationTimer = 0f;
        healOverlay.color = new Color(healOverlay.color.r, healOverlay.color.g, healOverlay.color.b, 1);
    }
}
