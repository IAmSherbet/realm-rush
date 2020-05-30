using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Queue<Waypoint> queue = new Queue<Waypoint>();

    bool isRunning = true;

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
        Pathfind();
        //ExploreNeighbours();
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue(); // returns the front of the queue
            searchCenter.isExplored = true;
            print("Searching from " + searchCenter); //todo: remove
            StopIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
        }

        print("Finished pathfinding?");
    }

    private void StopIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Searching from end node, therefore stopping"); // todo: remove
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint currentPosition)
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourVector2Int = currentPosition.GetGridPos() + direction;

            try { QueueNewNeighbour(neighbourVector2Int); }
            catch { }
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
            neighbourWaypoint.SetTopColor(Color.blue);

            queue.Enqueue(neighbourWaypoint);

            print("Queueing " + neighbourWaypoint);
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
