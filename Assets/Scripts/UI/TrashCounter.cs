using TMPro;
using UnityEngine;
using Zenject;
using System;

public class TrashCounter : MonoBehaviour
{
    public event Action OnAllTrashCollected;

    private TextMeshProUGUI _text;

    private int _maxNumberOfTrash;
    private float _divideNumber = 2.2f;
    public int CurrentNumberOfTrash { get; private set; }

    [Inject]
    public void Construct(TrashSpawner trashSpawner,WinScreen winScreen)
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

        if (CurrentNumberOfTrash <= 0)
            OnAllTrashCollected?.Invoke();
    }
    public float TrashDamageToPlanet()
    { 
        return _maxNumberOfTrash/ _divideNumber;
       
    }

}