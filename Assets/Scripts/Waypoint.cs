using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false; // OK to have a public bool because waypoint is a data class

    public Waypoint exploredFrom;

    const int gridSize = 10;

    private void Update()
    {
        if (isExplored) { SetTopColor(Color.blue); }
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        if (topMeshRenderer.material.color == Color.green || topMeshRenderer.material.color == Color.black)
        {
            // todo: replace this with something more fail-proof
        } else
        {
            topMeshRenderer.material.color = color;
        }
    }
}
