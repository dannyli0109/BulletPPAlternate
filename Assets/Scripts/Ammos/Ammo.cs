using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ammo
{
    void Init();
    void OnUpdate();
    void OnHit();
    void OnFixedUpdate();
}
