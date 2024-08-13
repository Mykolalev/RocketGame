using UnityEngine;

namespace Assets.Scripts
{
    public class RocketFuelView : MonoBehaviour
    {
        [SerializeField] private RocketFuelModel _model;
        [SerializeField] private RocketFuelBar _bar;

        private void Start()
        {
            UpdateView();
            _model.FuelChanged += UpdateView;
            Debug.Log("UpdateView subscription");
        }

        private void UpdateView() 
        {
            _bar.SetFuel(_model.CurrentFuel);
        }
    }
}