using UnityEngine;



public class MedkitParticleController : MonoBehaviour
{
    public ParticleSystem heartAnimation;

    private GameObject _player = null;
    private PlayerPickupMedkitController _playerPickupMedkitController;
    private PlayerHealth _playerHealth;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _player = other.gameObject;
            _playerPickupMedkitController = other.gameObject.GetComponent<PlayerPickupMedkitController>();
            _playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        }
    }

    private void Update()
    {
        if (_player != null && Input.GetKeyDown(KeyCode.E))
        {
            heartAnimation.Play();

            _playerHealth.Heal(50);
            _playerPickupMedkitController.pickUpText.SetActive(false);
            _player = null;

            Destroy(gameObject, 2f);
        }
    }
}