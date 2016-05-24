using UnityEngine;
using System.Collections;

public class ExplodingBricks : MonoBehaviour
{
    float moveIncrement;
    float explosionRad;
    float power;
    // Use this for initialization
    void Start()
    {
        explosionRad = 6;
        power = .2f;
        Destroy(gameObject, 3.0f);
        moveIncrement = .1f; //Controls speed of movement
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

        float randomX = Random.Range(5, 10);
        float randomY = Random.Range(-5, -10);
        if (col.gameObject.tag == "Ball")
        {
            gameObject.AddComponent<Rigidbody2D>();
            GetComponent<Rigidbody2D>().AddForce(new Vector3(randomX, randomY, 0));
            //explode();
           
        }
    }

    void explode()
    {
        
        Vector2 start=transform.position;
        float radius = 4f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(start, radius);

        float randomX = Random.Range(5, 10);
        float randomY = Random.Range(-5, -10);
        foreach (Collider2D col in colliders)
        {
            gameObject.AddComponent<Rigidbody2D>();
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(20, 20));
        }

        

        
           

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Brick")
        {
            col.gameObject.AddComponent<Rigidbody2D>();
            col.GetComponent<Rigidbody2D>().AddForce(new Vector2(20, 20));
        }
    }

  
     
    
    
}