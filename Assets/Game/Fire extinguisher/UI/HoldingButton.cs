using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldingButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static event Action HoldingDownTheButton;
    public static event Action UpTheButton;

    bool _down;

    void Update()
    {
        if (_down)
            HoldingDownTheButton();
        else
            UpTheButton();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _down = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _down = false;
    }
}
