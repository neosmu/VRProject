using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    [SerializeField] private CountUi countUi;
    private int currentIndex = 0;
    private int spawnCount = 0;
    private int maxCount = 20;

    void Start()
    {
       
        StartCoroutine(TargetRoutine());
    }
    IEnumerator TargetRoutine()
    {
        while (spawnCount < maxCount)
        {
            for (int i = 3; i > 0; i--)
            {
                countUi.SetTime(i);
                yield return new WaitForSeconds(1f);
            }

            ShowTarget(currentIndex);

            
            for (int i = 10; i > 0; i--)
            {
                countUi.SetTime(i);
                yield return new WaitForSeconds(1f);
            }

            HideTargets();

            currentIndex++;
            if (currentIndex >= targets.Length)
                currentIndex = 0;

            spawnCount++;
        }

        countUi.SetTime(0);
}

void ShowTarget(int index)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(i == index);
        }
    }

    void HideTargets()
    {
        foreach (GameObject t in targets)
            t.SetActive(false);
    }
}
