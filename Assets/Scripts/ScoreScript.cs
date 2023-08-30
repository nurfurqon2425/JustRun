using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public float pointsPerSecond;

    public Text scoreText;
    public Text hiScoreText;

    public float score;
    public float hiScore;

    public bool isScoreIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HiScore"))
        {
            hiScore = PlayerPrefs.GetFloat("HiScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isScoreIncreasing)
        {
            score += pointsPerSecond * Time.deltaTime;
        }        

        if(score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetFloat("HiScore", hiScore);
        }

        scoreText.text = Mathf.Round(score).ToString();
        hiScoreText.text = Mathf.Round(hiScore).ToString();
    }
}
