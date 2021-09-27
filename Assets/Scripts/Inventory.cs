using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    // Start is called before the first frame update
    List<Augment> augments;
    int capacity;


    public Inventory(int capacity)
    {
        augments = new List<Augment>();
        this.capacity = capacity;
    }

    public Augment this[int index]
    {
        get => augments[index];
    }

    public int Count
    {
        get => augments.Count;
    }

    public bool AddAugment(Augment augment)
    {
        if (augments.Count >= capacity) return false;
        augments.Add(augment);
        return true;
    }

    
}
