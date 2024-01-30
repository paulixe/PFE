using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    Text text;
    float timeElapsed = 0f;

    float timeRemaining =>Mathf.Max(0, Settings.GameTime - timeElapsed);
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        RefreshCounter();
    }
    void RefreshCounter()
    {
        int minutes = Mathf.FloorToInt(timeRemaining/60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        string secondsDisplay = seconds < 10 ? "0" + seconds : seconds.ToString();
        text.text = minutes + ":" + secondsDisplay;
    }
}
