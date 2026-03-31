using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ObjectClickHandler : MonoBehaviour, IPointerDownHandler
{   
    public event Action OnTowerClicked;
            
    public void OnPointerDown(PointerEventData eventData)
    {
        OnTowerClicked?.Invoke();
        HandleClick();
    }

    private void HandleClick()
    {
        if (gameObject.TryGetComponent(out Trash trash))
            trash.Collect();        
    }

}