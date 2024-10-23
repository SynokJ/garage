using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private const float _MOVEMENT_SPEED = 3.0f;
    private const float _MOVEMENT_DISTANCE_OFFSET = 2.0f;

    private Transform _targetTr;
    private Collider _collider;
    private Renderer _renderer;
    private Rigidbody _rb;

    private int _overlaps;

    void OnTriggerEnter(Collider other)
    {
        Car car = other.GetComponent<Car>();
        if (car != null) return;

        _overlaps++;
    }

    void OnTriggerExit(Collider other)
    {
        Car car = other.GetComponent<Car>();
        if (car != null) return;

        _overlaps--;
    }

    public virtual Interactable OnPickedUp(Transform targetTr)
    {
        _targetTr = targetTr;
        _rb.useGravity = false;
        _collider.isTrigger = true;
        return this;
    }

    public virtual void OnDropped()
    {
        _targetTr = null;
        _rb.useGravity = true;
        _collider.isTrigger = false;
    }

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }

    private void Update()
    {
        if (_targetTr == null) return;

        _renderer.material.color = CanDropInteractable() ? Color.green : Color.red;

        Vector3 endPos = _targetTr.position + _targetTr.forward * _MOVEMENT_DISTANCE_OFFSET;
        float speed = _MOVEMENT_SPEED * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, endPos, speed);
    }

    public bool CanDropInteractable()
        => _overlaps == 0;

}
