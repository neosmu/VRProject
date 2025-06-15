using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private GameObject target1;
    [SerializeField] private GameObject target2;
    [SerializeField] private GameObject target3;

    private GameObject[] targets;
    private int currentIndex = 0;
    private int spawnCount = 0;
    private int maxCount = 20;

    void Start()
    {
        targets = new GameObject[] {target1, target2, target3};
        StartCoroutine(TargetRoutine());
    }
    IEnumerator TargetRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            ShowTarget(currentIndex);

            yield return new WaitForSeconds(10f);

            HideTargets();

            currentIndex++;
            if (currentIndex >= targets.Length)
                currentIndex = 0;

            spawnCount++;
        }
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
