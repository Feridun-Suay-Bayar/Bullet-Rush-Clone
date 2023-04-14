using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] Image pivotImage;
    public  Vector2 _position;
    public static Vector2 direction;
    private void Start()
    {
        pivotImage.enabled = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _position = eventData.position;
        pivotImage.enabled = true;
        pivotImage.transform.position = _position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _position = Vector2.zero;
        direction = Vector2.zero;
        pivotImage.enabled = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        direction = (eventData.position - _position).normalized;
    }
}

