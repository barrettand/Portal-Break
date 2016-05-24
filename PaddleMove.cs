using UnityEngine;
using System.Collections;

public class PaddleMove : MonoBehaviour {


    Camera camera = new Camera();
	// Use this for initialization
	void Start () {

        camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        //Get touch position

        Vector3 positionX = Input.GetTouch(0).position;
        Vector3 positionNormal = transform.position;
        Vector3 p = camera.ScreenToWorldPoint(positionX);
        transform.position = new Vector3(p.x, positionNormal.y, 0);
        //need for android build

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -7) {
            transform.Translate(-0.3f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 7)
        {
            transform.Translate(0.3f, 0, 0);
        }
    }
}
