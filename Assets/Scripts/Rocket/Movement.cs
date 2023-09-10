using Assets.Scripts;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _powerUp;
    [SerializeField] private float _turningSpeed;
    [SerializeField] private RocketFuel _rocketFuel;

    private float _turningDirection;
    private bool _canPush = false;
    private Rigidbody _rb;

    public bool CanPush
    {
        get => _canPush;
        set => _canPush = value;
    }
        

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void FixedUpdate()
    {
        RocketPushing();
        RocketRotation();
    }

    private void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            _canPush = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _canPush = false;
        }

    }

    private void ProcessRotation()
    {
        _turningDirection = Input.GetAxis("Horizontal");
    }

    private void RocketPushing()
    {
        if (_canPush == true)
        {
            _rb.AddRelativeForce(Vector3.up * _powerUp * Time.deltaTime);
        }
    }

    private void RocketRotation()
    {
        _rb.freezeRotation = true;
        transform.rotation *= Quaternion.Euler(0, 0, -_turningDirection * _turningSpeed * Time.deltaTime);
        _rb.freezeRotation = false;
    }
}
