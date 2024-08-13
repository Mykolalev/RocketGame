using UnityEngine;

namespace Assets.Scripts
{
    public class FuelBarrel : Item
    {
        [SerializeField] private int _fuel;

        protected override void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<IFuelable>(out var fuelComponent)) 
            {
                fuelComponent.FuelInteraction(_fuel);
                gameObject.SetActive(false);         
            }
        }
    }
}