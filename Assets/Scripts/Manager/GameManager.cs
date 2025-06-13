using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : Singleton<GameManager>
{
    public int Score { get; set; }
    private void Awake() => Init();

    private void Init()
    {
        base.SingletonInit();
    }
    public void AddScore(int score)
    {
        Score += score;
    }
}