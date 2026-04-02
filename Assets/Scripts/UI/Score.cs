using TMPro;
using UnityEngine;
using Zenject;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private BestScore _bestScore;
    private int _currentScore = 0;

    [Inject]
    public void Construct(BestScore bestScore)
    {
        _bestScore = bestScore;
    }

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        ChangeScore(0);
    } 

    public void ChangeScore(int score)
    {
        _currentScore += score;
        _text.text = _currentScore.ToString();
        _bestScore.TrySetBestScore(_currentScore);
    }


}