using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class TrashSpawner : MonoBehaviour, IInitializable
{
    [SerializeField] private GameObject[] _trashPrefabs;
    [SerializeField] private int _numberOfTrash = 10;

    private List<Trash> _activeTrash = new();

    private TrashFactory _trashFactory;     
    private SphereCollider _collider;

    private float _trashScaleMultiply = 1f;
    private float _damageMultiply;
    private float _baseRadius;

    public int TrashNumber => _numberOfTrash;

    [Inject]
    public void Construct(TrashFactory trashFactory)
    {
        _trashFactory = trashFactory;
        _collider = GetComponent<SphereCollider>();
        _baseRadius = _collider.radius;
        _damageMultiply = 1f;
    }

    public void Initialize()
    {
        SpawnTrash();
    }

    public void SpawnTrash()
    {
        for (int i = 0; i < _numberOfTrash; i++)
        {
            SpawnRandomTrash();
        }
    }

    private void SpawnRandomTrash()
    {
        if (_trashPrefabs == null || _trashPrefabs.Length == 0) 
            return;

        int randomIndex = Random.Range(0, _trashPrefabs.Length);
        float worldRadius = _baseRadius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z);

        Vector3 randomDir = Random.onUnitSphere;
        Vector3 spawnPosition = transform.position + (randomDir * worldRadius);

        Vector3 trashLookUp = Random.onUnitSphere;
        trashLookUp.y = 1f;

        Quaternion spawnRotation = Quaternion.FromToRotation(trashLookUp, randomDir);
        Trash newTrash = _trashFactory.Create(_trashPrefabs[randomIndex], spawnPosition, spawnRotation, transform);
        newTrash.gameObject.transform.localScale *= _trashScaleMultiply;
        _activeTrash.Add(newTrash);
    }

    public void ExplodeRandomTrash()
    {
        if (_activeTrash.Count == 0) 
            return;

        int index = Random.Range(0, _activeTrash.Count);
        Trash target = _activeTrash[index];

        if (target != null)
        {
            _activeTrash.RemoveAt(index);
            target.StartDisaster(_damageMultiply);
        }
    }

    public void NotifyTrashCollected(Trash trash) => _activeTrash.Remove(trash);

    public void SetTrashCount(int number) => _numberOfTrash = number;

    public void IncreaseTrashScale(float multiply) => _trashScaleMultiply += multiply;

    public void SetTrashDamageMultiplier(float multiply) => _damageMultiply = multiply;

    
}
