using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickupMedkitController : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSound;
    public ParticleSystem heartAnimation;
    public GameObject pickUpText;
    private GameObject _medkit = null;


    private void Start()
    {
        pickUpText.SetActive(false);
    }

    private void Update()
    {
        if (_medkit != null && Input.GetKeyUp(KeyCode.E))
        {
            PlayPickupSound();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Medkit"))
        {
            _medkit = other.gameObject;
        }
        if (other.gameObject.CompareTag("Medkit"))
        {
            pickUpText.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {
        pickUpText.SetActive(false);
    }

    private void PlayPickupSound()
    {
        Debug.Log("pick up sound");
        SoundManager.Instance.PlaySound(this.pickupSound, this.transform, 1.0f);
    }
}