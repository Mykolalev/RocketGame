using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    private readonly List<Bullet> _bulletsPool = new List<Bullet>();

    public Bullet GetBullet()
    {
        Bullet bullet;
        if (_bulletsPool.Count > 0)
        {
            bullet = _bulletsPool[0];
            _bulletsPool.Remove(bullet);
        }
        else
        {
            bullet = Instantiate(_bulletPrefab);
        }
        bullet.Destroyed += ReturnBulletToPool;
        bullet.Activate();
        return bullet;            
    }

    private void ReturnBulletToPool(Bullet bullet)
    {
        bullet.Destroyed -= ReturnBulletToPool;
        _bulletsPool.Add(bullet);
    }
}
