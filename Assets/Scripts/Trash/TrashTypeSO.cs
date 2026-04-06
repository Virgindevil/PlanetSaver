using UnityEngine;

[CreateAssetMenu(fileName = "TrashType", menuName = "Game/Trash Type")]
public class TrashTypeSO : ScriptableObject
{
    [SerializeField] private int _scoreValue;
    [SerializeField] private float _polutionValue;

    public int ScoreValue => _scoreValue; 
    public float PollutionValue => _polutionValue; 
}