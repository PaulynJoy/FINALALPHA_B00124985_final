using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstaclePlayerboom : MonoBehaviour
{

    PlayerMovement playerMovement;



    // Start is called before the first frame update
    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Player boom
            playerMovement.Boom();
        }
    }


}
