public class PlayerMovement
{
    private const float _MOVEMENT_SPEED = 30.0f;

    private UnityEngine.Rigidbody _playerRb;

    public PlayerMovement(UnityEngine.Rigidbody playerRb)
    {
        _playerRb = playerRb;
    }

    ~PlayerMovement()
    {
        _playerRb = null;
    }

    public void Move()
    {
        float horMove = UnityEngine.Input.GetAxis("Horizontal");
        float verMove = UnityEngine.Input.GetAxis("Vertical");

        UnityEngine.Vector3 dir = _playerRb.transform.right * horMove + _playerRb.transform.forward * verMove;
        float speed = _MOVEMENT_SPEED * UnityEngine.Time.deltaTime;
        _playerRb.MovePosition(_playerRb.transform.position + dir * speed);
    }
}
