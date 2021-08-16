using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed = 5;

    private float EnemyBulletDeathZone = -2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.up * speed * Time.deltaTime;

        if (this.transform.position.y < EnemyBulletDeathZone)
        {
            Destroy(this.gameObject);
        }
    }
}
