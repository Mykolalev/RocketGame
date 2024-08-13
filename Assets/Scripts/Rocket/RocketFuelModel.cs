using Assets.Scripts;
using System;
using UnityEngine;

public class RocketFuelModel : MonoBehaviour, IFuelable
{
    [SerializeField] private int _maxFuel;
    private int _currentFuel;

    public event Action FuelChanged;

    public int CurrentFuel
    {
        get => _currentFuel;
        set
        {
            if (value > _maxFuel)
            {
                _currentFuel = _maxFuel;
            }
            else
            {
                _currentFuel = value;
            }
        }
    }

    private void Awake()
    {
        _currentFuel = _maxFuel; 
    }

    public void FuelInteraction(int fuel)
    {
        if (_currentFuel <= 0)
        {
            _currentFuel = 0;
        }
        CurrentFuel += fuel;
        FuelChanged?.Invoke();
    }
}