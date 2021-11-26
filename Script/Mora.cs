using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mora : MonoBehaviour
{
    public float turnSpeed = 90f;
    //getting them coins
    private void OnTriggerEnter(Collider other)
    {

        //Prevents coins from being inside the obstacle
        if (other.gameObject.GetComponent<ObstaclePlayerboom>() != null)
        {
            Destroy(gameObject);
            return;
        }


        if (other.gameObject.name != "Player")
        {
            return;
        }
        //score
        GameManager.inst.IncrementScore();

        //remove coins
        Destroy(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0,0, turnSpeed * Time.deltaTime);
    }
}
