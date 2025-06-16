using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : Singleton<GameManager>
{
    public ScoreManager Score { get; private set; }
    public CountUi countUi { get; private set; }
    [SerializeField] private CountUi countUiPrefab;
    private void Awake() => Init();

    private void Init()
    {
        base.SingletonInit();
        Score = GetComponentInChildren<ScoreManager>();
        countUi = countUiPrefab;
    }
}