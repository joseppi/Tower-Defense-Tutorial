using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyMoneyUI : MonoBehaviour {

	public Text moneyText;

	// Update is called once per frame
	void Update () {        
		moneyText.text = "$" + StatsEnemy.Money.ToString();
	}
}
