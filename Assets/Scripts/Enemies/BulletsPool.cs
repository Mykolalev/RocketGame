using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    private List<Bullet> _bulletsPool = new List<Bullet>();

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
        bullet.Destroyed += ReturnBullet;
        return bullet;            
    }

    private void ReturnBullet(Bullet bullet)
    {
        bullet.Destroyed -= ReturnBullet;
        _bulletsPool.Add(bullet);
    }
}
