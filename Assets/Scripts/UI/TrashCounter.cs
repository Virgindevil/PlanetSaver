using TMPro;
using UnityEngine;
using Zenject;

public class TrashCounter : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _maxNumberOfTrash;
    public int CurrentNumberOfTrash { get; private set; }

    [Inject]
    public void Construct(TrashSpawner trashSpawner)
    {
        _text = GetComponent<TextMeshProUGUI>();
        SetTrashNumber(trashSpawner.TrashNumber);
    }

    public void SetTrashNumber(int number)
    {
        _maxNumberOfTrash = number;
        CurrentNumberOfTrash = _maxNumberOfTrash;
        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = $"{CurrentNumberOfTrash} / {_maxNumberOfTrash}";
    }

    public void DecreaseTrashNumber()
    {
        CurrentNumberOfTrash--;
        UpdateText();
    }

}