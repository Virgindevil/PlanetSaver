using TMPro;
using UnityEngine;
using Zenject;

public class TrashCounter : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private WinScreen _winScreen;
    private int _maxNumberOfTrash;
    public int CurrentNumberOfTrash { get; private set; }

    [Inject]
    public void Construct(TrashSpawner trashSpawner,WinScreen winScreen)
    {
        _text = GetComponent<TextMeshProUGUI>();
        SetTrashNumber(trashSpawner.TrashNumber);
        _winScreen = winScreen;
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

        if (CurrentNumberOfTrash <= 0)
        {
            _winScreen.Open();
        }
    }

}