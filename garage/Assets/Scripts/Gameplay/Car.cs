using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;

    private int _interactablesAmount = 0;

    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {
            _interactablesAmount++;
            if(_interactablesAmount >= 3 && _particles.isStopped)
                _particles.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {
            _interactablesAmount--;
            if (_interactablesAmount < 3 && _particles.isPlaying)
                _particles.Stop();
        }
    }
}
