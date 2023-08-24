using System;
using UnityEngine;

public interface IDeadable
{
    void Dead(Action action, Transform transform);
}
