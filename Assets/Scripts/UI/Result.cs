using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : UIManager
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI hitCountText;

    private void Start()
    {
        int score = GameManager.Instance.Score.Score.Value;
        int hitCount = GameManager.Instance.Score.HitCount.Value;

        scoreText.text = $"{score}";
        hitCountText.text = $"{hitCount}/20";
    }

    //public void OnClickRetry()
    //{
    //    PlayClickSound();
    //    SceneManager.LoadScene("Shooting Scene");
    //}
    //public void OnClickTitle()
    //{
    //    PlayClickSound();
    //    SceneManager.LoadScene("Title Scene");
    //}
}
