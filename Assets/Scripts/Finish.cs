using System;
using UnityEngine;

public class Finish : MonoBehaviour, IWinable
{
    [SerializeField] private ParticleSystem _particleSystem;
    private bool _particlePlayed = false;

    public void Win(Action action, Transform objTransform)
    {
        if (_particlePlayed == true) { return; }

        _particlePlayed = true; 
        action.Invoke();
        ParticleSystem particleSystem = Instantiate(_particleSystem, transform.position, Quaternion.identity);
    }
}