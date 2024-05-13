using UnityEngine.Events;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    private const string PlayerTag = "Player";
    public UnityEvent OnInteract;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Interact()
    {

        // Invoke the OnInteract event
        OnInteract.Invoke();

        // Destroy the object
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.gameObject.CompareTag(PlayerTag))
        {
            // Destroy the health kit
            Destroy(gameObject);
        }
    }

}
