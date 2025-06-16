using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledBullet : MonoBehaviour
{
    private Rigidbody rigid;
    private BulletPool pool;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(AutoReturn());
    }

    public void SetPool(BulletPool bulletPool)
    {
        pool = bulletPool;
    }

    public void Shoot(Vector3 direction, float force)
    {
        rigid.velocity = Vector3.zero;
        rigid.AddForce(direction * force, ForceMode.Impulse);
    }

    private IEnumerator AutoReturn()
    {
        yield return new WaitForSeconds(5f);
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
        pool.ReturnBullet(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            ReturnToPool();
        }
    }
}
