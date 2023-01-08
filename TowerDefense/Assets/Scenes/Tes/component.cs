using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class component : MonoBehaviour
{
    GridCreator gridCreator;
    GridParent parent;
    public List<Vector2> touchPosition;
    float deltaX;
    float deltaY;

    void Start()
    {
        gridCreator = GridCreator.instance;
        parent = GetComponentInParent<GridParent>();
    }

    void OnMouseDown()
    {
        touchPosition.Add((Vector2)Input.mousePosition);
    }

    void OnMouseUp()
    {
        touchPosition.Add((Vector2)Input.mousePosition);

        if (Mathf.Abs(touchPosition[0].x - touchPosition[1].x) >
            Mathf.Abs(touchPosition[0].y - touchPosition[1].y))
        {
            deltaX = (touchPosition[0].x - touchPosition[1].x) * -1;
            if (deltaX < 0)
            {
                deltaX = -1;

                // find grid that in left of this grid using gridCreator
                GridParent grid = gridCreator.Grids.Find(x => x.transform.position.x < transform.position.x);

                // instantiate component prefab
                GameObject instance = Instantiate(grid.componentPrefab, grid.transform.position, Quaternion.identity, grid.transform);
                instance.transform.localPosition = new Vector3(instance.transform.localPosition.x, instance.transform.localPosition.y + 3, instance.transform.localPosition.z);
                // add component to left grid
                grid.components.Add(parent.components[parent.components.Count - 1]);

                // destroy component prefab
                Destroy(parent.components[parent.components.Count - 1]);
                // remove component from grid
                parent.components.Remove(parent.components[parent.components.Count - 1]);

            }
            else
            {
                deltaX = 1;
                // do otherwise
                // find grid that in right of this grid using gridCreator
                GridParent grid = gridCreator.Grids.Find(x => x.transform.position.x > transform.position.x);

                // instantiate component prefab
                GameObject instance = Instantiate(grid.componentPrefab, grid.transform.position, Quaternion.identity, grid.transform);
                instance.transform.localPosition = new Vector3(instance.transform.localPosition.x, instance.transform.localPosition.y + 3, instance.transform.localPosition.z);
                // add component to right grid
                grid.components.Add(parent.components[parent.components.Count - 1]);

                // destroy component prefab
                Destroy(parent.components[parent.components.Count - 1]);
                // remove component from grid
                parent.components.Remove(parent.components[parent.components.Count - 1]);
            }
        }
        else
        {
            deltaY = (touchPosition[0].y - touchPosition[1].y) * -1;
            if (deltaY < 0)
            {
                deltaY = -1;

                // find grid that in top of this grid using gridCreator
                GridParent grid = gridCreator.Grids.Find(x => x.transform.position.y > transform.position.y);

                // instantiate component prefab
                GameObject instance = Instantiate(grid.componentPrefab, grid.transform.position, Quaternion.identity, grid.transform);
                instance.transform.localPosition = new Vector3(instance.transform.localPosition.x, instance.transform.localPosition.y + 3, instance.transform.localPosition.z);
                // add component to top grid
                grid.components.Add(parent.components[parent.components.Count - 1]);

                // destroy component prefab
                Destroy(parent.components[parent.components.Count - 1]);
                // remove component from grid
                parent.components.Remove(parent.components[parent.components.Count - 1]);

            }
            else
            {
                deltaY = 1;
                // do otherwise
                // find grid that in bottom of this grid using gridCreator
                GridParent grid = gridCreator.Grids.Find(x => x.transform.position.y < transform.position.y);

                // instantiate component prefab
                GameObject instance = Instantiate(grid.componentPrefab, grid.transform.position, Quaternion.identity, grid.transform);
                instance.transform.localPosition = new Vector3(instance.transform.localPosition.x, instance.transform.localPosition.y + 3, instance.transform.localPosition.z);
                // add component to bottom grid
                grid.components.Add(parent.components[parent.components.Count - 1]);

                // destroy component prefab
                Destroy(parent.components[parent.components.Count - 1]);
                // remove component from grid
                parent.components.Remove(parent.components[parent.components.Count - 1]);
            }
        }


        touchPosition.Clear();
    }
}
