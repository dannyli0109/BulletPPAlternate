using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModelType
{
    Wall,
    Corner,
    Floor,
    Piller
}


public class Level : MonoBehaviour
{
    public Vector2 cellSize;
    public ModelType type;
    public float rotation;
    public GameObject[] prefabs;
}
