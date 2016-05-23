using UnityEngine;
using System.Collections;

public class SpawnBricks : MonoBehaviour {


    [SerializeField] GameObject BrickPrefab;
    [SerializeField] GameObject SpawnArea;

    ArrayList line1,line2,line3;
    float spawnAreaHeight;
    bool canSpawn;
    float numBricksHeight=3;
    Vector3 spawnPosition;
    Vector3 lastBrickPosition;
    float spawnAreaTopPosY,spawnAreaBotPosY;
   
    //Have a spawn area with 3 lines that spawn bricks
    //3 Arrays

    // Use this for initialization
    void Start ()
    {
        spawnAreaTopPosY = SpawnArea.transform.position.y + (SpawnArea.transform.localScale.y / 2)-BrickPrefab.transform.localScale.y/2;
        spawnAreaBotPosY = SpawnArea.transform.position.y - (SpawnArea.transform.localScale.y / 2)+BrickPrefab.transform.localScale.y/2;
        spawnPosition = SpawnArea.transform.position;
        spawnPosition.y += SpawnArea.gameObject.transform.localScale.y/2 - BrickPrefab.transform.localScale.y / 2; 
        spawnAreaHeight = SpawnArea.gameObject.transform.localScale.y / numBricksHeight;
        lastBrickPosition = spawnPosition;
        canSpawn = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
        spawnBrickTimeManger();
	}

    void spawnBrickTimeManger()
    {
        if (canSpawn)
        {
            float randomTime = Random.Range(.2f, .3f);
            Invoke("spawnBrick",randomTime);
            canSpawn = false;
        }
    }

    void spawnBrick()//spawns each brick 
    {
        setBrickPositions();

        canSpawn = true;
        spawnPosition = SpawnArea.transform.position;
        spawnPosition.y += SpawnArea.gameObject.transform.localScale.y/2 - BrickPrefab.transform.localScale.y / 2;
        spawnAreaHeight = SpawnArea.gameObject.transform.localScale.y / numBricksHeight;

      
            float yPosition = Random.Range(spawnAreaBotPosY, spawnAreaTopPosY);          
           spawnPosition = new Vector3(spawnPosition.x, yPosition, spawnPosition.z);
               
       
        
    }

    void setBrickPositions()
    {
        float interval = spawnAreaHeight / numBricksHeight;
        Instantiate(BrickPrefab, spawnPosition, Quaternion.identity);
    }
}
