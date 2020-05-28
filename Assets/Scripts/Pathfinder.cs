using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    void Start()
    {
        LoadBlocks();
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.black);
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
