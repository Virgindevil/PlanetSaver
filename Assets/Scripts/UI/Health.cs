using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Slider))]
public class Health : MonoBehaviour
{
    private Slider _healthSlider;
    private TrashCounter _trashCounter;
    private GameOverScreen _gameOverScreen;

    private float _healthMultiply = 100f;
    private float _currentHealth;

    [Inject]
    public void Construct(TrashCounter trashCounter, GameOverScreen gameOverScreen)
    {
        _trashCounter = trashCounter;
        _gameOverScreen = gameOverScreen;
        _healthSlider = GetComponent<Slider>();
        _currentHealth = _healthSlider.maxValue;
    }

    public void GetExplodeDamage(int damage)
    {
        _healthSlider.value -= damage;
    }

    private void Update()
    {
        if (_healthSlider.value > 0)
        {
            _healthSlider.value -= _trashCounter.TrashDamageToPlanet() * Time.deltaTime;
        }
        else if (!_gameOverScreen.isActiveAndEnabled && _healthSlider.value <= 0)
        {
            _gameOverScreen.Open();
        }
    }

    public void Refill()
    {
        _currentHealth += _healthMultiply;
        _healthSlider.maxValue = _currentHealth;
        _healthSlider.value = _healthSlider.maxValue;
    }
}
