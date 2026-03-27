using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(SphereCollider))]
public class TrashSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _trashPrefabs;
    [SerializeField] private int _numberOfTrash = 10;

    private TrashFactory _trashFactory;

    [Inject]
    public void Construct(TrashFactory trashFactory)
    {
        _trashFactory = trashFactory;
    }

    private IInstantiator _instantiator;
    private SphereCollider _collider;
    private float _baseRadius;

    public int TrashNumber => _numberOfTrash;

    [Inject]
    public void Construct(IInstantiator instantiator)
    {
        _instantiator = instantiator;
        _collider = GetComponent<SphereCollider>();
        _baseRadius = _collider.radius;

        for (int i = 0; i < _numberOfTrash; i++)
        {
            SpawnRandomTower();
        }
    }

    private void SpawnRandomTower()
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
        //GameObject newTrash = _instantiator.InstantiatePrefab(_trashPrefabs[randomIndex], spawnPosition, spawnRotation, transform);
        //GameObject newTrash = Instantiate(_trashPrefabs[randomIndex], spawnPosition, spawnRotation);

        newTrash.transform.SetParent(transform, true);
    }
}
