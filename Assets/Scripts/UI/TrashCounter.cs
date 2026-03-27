using TMPro;
using UnityEngine;
using Zenject;

public class TrashCounter : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _currentNumberOfTrash;
    private int _maxNumberOfTrash;

    [Inject]
    public void Construct(TrashSpawner trashSpawner)
    {
        // Сначала получаем ссылку на текст!
        _text = GetComponent<TextMeshProUGUI>();

        // Теперь вызываем логику, которая использует _text
        SetTrashNumber(trashSpawner.TrashNumber);
    }

    public void SetTrashNumber(int number)
    {
        _maxNumberOfTrash = number;
        _currentNumberOfTrash = _maxNumberOfTrash;
        UpdateText();
    }

    private void UpdateText()
    {
        // Теперь _text точно не null
        _text.text = $"{_currentNumberOfTrash} / {_maxNumberOfTrash}";
    }

    public void DecreaseTrashNumber()
    {
        _currentNumberOfTrash--;
        UpdateText();
    }

}