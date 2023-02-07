using UnityEngine;
using UnityEngine.Events;

public class Event : MonoBehaviour
{
    [SerializeField] private UnityEvent _callback;

    public void CallFunction() => _callback.Invoke();
}