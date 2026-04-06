using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ObjectClickHandler : MonoBehaviour, IPointerDownHandler
{               
    public void OnPointerDown(PointerEventData eventData)
    {
        HandleClick();
    }

    private void HandleClick()
    {
        if (gameObject.TryGetComponent(out Trash trash))
            trash.Collect();        
    }
}