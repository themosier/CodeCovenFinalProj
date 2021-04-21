using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Put this on empty object marking enemy spawn points

    // this spawns enemies from a designated spawn point

    public Object enemyPrefab;

    // obsolete: use PlayerManager.player
    //public static GameObject player;

    public static int maxEnemies = 10;
    public static int curEnemies;
    public static List<Object> EnemyList;
    private float spawnTime = 2f;

    public List<GameObject> SpawnPoints;
    private int currSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player");

        curEnemies = 0;
        EnemyList = new List<Object>();

        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
        
    }


    public void SpawnEnemy()
    {
        if (EnemyList.Count < maxEnemies)
        {
            Vector3 pos = Vector3.zero;

            if (currSpawn < SpawnPoints.Count)
            {
                pos = SpawnPoints[currSpawn].transform.position;
                currSpawn++;
                if (currSpawn >= SpawnPoints.Count)
                {
                    currSpawn = 0;
                }
            }

            EnemyList.Add(Instantiate(enemyPrefab, pos, Quaternion.identity));
            curEnemies++;
        }

    }
}
