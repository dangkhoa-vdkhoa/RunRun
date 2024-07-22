using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class control_phone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public hero player; // Tham chiếu đến đối tượng hero
    public void OnPointerDown(PointerEventData eventData)
    {
        // Xử lý sự kiện nhấn
        if (gameObject.name == "MoveLeft")
        {
            player.MoveLeftButtonDown();
        }
        else if (gameObject.name == "MoveRight")
        {
            player.MoveRightButtonDown();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Xử lý sự kiện thả
        if (gameObject.name == "MoveLeft")
        {
            player.MoveLeftButtonUp();
        }
        else if (gameObject.name == "MoveRight")
        {
            player.MoveRightButtonUp();
        }
    }
}
