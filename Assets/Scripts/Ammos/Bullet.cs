using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamageDealer, IBouncable
{
    [SerializeField]
    AmmoStats stats;
    float time;
    Vector3 velocity;
    int currentBounces;

    public void Init()
    {
        velocity = transform.forward * stats.speed;
        time = 0;
        currentBounces = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= stats.lifeTime)
        {
            Destroy(gameObject);
        }
        velocity = transform.forward * stats.speed;
    }

    private void FixedUpdate()
    {
        transform.position += velocity * Time.fixedDeltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currentBounces < stats.bounces)
        {
            Bounce(collision);
            currentBounces++;
        }
        GameObject hitObject = collision.gameObject;
        IHittable hittable = hitObject.GetComponent<IHittable>();
        if (hittable != null)
        {
            hittable.OnHit(this);
        }

        IDamagable damagable = hitObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.OnDamage(this);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        Destroy(gameObject);
    }

    public float GetDamage()
    {
        return stats.damage;
    }

    public void Bounce(Collision collision)
    {
        Vector3 normal = new Vector3(collision.contacts[0].normal.x, 0, collision.contacts[0].normal.z);
        Vector3 reflectionDir = Vector3.Reflect(gameObject.transform.forward, normal);
        gameObject.transform.forward = reflectionDir;
    }
}
