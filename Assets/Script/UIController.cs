using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameObject ScoreText;
    private GameObject Wave1;
    private float waveTime = 0f;
    private GameObject BossText;
    private float BossTextlifetime = 2;
    private GameObject ClearText;

    //ゲームオーバー
    private GameObject GameOverText;
    

    //スコア
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.ScoreText = GameObject.Find("Score");
        this.Wave1 = GameObject.Find("Wave1");
        this.GameOverText = GameObject.Find("GameOverText");
        this.BossText = GameObject.Find("Boss");
        this.ClearText = GameObject.Find("ClearText");

        Wave1.GetComponent<Text>().text = "Wave1";

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.GetComponent<Text>().text = "Score" + score;

        waveTime += Time.deltaTime;

        if (waveTime >= 2)
        {
            Destroy(Wave1);
        }
        if (waveTime >= 30)
        {
            BossText.GetComponent<Text>().text = "BOSS";
            Destroy(this.gameObject, BossTextlifetime);
        }
        
       
    }

    public void GameOver()
    {
        GameOverText.GetComponent<Text>().text = "GameOver";

    }
    public void GameClear()
    {
        ClearText.GetComponent<Text>().text = "GameClear";
    }
}
