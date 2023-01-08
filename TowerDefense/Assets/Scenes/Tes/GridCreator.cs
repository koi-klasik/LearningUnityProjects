using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    public List<GridParent> Grids;
    public GameObject GridPrefab;

    // Singleton
    public static GridCreator instance;
    void Awake()
    {
        if (instance != null) return;
        instance = this;
    }
}
