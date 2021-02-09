using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementTwo : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    Animator animations;
    private EnemyScript enemy;


    void Start()
    {
        enemy = GetComponent<EnemyScript>();
        animations = GetComponent<Animator>();
        target = WayPointsTwo.points[0];
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
        if (wavepointIndex >= WayPointsTwo.points.Length - 1)
        {

            EndPath();
            return;
        }

        wavepointIndex++;
        target = WayPointsTwo.points[wavepointIndex];
    }

    void EndPath()
    {
        //animations.SetBool("Attacks", true);
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        WaveSpawnerTwo.EnemiesAlivee--;
        Destroy(gameObject);
    }

}
