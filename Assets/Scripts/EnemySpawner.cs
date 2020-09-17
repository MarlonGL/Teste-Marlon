using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameInfo game;
    public Transform player;
    public GameObject enemyPrefab;
    public Transform[] spots;
    int spot;
    int lastSpot = -1;
    float spawnTime;
    float time = 0f;
    bool waiting = false;
    int type;
    void Start()
    {
        spawnTime = Global.EnemySpawnTime;
    }

    void Update()
    {
        if (!waiting)
        {
            type = Random.Range(0, 11);
            if(lastSpot >= 0)
            {
                while(spot == lastSpot)
                {
                    spot = Random.Range(0, spots.Length);
                }
            }
            GameObject enemy = Instantiate(enemyPrefab, spots[spot].position, Quaternion.identity);
            enemy.GetComponent<Enemy>().setPlayerT(player);
            enemy.GetComponent<Enemy>().setGame(game);
            if (type <= 7)
            {
                enemy.GetComponent<Enemy>().setType(0);
            }
            else
            {
                enemy.GetComponent<Enemy>().setType(1);
            }
            waiting = true;
            lastSpot = spot;
        }
        else
        {
            time += Time.deltaTime;
            if(time >= spawnTime)
            {
                waiting = false;
                time = 0f;
            }
        }
    }
}
