using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler,
                               IDragHandler, IPointerUpHandler
{
    public RectTransform _Contrainer;
    public RectTransform _Joystick;

    private Vector3 _inputVector;
    public Vector3 InputVector
    {
        get
        {
            return _inputVector;
        }
    }

    public void OnPointerDown(PointerEventData e)
    {
        OnDrag(e);
    }

    public void OnDrag(PointerEventData e)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _Contrainer,
            e.position,
            e.pressEventCamera,
            out pos))
        {

            pos.x = (pos.x / _Contrainer.sizeDelta.x);
            pos.y = (pos.y / _Contrainer.sizeDelta.y);

            _inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
            _inputVector = (_inputVector.magnitude > 1.0f) ?
                            _inputVector.normalized : _inputVector;

            _Joystick.anchoredPosition = new Vector3(
                                                                                     _inputVector.x * (_Contrainer.sizeDelta.x * .4f),
                            _inputVector.z * (_Contrainer.sizeDelta.y * .4f));
            //Debug.Log("Input Vector : " + _inputVector.ToString());
        }
    }

    public void OnPointerUp(PointerEventData e)
    {
        _inputVector = Vector3.zero;
        _Joystick.anchoredPosition = Vector3.zero;
        //Debug.Log("Input Vector : " + _inputVector.ToString());
    }
    public float Horizontal()
    {
        if (_inputVector.x != 0)
        {
            return _inputVector.x;
        }
        return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (_inputVector.z != 0)
        {
            return _inputVector.z;
        }
        return Input.GetAxis("Vertical");
    }
}