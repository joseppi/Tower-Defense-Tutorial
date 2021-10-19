using UnityEngine;
using UnityEngine.UI;

public class LivesEnemyUI : MonoBehaviour {

	public Text livesText;

	// Update is called once per frame
	void Update () {
		livesText.text = StatsEnemy.Lives.ToString() + " LIVES";
	}
}
