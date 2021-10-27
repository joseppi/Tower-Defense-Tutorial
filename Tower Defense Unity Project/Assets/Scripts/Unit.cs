using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour {

	public float startSpeed = 10f;

	[HideInInspector]
	public float speed;

	public float startHealth = 100;
	public float health;
    private float bonusHealthHP = 0;
    public int level = 1;    

	public int worth = 50;

	public GameObject deathEffect;

	[Header("Unity Stuff")]
	public Image healthBar;

	private bool isDead = false;

	void Start ()
	{
		speed = startSpeed;
		health = startHealth + bonusHealthHP;        
    }

    public void UpdateLevelUp()
    {
        bonusHealthHP = startHealth * level * 0.10f;
        this.Start();
    }

    public void FixedUpdate()
    {
        
    }    

    public void TakeDamage (float amount)
	{        
		health -= amount;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	public void Slow (float pct)
	{
		speed = startSpeed * (1f - pct);
	}

	void Die ()
	{
		isDead = true;

		StatsPlayer.Money += worth;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		Destroy(gameObject);
	}

    public void SetHealth(float newHealth)
    {
        this.health = newHealth;
    }

    public float GetHealth()
    {
        return health;
    }
}
