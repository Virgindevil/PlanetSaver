using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Slider))]
public class Health : MonoBehaviour
{
    private Slider _healthSlider;
    private TrashCounter _trashCounter;
    private GameOverScreen _gameOverScreen;


    [Inject]
    public void Construct(TrashCounter trashCounter, GameOverScreen gameOverScreen)
    {
        _trashCounter = trashCounter;
        _gameOverScreen = gameOverScreen;
        _healthSlider = GetComponent<Slider>();
    }

    public void GetExplodeDamage(int damage)
    {
        _healthSlider.value -= damage;
    }

    private void Update()
    {
        if (_healthSlider.value > 0)
        {
            _healthSlider.value -= _trashCounter.CurrentNumberOfTrash * Time.deltaTime;
        }
        else
        {
            _gameOverScreen.Open();
        }
    }

    public void Refill()
    {
        _healthSlider.maxValue = _healthSlider.maxValue * 2;
        _healthSlider.value = _healthSlider.maxValue;
    }
}
