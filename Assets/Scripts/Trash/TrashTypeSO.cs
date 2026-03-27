using UnityEngine;

[CreateAssetMenu(fileName = "TrashType", menuName = "Game/Trash Type")]
public class TrashTypeSO : ScriptableObject
{
    [SerializeField] private string _typeName;
    [SerializeField] private int _scoreValue;
    [SerializeField] private int _polutionValue;

    public string TypeName => _typeName;
    public int ScoreValue => _scoreValue; 
    public int PolutionValue => _polutionValue; 
}