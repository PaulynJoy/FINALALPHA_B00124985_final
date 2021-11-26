using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTile : MonoBehaviour
{

    SpawnManager roadSpawner;
    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GameObject.FindObjectOfType<SpawnManager>();
   
    }

    private void OnTriggerExit(Collider other)
    {
        roadSpawner.GroundSpawnTile(true);
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {

    }

    //obstacle
    public GameObject obstaclePrehab;

    public void SpawnObstacle()
    {
        //random 
        int obstacleSpawnerIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnerIndex).transform;

        //spawner
        Instantiate(obstaclePrehab, spawnPoint.position, Quaternion.identity,transform);
    }

    public GameObject scorePrefab;

    public void SpawnCoins ()
    {
        int moraSpawner = 3;
        //amount coins
    for (int i = 0; i<moraSpawner; i++)
			{
            GameObject temp = Instantiate(scorePrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
			}

    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        //Generates the coins randomly from the area of min and max of the ground
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        //Just activates if coins are accidentaly done outside of the collider or when the error happens
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}

