using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _currentScore = 0;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        AddScore(0);
    } 

    public void AddScore(int score)
    {
        _currentScore += score;
        _text.text = _currentScore.ToString();
    }
}