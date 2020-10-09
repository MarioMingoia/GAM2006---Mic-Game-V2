using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListenIn : MonoBehaviour
{

    AudioClip microphoneInput;
    bool microphoneInitialized;
    public float sensitivity;
    public bool doIt;
    public Text myText;

    public float ourLevel;
    void Awake()
    {
        //init microphone input
        if (Microphone.devices.Length > 0)
        {
            microphoneInput = Microphone.Start(Microphone.devices[0], true, 999, 44100);
            microphoneInitialized = true;
        }
    }

    // Start is called before the first frame update

    // Get list of Microphone devices and print the names to the log
    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //get mic volume
        int dec = 128;
        float[] waveData = new float[dec];
        int micPosition = Microphone.GetPosition(null) - (dec + 1); // null means the first microphone
        microphoneInput.GetData(waveData, micPosition);

        // Getting a peak on the last 128 samples
        float levelMax = 0;
        for (int i = 0; i < dec; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        float level = Mathf.Sqrt(Mathf.Sqrt(levelMax));
        //For Debugging
        // Debug.Log(level);
        // Show the input level on screen
        level = level * 10;
        ourLevel = level;

        myText.text = level.ToString();

        if (level >= 2)
        {
            myText.GetComponent<Text>().color = Color.red;
        }
        if (level < 2)
        {
            myText.GetComponent<Text>().color = Color.blue;
        }

    }
}



