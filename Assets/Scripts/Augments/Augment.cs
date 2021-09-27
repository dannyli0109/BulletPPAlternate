using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Augment : ScriptableObject
{

    public List<Action<Bullet>> OnAttached;
    public List<Action<Bullet>> OnHit;
    public List<Action<Bullet>> OnDamage;
    public List<Action<Bullet>> OnBounce;
    public List<Action<Bullet>> OnCrit;

    public abstract void Init();

    public void InitEvents()
    {
        OnAttached = new List<Action<Bullet>>();
        OnHit = new List<Action<Bullet>>();
        OnDamage = new List<Action<Bullet>>();
        OnBounce = new List<Action<Bullet>>();
        OnCrit = new List<Action<Bullet>>();
    }

    public void AddOnAttachedEvent(Action<Bullet> action)
    {
        OnAttached.Add(action);
    }

    public void AddOnHitEvent(Action<Bullet> action)
    {
        OnHit.Add(action);
    }

    public void AddOnDamageEvent(Action<Bullet> action)
    {
        OnDamage.Add(action);
    }

    public void AddOnBounceEvent(Action<Bullet> action)
    {
        OnBounce.Add(action);
    }

    public void AddOnCritEvent(Action<Bullet> action)
    {
        OnCrit.Add(action);
    }

    public abstract void Shoot(Transform transform);
}
