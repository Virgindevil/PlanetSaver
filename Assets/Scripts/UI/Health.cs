using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System;

[RequireComponent(typeof(Slider))]
public class Health : MonoBehaviour
{
    public event Action OnDied; 

    private Slider _healthSlider;
    private TrashCounter _trashCounter;
    private float _healthMultiply = 100f;
    private bool _isDead;

    [Inject]
    public void Construct(TrashCounter trashCounter)
    {
        _trashCounter = trashCounter;
        _healthSlider = GetComponent<Slider>();
    }

    public void TakeDamage(float damage)
    {
        _healthSlider.value -= damage;
        CheckDeath();
    }

    private void Update()
    {
        if (!_isDead)
        {
            _healthSlider.value -= _trashCounter.TrashDamageToPlanet() * Time.deltaTime;
            CheckDeath();
        }
    }

    private void CheckDeath()
    {
        if (!_isDead && _healthSlider.value <= 0)
        {
            _isDead = true;
            OnDied?.Invoke(); 
        }
    }

    public void Refill()
    {
        _healthSlider.maxValue += _healthMultiply;
        _healthSlider.value = _healthSlider.maxValue;
        _isDead = false; 
    }
}
