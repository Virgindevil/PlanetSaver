using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ObjectClickHandler : MonoBehaviour, IPointerDownHandler
{   
    public event Action OnTrashClicked;
            
    public void OnPointerDown(PointerEventData eventData)
    {
        OnTrashClicked?.Invoke();
        HandleClick();
    }

    private void HandleClick()
    {
        if (gameObject.TryGetComponent(out Trash trash))
            trash.Collect();        
    }

}