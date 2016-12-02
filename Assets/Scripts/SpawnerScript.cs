using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    public Transform player;
    public Transform generationPoint;
    public Transform deletePoint;

    public PlayerScript playerScript;

    private float waterWidth;

    public GameObject flyingEnemy;
    public GameObject coin;
    public GameObject coinRow;
    public GameObject coinColumn;
    public GameObject coinOther;

    public GameObject water;

    public float spawnEnemyTime = 20; // * 0.5 seconds
    public float spawnCoinRowTime = 20;
    public float spawnCoinTime = 8;

    private float waterY = -8.4f;

    private bool invokingEnemy = false;
    private int count = 0;
    private int waterCount = 0;

	// Use this for initialization
	void Start () {

        InvokeRepeating("spawn", 0.2f, 0.5f);


    }
	
	// Update is called once per frame
	void Update () {
        
        if(transform.position.x > 80*waterCount)
        {
            waterCount++;
            spawnWater();
        }
            



    }

    void spawn()
    {
        count++;
        

        if (count % spawnEnemyTime == 0)
            spawnFlyingEnemy();

        if (count % spawnCoinTime == 0)
            spawnCoin();

        if (count % spawnCoinRowTime == 0)
            spawnCoinRow();

        if (count % 50 == 0 && spawnEnemyTime > 1)
            spawnEnemyTime = spawnEnemyTime / 2;

        if (count % 40 == 0 && spawnCoinRowTime > 0)
            spawnCoinRowTime = spawnCoinRowTime / 2;

        if (count % 40 == 0 && spawnCoinTime > 0)
            spawnCoinTime = spawnCoinTime / 2;
    }

    void spawnCoin()
    {
        float y = Random.Range(Mathf.Max(1, generationPoint.position.y - 20), generationPoint.position.y + 15);
        Instantiate(coin, new Vector3(generationPoint.transform.position.x, y, 0), Quaternion.identity);
        

    }

    void spawnCoinRow()
    {
        float y2 = Random.Range(Mathf.Max(5, generationPoint.position.y - 20), generationPoint.position.y + 15);
        Instantiate(coinRow, new Vector3(generationPoint.transform.position.x, y2, 0), Quaternion.identity);
    }

    void spawnFlyingEnemy()
    {
        float y3 = Random.Range(Mathf.Max(1, generationPoint.position.y - 20), generationPoint.position.y + 20);
        Instantiate(flyingEnemy, new Vector3(generationPoint.transform.position.x, y3, 0), Quaternion.identity);
        
    }

    void spawnWater()
    {
        Instantiate(water, new Vector3(generationPoint.transform.position.x, waterY, 0), Quaternion.identity);
    }

}
