using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int scoreValue;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.Instance.Score.AddScore(scoreValue);
            GameManager.Instance.Score.AddHit();
            gameObject.SetActive(false);
        }
    }
}