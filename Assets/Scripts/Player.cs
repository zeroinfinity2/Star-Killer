using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField][Tooltip("In m/s")]
    private float _speed = 20f;

    [SerializeField][Tooltip("In m/s")]
    private float _xRange = 8f;

    [SerializeField][Tooltip("In m/s")]
    private float _yRange = 8;

    [SerializeField]
    private float _pitchFactor = -2f;
    [SerializeField]
    private float _controlPitchFactor = -20f;
    [SerializeField]
    private float _yawFactor = 2f;
    [SerializeField]
    private float _rollFactor = -2f;

    private float xOffset;
    private float yOffset;

    private float _xThrow;
    private float _yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        _xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        _yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        xOffset = _xThrow * _speed * Time.deltaTime;
        yOffset = _yThrow * _speed * Time.deltaTime;

        float clampedXPos = Mathf.Clamp((transform.localPosition.x + xOffset), -_xRange, _xRange);
        float clampedYPos = Mathf.Clamp((transform.localPosition.y + yOffset), -_yRange, _yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * _pitchFactor + _yThrow * _controlPitchFactor;
        float yaw = transform.localPosition.x * _yawFactor;
        float roll = transform.localPosition.z * _xThrow * _rollFactor ;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
