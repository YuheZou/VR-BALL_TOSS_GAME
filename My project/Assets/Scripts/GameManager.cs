using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    private int score;
    private bool isOver;

    public TextMeshProUGUI scoreText;
    public Slider healthBar;
    public TextMeshProUGUI gameOverText;
    public Button button;

    

    // Start is called before the first frame update
    void Start()
    {
        isOver = false;
        healthBar.value = 0;
        score = 0;
        button.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            isOver = true;
            button.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
        }
    }

    public bool gameOver()
    {
        return isOver;
    }

    public void getHurt()
    {
        HP -= 20;
        healthBar.value += 0.2f;
    }

    public void heal()
    {
        HP += 20;
        healthBar.value -= 0.2f;
    }

    public void updateScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = "Score: " + score;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
