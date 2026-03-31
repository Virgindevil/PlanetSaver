using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(SphereCollider))]
public class TrashSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _trashPrefabs;
    [SerializeField] private int _numberOfTrash = 10;

    private List<Trash> _activeTrash = new();

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
        _activeTrash.Add(newTrash);
    }

    public void ExplodeRandomTrash()
    {
        if (_activeTrash.Count == 0) return;

        int index = Random.Range(0, _activeTrash.Count);
        Trash target = _activeTrash[index];

        if (target != null)
        {
            _activeTrash.RemoveAt(index);
            target.StartDisaster();
        }
    }

    public void NotifyTrashCollected(Trash trash)
    {
        _activeTrash.Remove(trash);
    }
}
