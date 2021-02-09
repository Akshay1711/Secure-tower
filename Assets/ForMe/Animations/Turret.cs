using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	Transform Targetting;
    EnemyScript EnemyTarget;
	[Header("rangeOf")]
	public float theRange = 15f;
	[Header("default Bullets")]
	public GameObject bulletPrefab;
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	public bool useLaser = false;
	public int damageOverTime = 30;
	public float slowAmount = .5f;
	public LineRenderer lineRenderer;
	public ParticleSystem impactEffect;
	public Light impactLight;
	[Header("set up")]
	public string enemyTag = "Enemy";
	public Transform partToRotate;
	public float turnSpeed = 10f;
	public Transform firePoint;
    
	void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f); //for repeating
	}
	
	void UpdateTarget ()
	{
		GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag(enemyTag); //getting the enemiesArray
		float theMinimumDistance = Mathf.Infinity;
		GameObject nearbyEnemy = null;
		foreach (GameObject enemy in enemiesArray)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < theMinimumDistance)
			{
				theMinimumDistance = distanceToEnemy;
				nearbyEnemy = enemy;
			}
		}

		if (nearbyEnemy != null && theMinimumDistance <= theRange)
		{
			Targetting = nearbyEnemy.transform;
			EnemyTarget = nearbyEnemy.GetComponent<EnemyScript>();
		} else
		{
			Targetting = null;
		}

	}

	// Update is called once per frame
	void Update () {
		if (Targetting == null)
		{
			if (useLaser)
			{
				if (lineRenderer.enabled)
				{
					lineRenderer.enabled = false;
					impactEffect.Stop();
					impactLight.enabled = false;
				}
			}

			return;
		}

		LockingIntoOneTarget();

		if (useLaser)
		{
			Laser();
		} else
		{
			if (fireCountdown <= 0f)
			{
				Shooting();
				fireCountdown = 1f / fireRate;
			}

			fireCountdown -= Time.deltaTime;
		}

	}

	void LockingIntoOneTarget ()
	{
		Vector3 direction =
            Targetting.position - transform.position;
		Quaternion RotationOfTheLook = 
            Quaternion.LookRotation(direction);
		Vector3 rotations =
            Quaternion.Lerp(partToRotate.rotation, RotationOfTheLook, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotations.y, 0f);
	}

	void Laser ()
	{
		EnemyTarget.TakingDamage(damageOverTime * Time.deltaTime);
		EnemyTarget.SlowEffect(slowAmount);

		if (!lineRenderer.enabled)
		{
			lineRenderer.enabled = true;
			impactEffect.Play();
			impactLight.enabled = true;
		}

		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, Targetting.position);

		Vector3 dir = firePoint.position - Targetting.position;

		impactEffect.transform.position = Targetting.position + dir.normalized;

		impactEffect.transform.rotation = Quaternion.LookRotation(dir);
	}

	void Shooting ()
	{
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		BulletsScript bullet = bulletGO.GetComponent<BulletsScript>();

		if (bullet != null)
			bullet.SeekingTo(Targetting);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, theRange);
	}
}
