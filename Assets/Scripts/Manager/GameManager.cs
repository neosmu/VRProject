using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : Singleton<GameManager>
{
    public AudioManager Audio { get; private set; }
    public ScoreManager Score { get; private set; }
    public CountUi countUi { get; private set; }
    [SerializeField] private CountUi countUiPrefab;
    private void Awake() => Init();

    private void Init()
    {
        base.SingletonInit();
        Audio = GetComponentInChildren<AudioManager>();
        Score = GetComponentInChildren<ScoreManager>();
        countUi = countUiPrefab;
    }
}