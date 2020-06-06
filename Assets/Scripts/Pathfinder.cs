using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up, // shorthand for Vector2Int(0,1)
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        if ( path.Count == 0 )
        {
            CalculatePath();
        }

        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green); //todo: consider moving to Waypoint.cs
        endWaypoint.SetTopColor(Color.black);
    }

    private void CreatePath()
    {
        path.Add(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;

        while (previous != startWaypoint)
        {
            //loop through intermediate waypoints
            path.Add(previous);
            previous = previous.exploredFrom;
        }

        path.Add(startWaypoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue(); // returns the front of the queue
            searchCenter.isExplored = true;
            StopIfEndFound();
            ExploreNeighbours();
        }
    }

    private void StopIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourVector2Int = searchCenter.GetGridPos() + direction;

            if (grid.ContainsKey(neighbourVector2Int))
            {
                QueueNewNeighbour(neighbourVector2Int);
            }
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourVector2Int)
    {
        Waypoint neighbourWaypoint = grid[neighbourVector2Int];

        if (neighbourWaypoint.isExplored || queue.Contains(neighbourWaypoint))
        {
            // do nothing. question: why not return; ?   
        }
        else
        {
            queue.Enqueue(neighbourWaypoint);

            neighbourWaypoint.exploredFrom = searchCenter;
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
