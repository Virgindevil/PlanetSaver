using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ObjectClickHandler : MonoBehaviour, IPointerDownHandler
{   
    public event Action<RaycastHit> OnObjectHit;
    public event Action OnTowerClicked;
            
    public void OnPointerDown(PointerEventData eventData)
    {
        OnTowerClicked?.Invoke();
        HandleClick();
    }

    private void HandleClick()
    {
        Debug.Log($"{gameObject.name} была нажата!");
    }

}