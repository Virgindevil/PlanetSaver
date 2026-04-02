using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _currentBestScore;
    private const string BestScoreKey = "BestScore";

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();

        _currentBestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        _text.text = _currentBestScore.ToString();
    }

    public void TrySetBestScore(int score)
    {
        if (score > _currentBestScore)
        {
            _currentBestScore = score;
            _text.text = _currentBestScore.ToString();

            PlayerPrefs.SetInt(BestScoreKey, _currentBestScore);
            PlayerPrefs.Save(); 
        }
    }
}
