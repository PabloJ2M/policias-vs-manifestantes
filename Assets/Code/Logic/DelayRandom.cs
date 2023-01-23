using System.Collections;
using UnityEngine;

public class DelayRandom : Delay
{
    [SerializeField, Range(0, 10)] private float _random;

    protected override IEnumerator BeginDelay(float time, float constant)
    {
        if (_random >= time) _random = time - 0.01f;
        time = Random.Range(time - _random, time + _random);
        return base.BeginDelay(time, constant);
    }
}