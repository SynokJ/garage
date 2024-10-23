using UnityEngine;

public class CameraView : MonoBehaviour
{
    private const float _ROTATION_SPEED = 10.0f;

    [SerializeField] private Transform _playerTr;
    private float _currentRotValue = 0;

    private void Update()
    {
        float verRot = Input.GetAxis("Mouse Y");
        _currentRotValue -= verRot * _ROTATION_SPEED;
        _currentRotValue = Mathf.Clamp(_currentRotValue, -90, 90);

        transform.rotation = Quaternion.Euler(_currentRotValue, _playerTr.eulerAngles.y, 0.0f);
    }
}
