using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _currentScore = 0;

    private void Awake() => _text = GetComponent<TextMeshProUGUI>();

    public void AddScore(int score)
    {
        _currentScore += score;
        _text.text = _currentScore.ToString();
    }
}