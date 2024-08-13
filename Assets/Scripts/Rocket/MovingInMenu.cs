using UnityEngine;

public class MovingInMenu : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _positionOffset;
    private float _lerpTime;
    private Vector3 _upperPosition;
    private Vector3 _lowerPosition;

    private void Start()
    {
        _upperPosition = new Vector3(transform.position.x, transform.position.y + _positionOffset, transform.position.z);
        _lowerPosition = new Vector3(transform.position.x, transform.position.y - _positionOffset, transform.position.z);
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, _rotationSpeed, 0);
        MoveUpAndDown();
    }

    private void MoveUpAndDown()
    {
        _lerpTime += Time.fixedDeltaTime * _movingSpeed;
        float lerpValue = Mathf.PingPong(_lerpTime, 1);
        transform.position = Vector3.Lerp(_upperPosition, _lowerPosition, lerpValue);
    }
}