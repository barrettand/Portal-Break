using UnityEngine;
using System.Collections;

public class ScrollingBricks : MonoBehaviour {

    Vector3 spawnPosition;
    float moveIncrement;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 10.0f);
        moveIncrement = .1f; //Controls speed of movement
        spawnPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        moveBrick();
	}

    void moveBrick()
    {
        float positionX = transform.position.x - moveIncrement;
        Vector3 newPosition = new Vector3(positionX, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
