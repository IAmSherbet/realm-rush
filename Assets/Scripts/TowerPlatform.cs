using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatform : MonoBehaviour
{
    public bool isPlaceable = true;

    private void OnMouseOver()
    {
        if (isPlaceable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
        } else
        {
            //do nothing
            print("Tower already placed here");
        }
    }

    public void TogglePlaceable()
    {
        isPlaceable = !isPlaceable;
    }
}
