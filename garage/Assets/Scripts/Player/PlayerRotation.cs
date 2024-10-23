public class PlayerRotation
{
    private const float _ROTATION_SPEED = 10.0f;
   
    private UnityEngine.Transform _playerTr;
    private float _currentRotationScale = 0.0f;

    public PlayerRotation(UnityEngine.Transform playerTr)
    {
        _playerTr = playerTr;
    }

    ~PlayerRotation()
    {
        _playerTr = null;
    }
    
    public void Rotate()
    {
        float rotDir = UnityEngine.Input.GetAxis("Mouse X");
        _currentRotationScale += rotDir * _ROTATION_SPEED;

        UnityEngine.Vector3 tempRotation = new UnityEngine.Vector3(0.0f, _currentRotationScale, 0.0f);
        _playerTr.rotation = UnityEngine.Quaternion.Euler(tempRotation);
    }
}
