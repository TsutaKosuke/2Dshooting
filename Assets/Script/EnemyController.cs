using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1;

    private float deathZone = -2.5f;

    private bool destroy = false;

    public AudioClip au;

    //玉
    public GameObject BulletPrefab2;
    public Transform ShotPoint2;
    public float ShotTimeStartpoint = 2.5f;
    private float time = 0;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.up * speed * Time.deltaTime;

        if (this.transform.position.y < deathZone)
        {
            Destroy(this.gameObject);
        }

        if (this.transform.position.y < ShotTimeStartpoint)
        {
           
            time += Time.deltaTime;

            if (time > 1.5)
            {
                GameObject enbu = Instantiate(BulletPrefab2);
                enbu.transform.position = new Vector2(ShotPoint2.transform.position.x, ShotPoint2.transform.position.y);
                time = -1;
            }
        }
      
       
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BulletTag")
        {
            
            AudioSource.PlayClipAtPoint(au, transform.position);

            if (destroy == false)
            {
                UIController.score += 2;

              
            }

            if (destroy) return;
            destroy = true;
            Destroy(this.gameObject);
            Debug.Log("Hit");




        }
    }


}
