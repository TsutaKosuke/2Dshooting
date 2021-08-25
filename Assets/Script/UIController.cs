using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private GameObject ScoreText;
    private GameObject Wave1;
    private float waveTime = 0f;
    private GameObject BossText;
    private GameObject GameClearText;
    private GameObject BossHp;
    private GameObject ContinueText;

    //ゲームオーバー
    private GameObject GameOverText;
    private bool isGameOver = false;
    

    //スコア
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.ScoreText = GameObject.Find("Score");
        this.Wave1 = GameObject.Find("Wave1");
        this.GameOverText = GameObject.Find("GameOverText");
        this.BossText = GameObject.Find("Boss");
        this.GameClearText = GameObject.Find("ClearText");
        this.BossHp = GameObject.Find("BossHp");
        this.ContinueText = GameObject.Find("ContinueText");

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
            BossHp.GetComponent<Text>().text = "Hp" + BossController.Hp;

            if (waveTime >= 32)
            {
                BossText.SetActive(false);
            }
          
        }

        if (isGameOver == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        
       
    }

    public void GameOver()
    {
        GameOverText.GetComponent<Text>().text = "GameOver";
        ContinueText.GetComponent<Text>().text = "クリックでコンティニュー";

        isGameOver = true;

    }
    public void GameClear()
    {
        GameClearText.GetComponent<Text>().text = "GameClear";
    }
  
}
