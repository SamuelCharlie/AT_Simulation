using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 20;
    [SerializeField] private int _cameraBoundary = 6;
    private Vector3 _startingPosition;
    private Vector2 _motion;

    [SerializeField]
    private float offset = 0.25f;

    private void Start()
    {
        _startingPosition = transform.position;
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x) < _cameraBoundary && Mathf.Abs(transform.position.y) <= _cameraBoundary)
        {
            _motion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            transform.Translate(_motion * _moveSpeed * Time.deltaTime);
        }
        else if (transform.position.x >= _cameraBoundary)
        {
            transform.position = new Vector3(transform.position.x - offset, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -_cameraBoundary)
        {
            transform.position = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
        }
        else if (transform.position.y >= _cameraBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
        }
        else if (transform.position.y <= -_cameraBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
        }
    }

    public void ResetCamera()
    {
        transform.position = _startingPosition;
    }
}