using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.Button;

public class Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField]
    private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();
    bool m_IsPressed = false;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        m_IsPressed = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        m_IsPressed = false;
    }
    private void Update()
    {
        if (m_IsPressed)
        {
            m_OnClick.Invoke();
        }
    }
}
