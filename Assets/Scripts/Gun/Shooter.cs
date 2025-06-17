using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private int bulletCount;
    [SerializeField] private int maxbulletCount;
    [SerializeField] private AudioClip fireSound;

    public void Fire()
    {
        if (bulletCount<= 0) return;
        var bullet = BulletPool.Instance.GetBullet();
        if (bullet == null) return;

        bullet.transform.SetParent(null);

        var rigidbody = bullet.GetComponent<Rigidbody>();
        bullet.transform.position = muzzlePoint.position;
        bullet.transform.rotation = muzzlePoint.rotation;

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.AddForce(muzzlePoint.forward * bulletSpeed, ForceMode.Impulse);

        bulletCount--;
        if (GameManager.Instance.countUi != null)
        {
            GameManager.Instance.countUi.SetBullets(bulletCount, maxbulletCount);
        }
        AudioManager audio = FindObjectOfType<AudioManager>();
        if (audio != null && fireSound != null)
        {
            audio.PlaySFX(fireSound);
        }
        if (bulletCount <= 0)
        {
            StartCoroutine(LoadResultAfterDelay());
        }

        IEnumerator LoadResultAfterDelay()
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Result Scene");
        }
    }
}