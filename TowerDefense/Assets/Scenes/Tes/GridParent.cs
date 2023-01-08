using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridParent : MonoBehaviour
{
    public List<GameObject> components;
    public GameObject componentPrefab;

    void Start()
    {
        GameObject comp = Instantiate(componentPrefab, transform.position, Quaternion.identity, transform);
        comp.transform.parent = transform;
        comp.transform.localPosition = Vector3.zero;
        components.Add(comp);
    }
}
