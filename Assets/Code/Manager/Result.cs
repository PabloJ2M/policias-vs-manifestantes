using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI _text;

    private void Start()
    {
        _text?.SetText($"HighScore<br>{ PlayerPrefs.GetInt("HighScore", 0) }<br><br>Score<br>{ Score.Target }");
    }
}