﻿using UnityEngine;
using UnityEngine.UI;

public class LivesPlayerUI : MonoBehaviour {

	public Text livesText;

	// Update is called once per frame
	void Update () {
		livesText.text = StatsPlayer.Lives.ToString() + " LIVES";
	}
}
