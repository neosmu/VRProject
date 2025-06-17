using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private CountUi countUi;
    public ObservableProperty<int> Score = new();
    public ObservableProperty<int> HitCount = new();

    public void AddScore(int value)
    {
        Score.Value += value;
        if (countUi != null)
            countUi.SetScore(Score.Value);
    }

    public void AddHit()
    {
        HitCount.Value++;
        if (countUi != null)
            countUi.AddHit();
    }
    public void ResetScore()
    {
        Score.Value = 0;
        HitCount.Value = 0;
    }
}
