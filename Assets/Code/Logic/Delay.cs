using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Delay : MonoBehaviour
{
    [SerializeField] private bool _loop;
    [SerializeField, Range(0, 10)] private float _time;
    [SerializeField] private UnityEvent _onComplete;

    public void Start() => StartCoroutine(BeginDelay(_time, _time));
    protected virtual IEnumerator BeginDelay(float time, float constant)
    {
        yield return new WaitForSeconds(time);
        _onComplete.Invoke();

        if (!_loop) yield break;
        StartCoroutine(BeginDelay(constant, constant));
    }
}