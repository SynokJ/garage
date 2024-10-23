public class PlayerInterract
{
    private const float _INTERACTION_DISTANCE = 10.0f;

    private UnityEngine.Transform _cameraTr;
    private Interactable _interactable;

    public PlayerInterract(UnityEngine.Transform cameraTr)
    {
        _cameraTr = cameraTr;
    }

    ~PlayerInterract()
    {
        _cameraTr = null;
        _interactable = null;
    }

    public void TryToInterract()
    {
        float distance = _INTERACTION_DISTANCE;
        UnityEngine.RaycastHit[] hits =
            UnityEngine.Physics.RaycastAll(_cameraTr.position, _cameraTr.forward, distance);

        UnityEngine.Debug.DrawRay(_cameraTr.position, _cameraTr.forward * distance, UnityEngine.Color.red);

        foreach (UnityEngine.RaycastHit hit in hits)
        {
            if (hit.transform.TryGetComponent(out Interactable interactable))
            {
                _interactable = interactable;
                _interactable.OnPickedUp(_cameraTr);
                break;
            }
        }
    }

    public void TryDropItem()
    {
        if (_interactable == null) return;

        if (_interactable.CanDropInteractable())
        {
            _interactable.OnDropped();
            _interactable = null;
        }
    }
}
