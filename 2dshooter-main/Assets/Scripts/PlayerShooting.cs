using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform BulletPos;
    public GameObject PlayerBullet;

    private SpriteRenderer sr;

    private Animator anim;
    public bool Shooting = false;

    public float timeBetweenShots;
    private bool canshot = true;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            anim.SetBool("Shooting", true);
        }
        else
        {
            anim.SetBool("Shooting", false);
        }

    }

    public void Shoot()
    {
        Instantiate(PlayerBullet, BulletPos.position, BulletPos.rotation);
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