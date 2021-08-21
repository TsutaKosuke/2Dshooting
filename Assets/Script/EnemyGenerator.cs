using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;

    private int startPos = 2;

    private int goalPos = 30;

    private int MaxEnemyNum = 2;

    //ボス
    public GameObject BossPrefab;



    // Start is called before the first frame update
    void Start()
    {
        for (int i = startPos; i < goalPos; i++)
        {
            int m = Random.Range(1, MaxEnemyNum);

            for (int j = 0; j < m; j++)
            {
                float n = Random.Range(-3, 3);
                GameObject en = Instantiate(EnemyPrefab);
                en.transform.position = new Vector2(n, i);
            }
            
        }
        //ボス
        GameObject boss = Instantiate(BossPrefab);
        boss.transform.position = new Vector2(0, 35);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
