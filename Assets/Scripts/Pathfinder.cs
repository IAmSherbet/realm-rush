using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Vector2Int[] directions =
    {
        Vector2Int.up, // shorthand for Vector2Int(0,1)
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    void Start()
    {
        LoadBlocks();
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.black);
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourPos = direction + startWaypoint.GetGridPos();
            try
            {
                grid[neighbourPos].SetTopColor(Color.blue);
            }
            catch
            {

            }
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();

            // check if any blocks are overlapping
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block" + waypoint);
            } else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}
