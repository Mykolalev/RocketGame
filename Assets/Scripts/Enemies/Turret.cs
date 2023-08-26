using UnityEngine;

public class Turret : MonoBehaviour
{
    private ITurretStrategy _strategy;

    private void Update() => _strategy?.Update(Time.deltaTime);

    public void SetPattern(ITurretStrategy strategy)
    {
        if(strategy.GetType() == _strategy?.GetType()) return;
        _strategy?.StopMove();
        _strategy = strategy;
        _strategy.StartMove();
    }
}
