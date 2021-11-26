using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject roadTile;
    Vector3 spawnerTile;

    //spawns tiles
    public void GroundSpawnTile(bool spawnItems)
    {
       GameObject temp = Instantiate(roadTile, spawnerTile, Quaternion.identity);
       spawnerTile = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            temp.GetComponent<RoadTile>().SpawnObstacle();
            temp.GetComponent<RoadTile>().SpawnCoins();
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            if (i < 3)
            {
                GroundSpawnTile(false);
            }
            else
            {
                GroundSpawnTile(true);
            }
        }
      
    }

}
