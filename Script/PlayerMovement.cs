using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //RESTART THE GAME 
    bool alive = true;

    //BASIC MOVEMENT
    float horizontalInput;
    public float speed = 5;
    public Rigidbody rb;
    public float horizontalMultiplier = 2;

    //JUMP ANIMATION and pace
    public float speedIncreases = 0.1f;

    public float jumpF = 400f;
    public LayerMask groundMask;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        //restart game
        if (!alive) return;

        //basic movement
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame


    private void Update()
    {
        //basic movement for keys
        horizontalInput = Input.GetAxis("Horizontal");

        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        //restart game aka kill player if collided
        if (transform.position.y < -5)
        {
            Boom();
        }

    }

    public void Boom()
    {
        alive = false;

        //Goes back
        Invoke("Restart", 2);
       
    }

    void Restart()
    {
        //goes back to the original spot
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        rb.AddForce(Vector3.up * jumpF);
    }
}