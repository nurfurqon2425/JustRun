using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{

    public PlayerScript player;
    public ScoreScript score;
    public AudioSource bakgroundSound;
    public AudioSource deathSound;

    private Vector3 playerStartPoint;
    private Vector3 platformGenerationStartPoint;

    public PlatformGeneratorScript platformGenerator;

    public GameObject largePlatform;
    public GameObject mediumPlatform;

    public GameObject gameOverScreen;



    // Start is called before the first frame update
    void Start()
    {
        playerStartPoint = player.transform.position;
        platformGenerationStartPoint = platformGenerator.transform.position;
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        player.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        score.isScoreIncreasing = false;
        bakgroundSound.Stop();
        deathSound.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        PlatformDestroyerScript[] destroyer = FindObjectsOfType<PlatformDestroyerScript>();
        for (int i = 0; i < destroyer.Length; i++)
        {
            destroyer[i].gameObject.SetActive(false);            
        }

        largePlatform.SetActive(true);
        mediumPlatform.SetActive(true);
        player.transform.position = playerStartPoint;
        platformGenerator.transform.position = platformGenerationStartPoint;
        gameOverScreen.SetActive(false);
        player.gameObject.SetActive(true);
        bakgroundSound.Play();
        score.score = 0;
        score.isScoreIncreasing = true;
    }
}
