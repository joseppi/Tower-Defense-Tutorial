using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	private Transform target;
	private Unit targetEnemy;
    private float tParam = 0;
    private float currentDamageOverTime = 0;

    [Header("General")]

	public float range = 15f;

	[Header("Use Bullets (default)")]
	public GameObject bulletPrefab;
	public float fireRate = 1f;
    public int damage = 30;
    private float fireCountdown = 0f;

	[Header("Use Laser")]
	public bool useLaser = false; 
	
	public float slowAmount = .5f;

	public LineRenderer lineRenderer;
	public ParticleSystem impactEffect;
	public Light impactLight;

	[Header("Unity Setup Fields")]

	public string targetTag = "Enemy";

	public Transform partToRotate;
	public float turnSpeed = 10f;

	public Transform firePoint;

    public GameObject[] enemies;

    // Use this for initialization
    void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.1f);
	}
	
	void UpdateTarget ()
	{
        enemies = GameObject.FindGameObjectsWithTag(targetTag);
		float shortestDistance = Mathf.Infinity;
        float firstEnemyInRange = Mathf.Infinity;
		GameObject targetEnemyGO = null;
		foreach (GameObject enemy in enemies)
		{            
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); //Get closes enemy

            if (useLaser && distanceToEnemy < range) //Lasers get first enemy in range and stops looking
            {
                firstEnemyInRange = distanceToEnemy;
                targetEnemyGO = enemy;
                break;
            }
            else if (distanceToEnemy < shortestDistance) //Turrets always aim for closest enemy
            {                                    
                shortestDistance = distanceToEnemy;
                targetEnemyGO = enemy;
            }         
		}

		if (targetEnemyGO != null)
		{
            if (shortestDistance <= range)
            {
                target = targetEnemyGO.transform;
                targetEnemy = targetEnemyGO.GetComponent<Unit>();
            }
            else if (useLaser && firstEnemyInRange <= range)
            {
                target = targetEnemyGO.transform;
                targetEnemy = targetEnemyGO.GetComponent<Unit>();
            }
			
		}
        else
		{
            target = null;            					
		}
	}

	// Update is called once per frame
	void Update () {
		if (target == null)
		{
			if (useLaser)
			{
				if (lineRenderer.enabled)
				{
					lineRenderer.enabled = false;
					impactEffect.Stop();
					impactLight.enabled = false;
				}
                tParam = 0; //Reset Laser Damage when target is lost
            }

			return;
		}

		LockOnTarget();

		if (useLaser)
		{
			Laser();
		} 
        else
		{
			if (fireCountdown <= 0f)
			{
				Shoot();
				fireCountdown = 1f / fireRate;
			}

			fireCountdown -= Time.deltaTime;
		}

	}

	void LockOnTarget ()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

	void Laser ()
	{
        
        if (tParam < 1)
        {
            tParam += Time.deltaTime*fireRate;
        }        
        if (tParam < 0.9f)
        {
            currentDamageOverTime = Mathf.Lerp(0, damage/3, tParam);
        }
        else if (tParam >= 0.9f)
        {
            currentDamageOverTime = Mathf.Lerp(0, damage, tParam);
        }
        
        


        targetEnemy.TakeDamage(currentDamageOverTime* Time.deltaTime);
		targetEnemy.Slow(slowAmount);

		if (!lineRenderer.enabled)
		{
			lineRenderer.enabled = true;
			impactEffect.Play();
			impactLight.enabled = true;
		}

		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, target.position);

		Vector3 dir = firePoint.position - target.position;

		impactEffect.transform.position = target.position + dir.normalized;

		impactEffect.transform.rotation = Quaternion.LookRotation(dir);
	}

	void Shoot ()
	{
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);        
		Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.damage = this.damage;

		if (bullet != null)
			bullet.Seek(target);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
