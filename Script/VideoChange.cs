using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoChange : MonoBehaviour
{
    private int videoNumber;
    [SerializeField] private GameObject video1; // The first video
    [SerializeField] private GameObject video2; // The second video
    [SerializeField] private GameObject video3; // The third video

    // Start is called before the first frame update
    void Start()
    {
        videoNumber = UnityEngine.Random.Range(1, 4); // Generates a random number between 1 and 3


    }

    // Update is called once per frame
    void Update()
    {
        switch (videoNumber)
        {
            case 1:
                // Play video 1
                video1.SetActive(true);
                break;
            case 2:
                video2.SetActive(true);
                // Play video 2
                break;
            case 3:
                video3.SetActive(true);
                // Play video 3
                break;
        }

    }
}
