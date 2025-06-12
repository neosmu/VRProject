using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;

    public void Fire()
    {
        GameObject Bullet = Instantiate(bullet, muzzlePoint.position, Quaternion.identity);
        Bullet.GetComponent<Rigidbody>().AddForce(muzzlePoint.forward * bulletSpeed, ForceMode.Impulse);
    }
}
