using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower tower;

    Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(TowerPlatform towerPlatform)
    {

        if (towers.Count < 2)
        {
            InstantiateNewTower(towerPlatform);
            print(towers.Count + " tower(s) in scene");
        }
        else
        {
            MoveExistingTower(towerPlatform);
        }
    }

    private void InstantiateNewTower(TowerPlatform towerPlatform)
    {
        Tower placedTower = Instantiate(tower, towerPlatform.transform.position, Quaternion.identity);
        placedTower.builtOnPlatform = towerPlatform;

        towerPlatform.TogglePlaceable();

        towers.Enqueue(placedTower);
    }

    private void MoveExistingTower(TowerPlatform newPlatform)
    {
        // take the bottom tower off the queue
        Tower towerBeingMoved = towers.Dequeue();
        // set old platform as placeable
        towerBeingMoved.builtOnPlatform.TogglePlaceable();

        // set the new platform position
        towerBeingMoved.transform.position = newPlatform.transform.position;
        // set tower's new platform 
        towerBeingMoved.builtOnPlatform = newPlatform;
        // set new platform as not placeable
        newPlatform.TogglePlaceable();

        // add the tower on top of the queue
        towers.Enqueue(towerBeingMoved);
    }
}
