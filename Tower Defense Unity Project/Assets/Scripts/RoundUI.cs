using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundUI : MonoBehaviour
{
    public Text roundText;

    // Update is called once per frame
    void Update()
    {
        int roundDisplay = StatsPlayer.Rounds;
        roundText.text = "Round " + roundDisplay.ToString();
    }
}
