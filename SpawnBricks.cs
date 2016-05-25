using UnityEngine;
using System.Collections;

public class SpawnBricks : MonoBehaviour
{


    [SerializeField]
    GameObject BrickPrefab;
    [SerializeField]
    GameObject SpawnArea;
    [SerializeField]
    GameObject RocketPrefab;
    [SerializeField]
    GameObject KABOOMPrefab;
    [SerializeField]
    GameObject LongBrickPrefab;
    [SerializeField]
    GameObject bombCluster;

    ArrayList line1, line2, line3;
    bool canSpawn;
    Vector3 spawnPosition;
    float spawnAreaTopPosY, spawnAreaBotPosY;

    ArrayList variableBricks;
    bool longWaitBool;
    float longWait;
    //Have a spawn area with 3 lines that spawn bricks
    //3 Arrays

    // Use this for initialization
    void Start()
    {
        spawnAreaTopPosY = SpawnArea.transform.position.y + (SpawnArea.transform.localScale.y / 2) - BrickPrefab.transform.localScale.y / 2;
        spawnAreaBotPosY = SpawnArea.transform.position.y - (SpawnArea.transform.localScale.y / 2) + BrickPrefab.transform.localScale.y / 2;
        spawnPosition = SpawnArea.transform.position;
        spawnPosition.y += SpawnArea.gameObject.transform.localScale.y / 2 - BrickPrefab.transform.localScale.y / 2;
        canSpawn = true;

        //Add Different Bricks here
        variableBricks = new ArrayList();
        variableBricks.Add(BrickPrefab);
        variableBricks.Add(LongBrickPrefab);
        variableBricks.Add(bombCluster);
    }

    // Update is called once per frame
    void Update()
    {
        spawnBrickTimeManger();
    }

    void spawnBrickTimeManger()
    {
        if (canSpawn)
        {
            float randomTime;
            if (!longWaitBool)
            {
                randomTime = Random.Range(3f, 4f);
            }
            else
            {
                randomTime = 6f;
            }
            Invoke("spawnBrick", randomTime);
            canSpawn = false;
        }
    }

    void spawnBrick()//spawns each brick 
    {
        longWaitBool = false;
        setBrickPositions();
        canSpawn = true;
        spawnPosition = SpawnArea.transform.position;
        spawnPosition.y += SpawnArea.gameObject.transform.localScale.y / 2 - (BrickPrefab.transform.localScale.y / 2)*2;


        float yPosition = Random.Range(spawnAreaBotPosY, spawnAreaTopPosY);
        spawnPosition = new Vector3(spawnPosition.x, yPosition, spawnPosition.z);



    }

    void setBrickPositions()
    {
        float thing = Random.value;
        int brickSelection=Random.Range(0,variableBricks.Count);

        GameObject currentBrick = (GameObject)variableBricks[brickSelection];

        if(currentBrick.name==LongBrickPrefab.name)
        {
            longWaitBool = true;

        }

        if(currentBrick.name==bombCluster.name)
        {
            spawnPosition = SpawnArea.transform.position;
            spawnPosition.y += SpawnArea.gameObject.transform.localScale.y / 2 - (BrickPrefab.transform.localScale.y / 2)*5;
        }


        if (thing <= 0.33)
        {
            Instantiate((GameObject)variableBricks[brickSelection], spawnPosition, Quaternion.identity);
        }
        if (thing > 0.33 && thing < 0.66)
        {
            Instantiate((GameObject)variableBricks[brickSelection], spawnPosition, Quaternion.identity);
        }
        else {
            Instantiate(KABOOMPrefab, spawnPosition, Quaternion.identity);
        }
    }
}