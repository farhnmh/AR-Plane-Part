using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageUICanvasObjectScaler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _isDragging;
    public float minHeight, minWidth;
    public float maxHeight, maxWidth;
    public float minScale = 1, maxScale = 2;
    private float _temp = 0;
    public float _scalingRate = 0.1f;
    public RectTransform _contentRectTransform;
    private RectTransform _rectTransform;
    private Vector2 _currentSizeDelta;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _contentRectTransform = _rectTransform.parent.GetComponent<RectTransform>();
        _currentSizeDelta = _rectTransform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isDragging = false;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
            {
            //transform.localScale = new Vector2(_currentScale, _currentScale);
            _rectTransform.localScale = _currentSizeDelta;
            float distance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);

            if (_temp > distance)
                {
                if (_currentSizeDelta.x < minWidth || _currentSizeDelta.y < minHeight) {
                    print("minimal size");
                    return;
                }
                    //_currentScale -= (Time.deltaTime) * _scalingRate;
                _currentSizeDelta.x -= (Time.deltaTime) * _scalingRate;
                _currentSizeDelta.y -= (Time.deltaTime) * _scalingRate;
            }

            else if (_temp < distance)
                {
                if (_currentSizeDelta.x > maxWidth || _currentSizeDelta.y > maxHeight) {
                    print("max size");
                    return;
                }
                    //_currentScale += (Time.deltaTime) * _scalingRate;
                _currentSizeDelta.x += (Time.deltaTime) * _scalingRate;
                _currentSizeDelta.y += (Time.deltaTime) * _scalingRate;
            }

            _temp = distance;
        }
    }

    public void ScaleUp()
    {
        if (_contentRectTransform.localScale.x < maxScale)
        {
            _currentSizeDelta.x += _scalingRate;
            _currentSizeDelta.y += _scalingRate;
            _contentRectTransform.localScale = _currentSizeDelta;
        }
    }

    public void ScaleDown()
    {
        if (_contentRectTransform.localScale.x > minScale)
        {
            _currentSizeDelta.x -= _scalingRate;
            _currentSizeDelta.y -= _scalingRate;
            _contentRectTransform.localScale = _currentSizeDelta;
        }
    }

}
