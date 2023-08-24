using UnityEngine;

public class NozzleLight : MonoBehaviour
{
    [SerializeField] private GameObject _nozzleLight;
    private Movement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<Movement>();
    }

    private void Update()
    {
        TurnOnTheNozzleLight();
    }

    void TurnOnTheNozzleLight()
    {
        if (_playerMovement.CanPush)
        {
            _nozzleLight.SetActive(true);
        }
        else
        {
            _nozzleLight.SetActive(false);
        }
    }
}
