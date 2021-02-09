using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{

    public GameObject Menu;
    public Vector3 mousePos;
    public static MenuSpawner Instance; 


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Menu.SetActive(true);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {

                Debug.Log(hit.collider.gameObject.transform.position);
                mousePos = hit.point;

            }
            StartCoroutine(disableMenu());
        }

    }
    IEnumerator disableMenu()
    {
        yield return new WaitForSeconds(5f);
        Menu.SetActive(false);
    }




}
