using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{

    public GameObject Canon;
    public GameObject Gun;
    public GameObject LazerBeam;
    public Vector3 spawnPoint = Vector3.zero;
    public static WeaponSpawner Instance;


    private void Start()
    {
        Instance = this;
    }
    public void SpawnWeapon(int weapoId)
    {
        Debug.Log("weaponm position is "+ MenuSpawner.Instance.mousePos);
        if (weapoId == 0)
        {
            Instantiate(Canon, MenuSpawner.Instance.mousePos, Quaternion.identity);
            MenuSpawner.Instance.Menu.SetActive(false);
        }
        if (weapoId == 1)
        {
            Instantiate(Gun, MenuSpawner.Instance.mousePos, Quaternion.identity);
            MenuSpawner.Instance.Menu.SetActive(false);
        }
        if (weapoId == 2)
        {
            Instantiate(LazerBeam, MenuSpawner.Instance.mousePos, Quaternion.identity);
            MenuSpawner.Instance.Menu.SetActive(false);
        }
    }
}
