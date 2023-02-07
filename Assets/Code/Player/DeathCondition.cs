using UnityEngine;
using UnityEngine.Events;

public class DeathCondition : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private int _limit;
    [SerializeField] private UnityEvent _onDeath;
    private int _current;

    public void Compare()
    {
        _current++;
        if (_current < _limit) return;
        _onDeath.Invoke();
    }
}