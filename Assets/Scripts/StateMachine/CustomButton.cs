using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerDownHandler
{
    public event Action OnToggleChanged;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnToggleChanged?.Invoke();
    }
}