using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, Ammo
{
    public AmmoStats stats;
    float time;
    Vector3 velocity;
    public void Init()
    {
        velocity = transform.forward * stats.speed;
        time = 0;
    }

    public void OnHit()
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        time += Time.deltaTime;
        if (time >= stats.lifeTime)
        {
            Destroy(gameObject);
        }
    }

    public void OnFixedUpdate()
    {
        transform.position += velocity * Time.fixedDeltaTime;
    }

    private void Update()
    {
        OnUpdate();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
}
