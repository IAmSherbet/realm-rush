using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatform : MonoBehaviour
{
    [SerializeField] Tower tower;
    bool isPlaceable = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (isPlaceable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("Clicked " + gameObject.name);
                Instantiate(tower, transform.position, Quaternion.identity);
                isPlaceable = false;
            }
        } else
        {
            //do nothing
            print("Tower already placed here");
        }
    }
}
