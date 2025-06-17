using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI hitCountText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bulletText;

    private int hitCount = 0;
    private int score = 0;

    public void SetTime(int seconds)
    {
        timeText.text = $"{seconds}s";
    }

    public void AddHit()
    {
        hitCount++;
        hitCountText.text = $"{hitCount}/20";
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        scoreText.text = $"{score}";
    }
    public void SetBullets(int current, int max)
    {
        bulletText.text = $"{current}/{max}";
    }
}
