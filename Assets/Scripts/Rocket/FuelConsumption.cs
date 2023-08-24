using UnityEngine;

public class FuelConsumption : MonoBehaviour
{
    [SerializeField] private RocketFuel _rocketFuel;
    [SerializeField] private int _consumption;

    private AudioSource _audioSource; 
    private Movement _movement;
    private bool _canConsumFuel = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _movement = GetComponent<Movement>();
    }

    void Update()
    {
        FuelConsumCheck();
    }

    private void FixedUpdate()
    {
        CunsumFuel();
    }

    private void FuelConsumCheck()
    {
        if (_movement.CanPush == true) { _canConsumFuel = true; }
        else if (_movement.CanPush == false) { _canConsumFuel = false; }
    }

    private void CunsumFuel()
    {
        if (_canConsumFuel == true)
        {
            _rocketFuel.FuelInteraction(_consumption);
            //Debug.Log(_rocketFuel.CurrentFuel);
            if (_rocketFuel.CurrentFuel <= 0)
            {
                _audioSource.Stop(); 
                _movement.CanPush = false;
                _movement.enabled = false; 
            }
            else
            {
                _movement.enabled = true;
            }
        }
    }


}
