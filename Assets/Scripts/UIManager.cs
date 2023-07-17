using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public TextMeshProUGUI scoreText;
    int score;
    public TextMeshProUGUI highscoreText;
    int highscore;
    public TextMeshProUGUI containText;
    public TextMeshProUGUI waveText;
    int wave;
    public Image[] lifeSprites;
    public Image healthBar;
    public Sprite[] heatlhBars;
    Color32 active = new Color(1, 1, 1, 1);
    Color32 inavtive = new Color(1, 1, 1, 0.25f);


    private void Awake()
    {
        if (instance==null)
            instance = this;
        else
            Destroy(gameObject);


    }

    public static void UpdateLives(int l)
    {

    }

    public static void UpdateScore (int l)
    {

    }

    public static void UpdateHighScore()
    {

    }

    public static void UpdateWave(int l)
    {

    }

    public static void UpdateHealthBar()
    {

    }

    public static void UpdateCoins()
    {

    }
}
