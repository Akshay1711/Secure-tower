using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyScript))]
public class EnemyMovement : MonoBehaviour {

	Transform target;
    int wavepointIndex = 0;
    Animator animations;
	EnemyScript enemy;


	void Start()
	{
		enemy = GetComponent<EnemyScript>();
        animations = GetComponent<Animator>();
		target = Waypoints.points[0];
	}

    void Update()
    {
        Vector3 dir = target.position - transform.position;
      //  float angle = Mathf.Atan2(dir.y , dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.LookRotation(dir);
		transform.Translate(dir.normalized * enemy.SpeedValue * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		enemy.SpeedValue = enemy.startSpeed;
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
           
			EndPath();
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

	void EndPath()
	{
        //animations.SetBool("Attacks", true);
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}

}
