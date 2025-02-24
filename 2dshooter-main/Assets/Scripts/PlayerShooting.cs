using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePos;
    public GameObject bullet;
    public float timeBetweenShots;
    private bool canshot = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0) && canshot)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate (bullet, firePos.position, firePos.rotation);
        StartCoroutine(ShootDelay());
    }

    /// <summary>
    /// añadimos una corrutina
    /// </summary>
    /// <returns></returns>
    IEnumerator ShootDelay()
    {
        canshot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        canshot = true;
    }
}
