using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header ("Score Elements")]
    public int score;
    public int highscore;
    public Text scoreText;
    public Text HighscoreText;

    [Header("Game Over")]
    public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;
    public Text gameOverPanelHighscoreText;

    [Header("Sounds")]
    public AudioClip[] sliceSounds;
    private AudioSource audioSource;



    private void Awake()
    {
        gameOverPanel.SetActive (false);
        audioSource = GetComponent<AudioSource>();
        GethighScore();
    }

    private void GethighScore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        HighscoreText.text = "Best: " + highscore;
    }

    public void IncreaseScore( int points)
    {
        score += points;
        scoreText.text=score.ToString();
        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscore = score;
            HighscoreText.text = score.ToString();
            
        }

    }

    public void OnBombHit()
    {
        Time.timeScale = 0; //stop the game time
        gameOverPanel.SetActive(true);
        gameOverPanelScoreText.text="Your Score: "+ score.ToString();
        gameOverPanelHighscoreText.text = "Highscore: " + highscore.ToString();

    }

    public void RestartGame()
    {
        score = 0;
        scoreText.text = score.ToString();
        gameOverPanel.SetActive(false);
        

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable")) // destroy all objects in background
        {
            Destroy(g);
        }
        Time.timeScale=1;     
    }

    public void PlayRandomSliceSound()
    {
        AudioClip randomSound= sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomSound); 
    }

}
