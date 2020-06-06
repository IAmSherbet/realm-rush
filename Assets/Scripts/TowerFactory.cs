using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] int towerLimit = 5;

    public void AddTower(TowerPlatform towerPlatform)
    {
        var sceneTowers = FindObjectsOfType<Tower>();

        if (sceneTowers.Length < 5)
        {
            InstantiateNewTower(towerPlatform);
        }
        else
        {
            MoveExistingTower();
        }
    }

    private static void MoveExistingTower()
    {
        //todo: move first tower placed upon reaching limit
        print("Tower limit reached");
    }

    private void InstantiateNewTower(TowerPlatform towerPlatform)
    {
        Instantiate(tower, towerPlatform.transform.position, Quaternion.identity);
        towerPlatform.isPlaceable = false;
    }
}
