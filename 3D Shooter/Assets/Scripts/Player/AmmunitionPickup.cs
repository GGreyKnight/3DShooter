using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionPickup : MonoBehaviour
{
    [SerializeField] private int ammunitionCount;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<PlayerMovementController>() != null)
        {
            AmmunitionManager.instance.AddAmmunition(ammunitionCount);
            Destroy(gameObject);
        }
    }
}
