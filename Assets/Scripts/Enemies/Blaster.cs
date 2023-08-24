using System.Collections;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField] private int _delay;
    [SerializeField] private Radar _radar;
    [SerializeField] private float _rotatingSpeed;

    void Start()
    {
        StartCoroutine(nameof(BlasterIdle));
    }

    public IEnumerator BlasterIdle()
    {
        while (_radar.TargetDetected == false)
        {
            Vector3 newEulerAngles = new Vector3(Random.Range(0, -30), Random.Range(0, 360), 0);
            Quaternion newRotation = Quaternion.Euler(newEulerAngles);

            float elapsedTime = 0;
            float rotationDuration = 1f;

            Quaternion startRotation = transform.rotation;

            while (elapsedTime < rotationDuration)
            {
                elapsedTime += Time.deltaTime;
                transform.rotation = Quaternion.Lerp(startRotation, newRotation, elapsedTime);              
                yield return null;
            }

            transform.rotation = newRotation;

            yield return new WaitForSeconds(1f);
        }
    }
}
