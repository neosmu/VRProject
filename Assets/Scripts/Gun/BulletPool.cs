using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get; private set; }
    [SerializeField] private PooledBullet bulletPrefab;
    [SerializeField] private int poolSize;

    private Queue<PooledBullet> pool = new Queue<PooledBullet>();

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            CreateBullet();
        }
    }

    private void CreateBullet()
    {
        PooledBullet bullet = Instantiate(bulletPrefab, transform);
        bullet.SetPool(this);
        bullet.gameObject.SetActive(false);
        pool.Enqueue(bullet);
    }

    public PooledBullet GetBullet()
    {
        if (pool.Count == 0)
        {
            return null;
        }

        var bullet = pool.Dequeue();
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(PooledBullet bullet)
    {
        bullet.gameObject.SetActive(false);
        pool.Enqueue(bullet);
    }
}
