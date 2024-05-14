using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockMouse : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        // Lock the cursor to the center of the screen
        // Cursor.lockState = CursorLockMode.None;

        // // Hide the cursor
        // Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        // if (SceneManager.GetActiveScene().name == "SurvivalLevel")
        // {
        //     // Lock the cursor and hide it
        //     Cursor.lockState = CursorLockMode.Locked;
        //     Cursor.visible = false;
        // }
        // else
        // {
        //     // Unlock the cursor and make it visible
        //     Cursor.lockState = CursorLockMode.None;
        //     Cursor.visible = true;
        // }
    }
}
