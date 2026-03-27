using TMPro;
using UnityEngine;
using Zenject;

public class TrashCounter : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _currentNumberOfTrash;
    private int _maxNumberOfTrash;

    private void Awake() => _text = GetComponent<TextMeshProUGUI>();

    [Inject]
    public void Construct(TrashSpawner trashSpawner)
    {
        SetTrashNumber(trashSpawner.TrashNumber);
    }

    public void SetTrashNumber(int number)
    {
        _maxNumberOfTrash = number;
        _currentNumberOfTrash = _maxNumberOfTrash;
        UpdateText();
    }

    public void DecreaseTrashNumber() 
    {
        _currentNumberOfTrash--;
        UpdateText();
    }

    private void UpdateText() => _text.text = $"{_currentNumberOfTrash} / {_maxNumberOfTrash}";
}