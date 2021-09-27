using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentManager : MonoBehaviour
{
    public static AugmentManager current;
    public List<Augment> augments;

    private void Awake()
    {
        current = this;

        for (int i = 0; i < augments.Count; i++)
        {
            augments[i].Init();
        }
    }

    public static List<Augment> GetAugments()
    {
        return current.augments;
    }
}
