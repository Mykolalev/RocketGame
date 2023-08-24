using System;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDeadable
{
    [SerializeField] private GameObject _particleSystem;
    private bool _particlePlayed = false;

    public void Dead(Action action, Transform objTransform) 
    {
        if (_particlePlayed == true) { return; }

        _particlePlayed = true;
        action.Invoke();
        Instantiate(_particleSystem, objTransform.position, Quaternion.identity);
    }
}
