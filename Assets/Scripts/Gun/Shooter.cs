using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private BulletPool bulletPool;

    public void Fire()
    {
        var bullet = BulletPool.Instance.GetBullet();
        if (bullet == null) return;

        bullet.transform.SetParent(null);

        var rigidbody = bullet.GetComponent<Rigidbody>();
        bullet.transform.position = muzzlePoint.position;
        bullet.transform.rotation = muzzlePoint.rotation;

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.AddForce(muzzlePoint.forward * bulletSpeed, ForceMode.Impulse);
    }
}