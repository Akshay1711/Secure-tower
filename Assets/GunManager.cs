using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GameObject target;
    public float range = 15f;
    public string enemTag = "Enemy";
    public Transform partToRotate;
    public GameObject spawnPoint;
    public GameObject bullet;
    public int bulletCount = 5;
    // Start is called before the first frame update
    void Start()
    {
     //  InvokeRepeating("GetTarget", 0f, 0.5f);
    }
  

    void GetTarget()
    {
        GameObject[] enemArr = GameObject.FindGameObjectsWithTag(enemTag);
        float minDist = Mathf.Infinity;
        GameObject nearEnem = null;
        foreach(GameObject enem in enemArr)
        {
            float distToEnem = Vector3.Distance(transform.position, enem.transform.position);
            if(distToEnem < minDist)
            {
                minDist = distToEnem;
                nearEnem = enem;
            }
        }
        if (nearEnem != null && minDist <= range)
        {
            target = nearEnem;
            shoot();
        }
        else
            target = null;

    }

    void shoot() 
    {
        GameObject newbullet = ObjectPool.sharedInstance.getPooledObjects();
        newbullet.transform.position = spawnPoint.transform.position + spawnPoint.transform.forward * 0.5f;
        newbullet.GetComponent<Rigidbody>().velocity = spawnPoint.transform.position * 3f;
        newbullet.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemArr = GameObject.FindGameObjectsWithTag(enemTag);
        float minDist = Mathf.Infinity;
        GameObject nearEnem = null;
        foreach (GameObject enem in enemArr)
        {
            float distToEnem = Vector3.Distance(transform.position, enem.transform.position);
            if (distToEnem < minDist)
            {
                minDist = distToEnem;
                nearEnem = enem;
            }
        }
        if (nearEnem != null && minDist <= range)
        {
            target = nearEnem;
            partToRotate.LookAt(target.transform.position);
            shoot();
        }
        else
            target = null;

        if (target == null)
            return;
    }

    void onDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);

    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(15f);
    }

}
