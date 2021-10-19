using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalTimeDisplay : MonoBehaviour
{
    Text totalTimeDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        totalTimeDisplay = GetComponent<Text>();
        SetTotalTimeDisplay(GameManager.totalMatchTime);
    }

    public void SetTotalTimeDisplay(float totalTime)
    {
        totalTimeDisplay.text = string.Format("{0:00:00}" + " Total Time Played", totalTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
