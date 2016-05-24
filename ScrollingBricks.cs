using UnityEngine;
using System.Collections;

public class ScrollingBricks : MonoBehaviour
{

    Vector3 spawnPosition;
    float moveIncrement;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 3.0f);
        moveIncrement = .1f; //Controls speed of movement
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveBrick();
    }

    void moveBrick()
    {
        float positionX = transform.position.x - moveIncrement;
        Vector3 newPosition = new Vector3(positionX, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        float randomX = Random.Range(5,10);
        float randomY = Random.Range(-5, -10);
        if (col.gameObject.tag == "Ball")
        {
            gameObject.AddComponent<Rigidbody2D>();
            GetComponent<Rigidbody2D>().AddForce(new Vector3(randomX, randomY, 0));
        }
    }
}