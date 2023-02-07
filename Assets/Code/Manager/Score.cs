using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private Dificulty _manager;
    [SerializeField, Range(0, 100)] private int _amount;
    [SerializeField] private TextMeshProUGUI _text;
    private int _highScore;

    private float _current;
    public static float Target { get; private set; }

    private void Awake()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        _manager.OnShieldUsed += AddScore;
        Target = 0;
    }
    private System.Collections.IEnumerator Start()
    {
        yield return new WaitUntil(() => _current < Target);
        yield return null;

        _current = Mathf.Lerp(_current, Target, Time.deltaTime * 10);
        _text.SetText(Mathf.RoundToInt(_current).ToString());
        StartCoroutine(Start());
    }
    private void AddScore()
    {
        Target += _amount;
        if (Target <= _highScore) return;

        _highScore = (int)Target;
        PlayerPrefs.SetInt("HighScore", _highScore);
    }
}