using UnityEngine;

namespace Assets.Scripts
{
    public class FuelBarrel : MonoBehaviour
    {
        [SerializeField] private int _fuel;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<Movement>(out var movement))
            {
                movement.GetComponentInChildren<IFuelable>().FuelInteraction(_fuel);
                Destroy(gameObject);
            }
        }
    }
}