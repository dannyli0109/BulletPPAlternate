using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Augments/StandardBullet")]
public class StandardBullet : Augment
{
    public Bullet bulletPrefab;

    public override void Init()
    {
        InitEvents();
        AddOnHitEvent((bullet) =>
        {
            Debug.Log("hit");
        });
    }

    public override void Shoot(Transform transform)
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Init(this);
    }
}
