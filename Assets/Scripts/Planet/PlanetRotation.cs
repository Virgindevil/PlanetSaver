using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetRotation : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float _autoRotateSpeed = 10f;
    [SerializeField] private float _sensitivity = 0.5f;
    [SerializeField] private float _maxSafeSpeed = 500f; 

    private float _currentRotationSpeed;
    private Quaternion _lastRotation;
    private bool _isDragging = false;

    private void Start()
    {
        _lastRotation = transform.rotation;
    }

    private void Update()
    {
        float angleChange = Quaternion.Angle(transform.rotation, _lastRotation);
        _currentRotationSpeed = angleChange / Time.deltaTime;
        _lastRotation = transform.rotation;

        if (_currentRotationSpeed > _maxSafeSpeed)
        {
            Debug.Log("Причина тряски");
        }

        if (!_isDragging)
        {
            Quaternion targetRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _autoRotateSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up, _autoRotateSpeed * Time.deltaTime, Space.World);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        float deltaX = eventData.delta.x * _sensitivity;
        float deltaY = eventData.delta.y * _sensitivity;

        transform.Rotate(Vector3.up, -deltaX, Space.World);
        transform.Rotate(Vector3.right, deltaY, Space.World);
    }
}
