using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;

    private int startPos = 2;

    private int goalPos = 20;

    private int MaxEnemyNum = 10;

  

    // Start is called before the first frame update
    void Start()
    {
        for (int i = startPos; i < goalPos; i++)
        {
            float n = Random.Range(-3, 3);
            int m = Random.Range(5, MaxEnemyNum);

            for (int j = 0; j < m; j++)
            {
                GameObject en = Instantiate(EnemyPrefab);
                en.transform.position = new Vector2(n, i);
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
