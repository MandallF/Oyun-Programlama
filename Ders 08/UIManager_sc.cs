using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_sc : MonoBehaviour
{

    [SerializeField] TMP_Text scoreText;
    [SerializeField] Sprite[] liveSprites;
    [SerializeField] Image liveImg;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] TMP_Text restartText;
    [SerializeField] GameManager_sc gameManager_Sc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: 0";
        liveImg.sprite = liveSprites[3];
        gameOverText.gameObject.SetActive(false);
        gameManager_Sc = GameObject.Find("Game_Manager").GetComponent<GameManager_sc>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
    public void UpdateLives(int currentlives)
    {
        liveImg.sprite = liveSprites[currentlives];
        if(currentlives == 0)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        if(gameManager_Sc != null)
        {
            gameManager_Sc.GameOver();
        }
        else
        {
            Debug.LogError("UIManager_sc::GameOverSequence, gameManager_sc is NULL!");
        }
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }


    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
