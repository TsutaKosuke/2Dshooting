using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBobu : MonoBehaviour
{
    public float speed = 5;

    private float BossBulletDeathZone = -2.7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= (transform.up + transform.right) * speed * Time.deltaTime;


        if (this.transform.position.y < BossBulletDeathZone)
        {
            Destroy(this.gameObject);
        }
    }
}
