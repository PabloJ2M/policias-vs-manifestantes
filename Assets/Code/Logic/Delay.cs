using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Delay : MonoBehaviour
{
    [SerializeField] private bool _loop, _playOnAwake = true;
    [SerializeField, Range(0, 10)] private float _time;
    [SerializeField] private UnityEvent _onComplete;

    private void Start() { if (_playOnAwake) StartDelay(); }
    public void StartDelay() => StartCoroutine(BeginDelay(_time, _time));
    protected virtual IEnumerator BeginDelay(float time, float constant)
    {
        yield return new WaitForSeconds(time);
        _onComplete.Invoke();

        if (!_loop) yield break;
        StartCoroutine(BeginDelay(constant, constant));
    }
}