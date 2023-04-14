using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnPoint_1;
    public GameObject spawnPoint_2;
    public GameObject spawnPoint_3;
    public GameObject spawnPoint_4;

    bool enemy_1;
    bool enemy_2;
    bool enemy_3;
    bool enemy_4;

    int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 6; i++)
        {
            int j;
            for (j = 0; j < 3; j++)
            {
                var obj = ObjectPooling.Instance.GetPooledObject(i);
                obj.transform.position = new Vector3(Random.RandomRange(spawnPoint_1.transform.position.x, spawnPoint_2.transform.position.x), 0,
                    Random.Range(spawnPoint_2.transform.position.z, spawnPoint_3.transform.position.z));
            }
            j = 0;
        }
        StartCoroutine(SpawnEnemy());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        
       
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int spawnTime = Random.RandomRange(5, 15);
            if (GameManager.Instance.canPlayGame)
            {
                int spawn = Random.RandomRange(0, 4);
                int spawnPosition = Random.RandomRange(0, 4);
                Vector3 position = Vector3.zero;
                if (spawnPosition == 0)
                {
                    position = spawnPoint_1.gameObject.transform.position;
                }
                if (spawnPosition == 1)
                {
                    position = spawnPoint_2.gameObject.transform.position;
                }
                if (spawnPosition == 2)
                {
                    position = spawnPoint_3.gameObject.transform.position;
                }
                if (spawnPosition == 3)
                {
                    position = spawnPoint_4.gameObject.transform.position;
                }

                foreach (var obj in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    if (obj.active)
                    {
                        enemyCount++;
                    }
                }

                if (372 - enemyCount >= 16 && enemyCount != 0)
                {
                    enemy_1 = true;
                }
                if (372 - enemyCount < 16)
                {
                    enemy_1 = false;
                }
                if (372 - enemyCount >= 7 && enemyCount != 0)
                {
                    enemy_2 = true;
                }
                if (372 - enemyCount < 7)
                {
                    enemy_2 = false;
                }
                if (372 - enemyCount >= 58 && enemyCount != 0)
                {
                    enemy_3 = true;
                }
                if (372 - enemyCount < 58)
                {
                    enemy_3 = false;
                }
                if (372 - enemyCount >= 43 && enemyCount != 0)
                {
                    enemy_4 = true;
                }
                if (372 - enemyCount < 43)
                {
                    enemy_4 = false;
                }
                if (enemyCount == 0)
                {
                    enemy_1 = true;
                    enemy_2 = true;
                    enemy_3 = true;
                    enemy_4 = true;
                }


                if (spawn == 0 && enemy_1)
                {
                    var obj = ObjectPooling.Instance.GetPooledObject(6);
                    obj.transform.position = position;
                }
                if (spawn == 1 && enemy_2)
                {
                    var obj = ObjectPooling.Instance.GetPooledObject(7);
                    obj.transform.position = position;
                }
                if (spawn == 2 && enemy_3)
                {
                    var obj = ObjectPooling.Instance.GetPooledObject(8);
                    obj.transform.position = position;
                }
                if (spawn == 3 && enemy_4)
                {
                    var obj = ObjectPooling.Instance.GetPooledObject(9);
                    obj.transform.position = position;
                }
            }
            else
            {
                spawnTime = 0;
            }
            

            
            enemyCount = 0;

            
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
