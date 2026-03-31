using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    private TrashCounter _trashCounter;

    [Inject]
    public void Construct(TrashCounter trashCounter)
    {
        _trashCounter = trashCounter;
    }

    public void GetExplodeDamage(int damage)
    {
        _healthSlider.value -= damage;
    }

    private void Update()
    {
        _healthSlider.value -= _trashCounter.CurrentNumberOfTrash * Time.deltaTime;
    }
}
