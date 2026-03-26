using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TrashSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _trashPrefabs;
    [SerializeField] private int _numberOfTrash = 10;

    private SphereCollider _collider;
    private float _baseRadius;

    private void Start()
    {
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

        Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, randomDir);
        GameObject newTrash = Instantiate(_trashPrefabs[randomIndex], spawnPosition, spawnRotation);

        newTrash.transform.SetParent(transform, true);
    }
}
