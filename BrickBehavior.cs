using UnityEngine;
using System.Collections;

public class BrickBehavior : MonoBehaviour {
    public TextMesh scoretext;
    public int score = 0;
    float shakeAmt = 0;
    public Camera mainCamera;
    Vector3 originalCameraPosition;

    // Use this for initialization
    void Start () {
        originalCameraPosition = mainCamera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        scoretext.text = "Score: " + score;
	}

    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.tag == "Brick")
        {
            shakeAmt = col.relativeVelocity.magnitude * .0025f;
            InvokeRepeating("CameraShake", 0, .01f);
            Invoke("StopShaking", 0.3f);
            score += 100;
            Destroy(col.gameObject,1f);
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    
    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.x += quakeAmt;
            pp.y += quakeAmt; // can also add to x and/or z
            mainCamera.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }
}
