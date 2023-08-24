using UnityEngine;

public class BlasterAttack : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Radar _radar;

    private void Update()
    {
        OnPlayerDetected();
    }

    private void OnPlayerDetected()
    {
        if(_radar.TargetDetected == true)
            transform.LookAt(_player);
    }
}
