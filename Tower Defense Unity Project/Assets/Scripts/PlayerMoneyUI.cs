using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMoneyUI : MonoBehaviour {

	public Text moneyText;

	// Update is called once per frame
	void Update () {        
		moneyText.text = "$" + StatsPlayer.Money.ToString();
	}
}
