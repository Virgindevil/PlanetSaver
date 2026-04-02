using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(ObjectClickHandler))]
public class Trash : MonoBehaviour
{
    [SerializeField] protected TrashTypeSO _trashType;
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private float _shakePower = 0.01f;
    [SerializeField] private float _shakeDuration = 0.5f;

    private Score _score;
    private Health _health;
    private TrashCounter _trashCounter;
    private TrashSpawner _trashSpawner;

    [Inject]
    public void Construct(Score score, TrashCounter trashCounter, Health health, TrashSpawner trashSpawner)
    {
        _score = score;
        _trashCounter = trashCounter;
        _health = health;
        _trashSpawner = trashSpawner;
    }

    public void StartDisaster()
    {
        StartCoroutine(ShakeAndExplode());
    }
    private IEnumerator ShakeAndExplode()
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < _shakeDuration)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * _shakePower;
            elapsed += Time.deltaTime;
            yield return null;
        }

        Explode();
    }

    private void Explode()
    {
        if (_explosionEffect != null)
            Instantiate(_explosionEffect, transform.position, Quaternion.identity);

        _trashCounter.DecreaseTrashNumber();
        _trashSpawner.NotifyTrashCollected(this);

        DamageToPlanet();
        _score.ChangeScore(-_trashType.ScoreValue);
        Destroy(gameObject);
        //gameObject.SetActive(false);         
    }


    public void Collect()
    {
        _score.ChangeScore(_trashType.ScoreValue);
        _trashCounter.DecreaseTrashNumber();
        _trashSpawner.NotifyTrashCollected(this);

        Destroy(gameObject);
        //gameObject.SetActive(false); 
    }

    public void DamageToPlanet()
    {
        _health.GetExplodeDamage(_trashType.PolutionValue);
    }
}
