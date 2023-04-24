using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField][Range(1f, 50f)] private float _MovementSpeed = 10f;
    [SerializeField][Range(1f, 50f)] private float _RotationSpeed = 10f;
    [SerializeField][Range(1f, 50f)] private float _ZoomMultiplier = 10f;
    [SerializeField][Range(1f, 10f)] private float _ZoomSpeed = 10f;
    [SerializeField] private float _ZoomMinY = 5f;
    [SerializeField] private float _ZoomMaxY = 60f;
    [SerializeField] private CinemachineVirtualCamera _CinemachineVirtualCamera;

    private Vector2 _movementVector;
    private float _rotationValue;
    private float _zoomValue;

    private Vector3 _targetZoom;

    private bool _autoMoveEnabled;

    private InputControls _controls;
    private CinemachineTransposer _cameraTransposer;

    private void Awake()
    {
        _cameraTransposer = _CinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        _targetZoom = _cameraTransposer.m_FollowOffset;
    }

    private void OnEnable()
    {
        _controls = new InputControls();
        _controls.Camera.Rotate.performed += Rotate_performed;
        _controls.Camera.Rotate.canceled += ctx => _rotationValue = 0;

        _controls.Camera.Zoom.performed += Zoom_performed;
        _controls.Camera.Zoom.canceled += ctx => _zoomValue = 0;
        _controls.Camera.Enable();
    }

    private void OnDisable()
    {
        _controls.Camera.Disable();
    }

    private void OnMove(InputValue movementValue)
    {
        _movementVector = movementValue.Get<Vector2>();
    }

    private void Rotate_performed(InputAction.CallbackContext ctx)
    {
        float tempValue = ctx.ReadValue<float>();
        if (tempValue > 0)
        {
            _rotationValue = tempValue;
            return;
        }
        _rotationValue = ctx.ReadValue<float>();
    }

    private void Zoom_performed(InputAction.CallbackContext ctx)
    {
        _zoomValue = -ctx.ReadValue<float>();
    }

    private void Update()
    {
        if(!_autoMoveEnabled)
        {
            _targetZoom.y = Mathf.Clamp((_targetZoom.y * _zoomValue < 0 ? _cameraTransposer.m_FollowOffset.y : _targetZoom.y) + _zoomValue * _ZoomMultiplier * 0.01f, _ZoomMinY, _ZoomMaxY);
            if (Mathf.Abs(_cameraTransposer.m_FollowOffset.y - _targetZoom.y) < 0.1f)
            {
                _cameraTransposer.m_FollowOffset = _targetZoom;
            }
            else
            {
                _cameraTransposer.m_FollowOffset = Vector3.Lerp(_cameraTransposer.m_FollowOffset, _targetZoom, Time.deltaTime * _ZoomSpeed);
            }

            Vector3 movement = transform.forward * _movementVector.y + transform.right * _movementVector.x;
            float speedMultiplier = (_targetZoom.y - _ZoomMinY) / (_ZoomMaxY - _ZoomMinY) + 1f;
            transform.position += movement * Time.deltaTime * _MovementSpeed * speedMultiplier;

            transform.eulerAngles += new Vector3(0f, _rotationValue * Time.deltaTime * _RotationSpeed, 0f);
        }
    }

    internal void MoveCameraTo(Vector3 targetPostion)
    {
        if (_autoMoveEnabled)
            return;

        _autoMoveEnabled = true;
        StartCoroutine(AutoMoveCoroutine(targetPostion));
    }

    private IEnumerator AutoMoveCoroutine(Vector3 targetPostion) {
        Vector3 diff = (targetPostion - transform.position);
        while(diff.sqrMagnitude > 0.01f)
        {
            transform.position += _MovementSpeed * Time.deltaTime * new Vector3(diff.x, 0, diff.z);
            diff = targetPostion - transform.position;
            yield return null;
        }
        transform.position = targetPostion;
        _autoMoveEnabled = false;
        yield return null;
    }
}
