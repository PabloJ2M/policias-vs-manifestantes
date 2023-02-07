using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject _fadePrefab;
    private bool _lock = false;

    public void FadeScene(string name)
    {
        if (_lock || !_fadePrefab) return;

        _lock = true;
        Instantiate(_fadePrefab, transform).GetComponent<Fade>().sceneName = name;
    }
}