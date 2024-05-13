using System.Collections;
using System.Numerics;
using TMPro;
using UnityEngine;

public class SpeedCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI SpeedText; // The TextMeshProUGUI object
    // [SerializeField] Rigidbody playerRigidbody; // The Rigidbody of the player
    public float speed; // The speed of the player

    void Start()
    {
        // Get the Rigidbody component of the player
        StartCoroutine(CalcSpeed());
    }
    IEnumerator CalcSpeed()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            UnityEngine.Vector3 prevPos = transform.position;
            yield return new WaitForFixedUpdate();
            speed = Mathf.RoundToInt((transform.position - prevPos).magnitude / Time.fixedDeltaTime);
        }
    }
    private void Update()
    {

        // Calculate the speed of the player without considering the effect of gravity
        // Vector3 horizontalVelocity = playerRigidbody.velocity;
        // horizontalVelocity.y = 0; // Ignore vertical speed
        // float speed = horizontalVelocity.magnitude;

        // Display the speed
        SpeedText.text = speed.ToString("0.00") + " m/s";
    }
}