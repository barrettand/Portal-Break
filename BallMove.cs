using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour
{
    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    float maxSpeed = 9f;
    float minSpeed = 6f;
    Vector2 currVelocity;

    // GameObject
    public GameObject playerObject;

    // Use this for initialization
    void Start()
    {
        // create the force
        ballInitialForce = new Vector2(300.0f, 300.0f);

        // set to inactive
        ballIsActive = false;

        // ball position
        ballPosition = transform.position;


        currVelocity = GetComponent<Rigidbody2D>().velocity;
    }

    // Update is called once per frame
    void Update()
    {
        // check for user input
        if (Input.GetButtonDown("Jump") == true)
        {
            // check if is the first play
            if (!ballIsActive)
            {
                // reset the force
                GetComponent<Rigidbody2D>().isKinematic = false;

                // add a force
                GetComponent<Rigidbody2D>().AddForce(ballInitialForce);

                // set ball active
                ballIsActive = !ballIsActive;
            }
        }

        if (!ballIsActive && playerObject != null)
        {

            // get and use the player position
            ballPosition.x = playerObject.transform.position.x;

            // apply player X position to the ball
            transform.position = ballPosition;
        }

        // Check if ball falls
        if (ballIsActive && transform.position.y < -6)
        {
            ballIsActive = !ballIsActive;
            ballPosition.x = playerObject.transform.position.x;
            ballPosition.y = -3.06f;
            transform.position = ballPosition;

            GetComponent<Rigidbody2D>().isKinematic = true;
        }

        monitorBallSpeed();

    }

    void monitorBallSpeed()
    {
        currVelocity = GetComponent<Rigidbody2D>().velocity;
        if (currVelocity.x<minSpeed)//Makes sure ball never travels too slowly
        {
            if (currVelocity.x > 0)//PositiveNumber
            {
                currVelocity.x = minSpeed;
            }
            else if(currVelocity.x<0)//Negative Number
            {
                currVelocity.x = minSpeed * -1;
            }
        }
        if(currVelocity.y<minSpeed)
        {
            if (currVelocity.y > 0)//Pos Number
            {
                currVelocity.y = minSpeed;
            }
            else if(currVelocity.y<0)//Neg Number
            {
                currVelocity.y = minSpeed * -1;
            }
        }



        GetComponent<Rigidbody2D>().velocity = currVelocity;


    }
}