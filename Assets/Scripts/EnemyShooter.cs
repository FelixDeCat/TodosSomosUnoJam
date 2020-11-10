using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Enemy
{
    public Transform shootingPos;
    public GameObject bulletPrefab;
    public float CDShoot;
    float timer = 0;
    bool canShoot = true;

    public override void Update()
    {
        base.Update();

        timer += Time.deltaTime;
        if (timer >= CDShoot)
        {
            timer = 0;
            canShoot = true;
        }

        if (canShoot) Shoot();
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = shootingPos.transform.position;
        canShoot = false;
        timer = 0;
    }

}
