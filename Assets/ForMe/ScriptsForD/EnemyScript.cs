using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

	public float startSpeed = 10f;

	[HideInInspector]
	public float SpeedValue;
    float health;
	public float startingHealth = 50;
	public int worth = 50;
	public GameObject EffectForDeath;
    [Header("HealthS")]
    public Image BarOfTheHealth;
	bool isDead = false;

	void Start ()
	{
		SpeedValue = startSpeed;
		health = startingHealth;

    }

	public void TakingDamage (float amount)
	{
		health -= amount;

		BarOfTheHealth.fillAmount = health / startingHealth;

		if (health <= 0 && !isDead)
		{
			Die();
            isDead = false;
        }
	}

	public void SlowEffect (float pct)
	{
		SpeedValue = startSpeed * (1f - pct);
	}

	void Die ()
	{
		isDead = true;
		GameObject DiyingEffect = 
            (GameObject)Instantiate(EffectForDeath
            , transform.position, Quaternion.identity);
		Destroy(DiyingEffect, 5f);
		PlayerStats.Money += worth;
		WaveSpawnerTwo.EnemiesAlive--;
		WaveSpawnerTwo.EnemiesAlivee--;
		Destroy(gameObject);
	}

}
