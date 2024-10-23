using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _cameraTr;

    private PlayerMovement _movement;
    private PlayerRotation _rotation;
    private PlayerInterract _playerInterract;

    void Awake()
    {
        _movement = new PlayerMovement(_rb);
        _rotation = new PlayerRotation(transform);
        _playerInterract = new PlayerInterract(_cameraTr);
    }

    private void Start()
    {
        UnityEngine.Cursor.lockState = UnityEngine.CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        _movement = null;
        _rotation = null;
        _rb = null;
    }

    void Update()
    {
        _movement.Move();
        _rotation.Rotate();

        if(Input.GetMouseButtonDown(0))
            _playerInterract.TryToInterract();

        if (Input.GetKeyDown(KeyCode.G))
            _playerInterract.TryDropItem();
    }
}
