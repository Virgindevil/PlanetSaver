using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Zenject;

[RequireComponent(typeof(ObjectClickHandler))]
public class Trash : MonoBehaviour
{
    [SerializeField] protected TrashTypeSO _trashType;
    
    private Score _score;
    private TrashCounter _trashCounter;

    // Zenject сам вызовет этот метод при спавне через IInstantiator
    [Inject]
    public void Construct(Score score, TrashCounter trashCounter)
    {
        _score = score;
        _trashCounter = trashCounter;
    }

    public void Collect()
    {
        _score.AddScore(_trashType.ScoreValue);
        _trashCounter.DecreaseTrashNumber();

        gameObject.SetActive(false); // Или Destroy(gameObject);
    }

    public int DamageToPlanet(int healthPoints, int damageMultiply = 1)
    {
        int currentHeath = healthPoints - (_trashType.PolutionValue * damageMultiply);
        return currentHeath;
    }
}
