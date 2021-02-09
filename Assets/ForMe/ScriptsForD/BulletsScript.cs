using UnityEngine;

public class BulletsScript : MonoBehaviour {

	

	public int damageOfTheBullets = 45;
	public float speedOfTheBullets = 65f;
    Transform enemyTarget;
	public float radiusOfExploding = 0f;
	public GameObject impactEffect;
	
	public void SeekingTo (Transform _target)
	{
		enemyTarget = _target;
	}
    
	void Update () {

		if (enemyTarget == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 direction
            = enemyTarget.position - transform.position;
		float CurrentDistanceF = speedOfTheBullets * Time.deltaTime;

		if (direction.magnitude <= CurrentDistanceF)
		{
			HittingTheTarget();
			return;
		}

		transform.Translate(direction.normalized * CurrentDistanceF, Space.World);
		transform.LookAt(enemyTarget);

	}

	void HittingTheTarget ()
	{
		GameObject EffectForHitting
            = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(EffectForHitting, 3f);

		if (radiusOfExploding > 0f)
		{
			Exploding();
		} else
		{
			Damage(enemyTarget);
		}

		Destroy(gameObject);
	}

	void Exploding ()
	{
		Collider[] collidersArray = Physics.OverlapSphere(transform.position, radiusOfExploding);
		foreach (Collider collider in collidersArray)
		{
			if (collider.tag == "Enemy")
			{
				Damage(collider.transform);
			}
		}
	}

	void Damage (Transform enemy)
	{
		EnemyScript e = enemy.GetComponent<EnemyScript>();

		if (e != null)
		{
			e.TakingDamage(damageOfTheBullets);
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, radiusOfExploding);
	}
}
