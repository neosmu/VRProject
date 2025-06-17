using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int scoreValue;
    [SerializeField] private AudioClip hitSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            AudioManager audio = FindObjectOfType<AudioManager>();
            if (audio != null && hitSound != null)
            {
                audio.PlaySFX(hitSound);
            }
            GameManager.Instance.Score.AddScore(scoreValue);
            GameManager.Instance.Score.AddHit();
            gameObject.SetActive(false);
        }
    }
}