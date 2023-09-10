using UnityEngine;

namespace Assets.Scripts
{
    public class RocketFuel : MonoBehaviour, IFuelable
    {
        [SerializeField] private int _maxFuel;
        [SerializeField] private RocketFuelBar _bar;
        private int _currentFuel;

        private void Start()
        {
            CurrentFuel = _maxFuel;
        }

        public int CurrentFuel
        {
            get => _currentFuel;
            set
            {
                if (value > _maxFuel)
                {
                    _currentFuel = _maxFuel;
                }

                _currentFuel = value;
                _bar.SetFuel(_currentFuel);
            }
        }

        public void FuelInteraction(int fuel)
        {
            if (CurrentFuel <= 0) { CurrentFuel = 0; }
            CurrentFuel += fuel;
        }
    }
}