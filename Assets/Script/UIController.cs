using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameObject ScoreText;
    private GameObject Wave1;
    private float waveTime = 0f;
   

    //スコア
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.ScoreText = GameObject.Find("Score");
        this.Wave1 = GameObject.Find("Wave1");

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
    }
}
