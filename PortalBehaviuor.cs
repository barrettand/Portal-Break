using UnityEngine;
using System.Collections;

public class PortalBehaviuor : MonoBehaviour {


    [SerializeField] GameObject portalObject;
    [SerializeField] GameObject paddle;
    // Use this for initialization
    void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(activatePortal());
        }
	
	}


    IEnumerator activatePortal()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            { 
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 newPosition = hit.point;
                    portalObject.transform.position = newPosition;
                    portalObject.SetActive(true);
                    paddle.GetComponent<PaddleMove>().portalActive=true;
                    break;
                }
            }
            yield return null;

        }
        yield return null;



    }
    
}
