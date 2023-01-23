using UnityEngine;
using UnityEngine.Events;

public class OnTrigger : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private UnityEvent _onTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(_tag)) return;
        _onTriggered.Invoke();
    }
}