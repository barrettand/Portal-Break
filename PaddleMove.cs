using UnityEngine;
using System.Collections;

public class PaddleMove : MonoBehaviour {

    // Use this for initialization

    public bool portalActive;
	void Start () {

        portalActive = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -8.5) {
            transform.Translate(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 8.5)
        {
            transform.Translate(0.1f, 0, 0);
        }


    }

   
}
