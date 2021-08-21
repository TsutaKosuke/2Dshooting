using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed = 1;

    public static int Hp = 30;

    //玉
    public GameObject BulletPrefab2;
    public GameObject BossBulletPrefab;
    public Transform ShotPoint2;
    public float ShotTimeStartpoint = 2.5f;
    private float time = 0;

    //ボスを左右にランダムに動かすやつ
    public float m_moveSpeed = 5;
    public float m_maxX = 2;
    public float m_minX = -2;
    public float m_stoppingDistance = 0.1f;
    Vector2 m_targetPosition;
    

    // Start is called before the first frame update
    void Start()
    {

      
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > 2)
        {
            transform.position -= transform.up * speed * Time.deltaTime;

            if (this.transform.position.y <= 2)
            {
                m_targetPosition = GetRandomTargetPosition();
            }
        }

        if (this.transform.position.y < 2)
        {

            if (Vector2.Distance(this.transform.position, m_targetPosition) < m_stoppingDistance)
            {
                m_targetPosition = GetRandomTargetPosition();
            }
            else
            {
                Vector2 direction = (m_targetPosition - (Vector2)this.transform.position).normalized;
                this.transform.Translate(direction * m_moveSpeed * Time.deltaTime);
            }


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

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BulletTag")
        {
            Hp -= 1;
        }

        if (Hp == 0)
        {
            Destroy(this.gameObject);

            GameObject.Find("Canvas").GetComponent<UIController>().GameClear();
        }

    }



    Vector2 GetRandomTargetPosition()
    {
        Vector2 position = this.transform.position;
        position.x = Random.Range(m_minX, m_maxX);
      
        
        return position;
    }
}
