using UnityEngine;

public class GarageDoors : MonoBehaviour
{
    private const float _VERTICAL_POSITION_ORIGIN_SCALE = 1.5f;
    private const float _VERTICAL_POSITION_DESTINATION_SCALE = 4.5f;

    [SerializeField] private Transform _doorTr;

    private float _currentDestPoint = _VERTICAL_POSITION_ORIGIN_SCALE;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
            _currentDestPoint = _VERTICAL_POSITION_DESTINATION_SCALE;
    }

    private void OnTriggerExit(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
            _currentDestPoint = _VERTICAL_POSITION_ORIGIN_SCALE;
    }

    private void Update()
    {
        float distance = Mathf.Abs(_currentDestPoint - _doorTr.position.y);
        if (distance < 0.001f) return;

        Vector3 destPos = new Vector3(_doorTr.position.x, _currentDestPoint, _doorTr.position.z);
        _doorTr.position = Vector3.Lerp(_doorTr.position, destPos, Time.deltaTime);
    }
}
