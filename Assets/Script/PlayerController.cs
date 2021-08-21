using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //横の移動速度
    public float velocityX = 3f;
    //縦の移動速度
    public float velocityY = 3f;
    //移動範囲(横)
    private float moveableRange = 3f;
    //移動範囲(縦)
    private float moveableRange2 = 2.15f;

    private Rigidbody2D rb2D;

    //玉
    public GameObject BulletPrefab;
    public Transform ShotPoint;

    //音
    public AudioClip au3;

    public GameObject explosionPrefab; 
   


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

      
    }

    // Update is called once per frame
    void Update()
    {
        //横方向の速度を代入
        float InputVelocityX = 0;
        //縦方向の速度を代入
        float InputVelocityY = 0;

        if (Input.GetKey(KeyCode.LeftArrow) && -this.moveableRange < this.transform.position.x)
        {
            InputVelocityX = -this.velocityX;
        }
        if (Input.GetKey(KeyCode.RightArrow) && this.moveableRange > this.transform.position.x)
        {
            InputVelocityX = this.velocityX;
        }
        if (Input.GetKey(KeyCode.UpArrow) && this.moveableRange2 > this.transform.position.y)
        {
            InputVelocityY = this.velocityX;
        }
         if (Input.GetKey(KeyCode.DownArrow) && -this.moveableRange2 < this.transform.position.y)
        {
            InputVelocityY = -this.velocityX;
        }
        //玉を打つやつ
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bu = Instantiate(BulletPrefab);
            bu.transform.position = new Vector2(ShotPoint.transform.position.x, ShotPoint.transform.position.y);

            AudioSource.PlayClipAtPoint(au3, transform.position);
        }

         this.rb2D.velocity = new Vector2(InputVelocityX * Time.deltaTime * 5, InputVelocityY * Time.deltaTime * 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyTag" || collision.gameObject.tag == "BulletTag2")
        {
            GameObject en = Instantiate(explosionPrefab);
            en.transform.position = new Vector2(transform.position.x, transform.position.y);

            Destroy(this.gameObject);
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
        }

        
       

    }

}
