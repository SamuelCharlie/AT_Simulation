using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField]  private float _zoomSpeed = 0f;
    [SerializeField]  private float _minZoomFOV = 0f;
    [SerializeField]  private float _maxZoomFOV = 0f;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ZoomIn();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ZoomOut();
        }
    }

    public void ZoomIn()
    {
        _camera.fieldOfView -= _zoomSpeed;
        if (_camera.fieldOfView < _minZoomFOV)
        {
            _camera.fieldOfView = _minZoomFOV;
        }
    }

    public void ZoomOut()
    {
        _camera.fieldOfView += _zoomSpeed;
        if (_camera.fieldOfView > _maxZoomFOV)
        {
            _camera.fieldOfView = _maxZoomFOV;
        }
    }
}
