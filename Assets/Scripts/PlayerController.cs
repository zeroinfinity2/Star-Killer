using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField][Tooltip("In m/s")]
    private float _controlSpeed = 15f;
    [SerializeField][Tooltip("In m/s")]
    private float _xRange = 19f;
    [SerializeField][Tooltip("In m/s")]
    private float _yRange = 13;

    [Header("Screen Position Based")]
    [SerializeField]
    private float _positionPitchFactor = -2f;
    [SerializeField]
    private float _positionYawFactor = 2.5f;

    [Header("Control Throw Based")]
    [SerializeField]
    private float _controlPitchFactor = -20f;
    [SerializeField]
    private float _controlRollFactor = -2f;


    private float xOffset;
    private float yOffset;

    private float _xThrow;
    private float _yThrow;

    private bool _isControlsEnabled = true;

    void Update()
    {
        if (_isControlsEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
        
    }

    private void ProcessTranslation()
    {
        _xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        _yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        xOffset = _xThrow * _controlSpeed * Time.deltaTime;
        yOffset = _yThrow * _controlSpeed * Time.deltaTime;

        float clampedXPos = Mathf.Clamp((transform.localPosition.x + xOffset), -_xRange, _xRange);
        float clampedYPos = Mathf.Clamp((transform.localPosition.y + yOffset), -_yRange, _yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * _positionPitchFactor + _yThrow * _controlPitchFactor;
        float yaw = transform.localPosition.x * _positionYawFactor;
        float roll = transform.localPosition.z * _xThrow * _controlRollFactor ;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    
    private void OnPlayerDeath() //Called by string reference
    {
        print("Controls frozen.");
        _isControlsEnabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;
    }

}
