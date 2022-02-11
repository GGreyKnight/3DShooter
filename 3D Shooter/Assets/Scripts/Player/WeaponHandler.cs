using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private List<Gun> guns = new List<Gun>();

    private AmmunitionManager ammunitionManager;

    private Transform cameraTransform;
    private Gun currentGun;
    private GameObject currentGunPrefab;

    private void Start()
    {
        ammunitionManager = AmmunitionManager.instance;
        cameraTransform = Camera.main.transform;
        currentGunPrefab = Instantiate(guns[0].gunPrefab, transform);
        currentGun = guns[0];
    }

    private void Update()
    {
        CheckForShooting();
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(currentGunPrefab);
            currentGunPrefab = Instantiate(guns[0].gunPrefab, transform);
            currentGun = guns[0];
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(currentGunPrefab);
            currentGunPrefab = Instantiate(guns[1].gunPrefab, transform);
            currentGun = guns[1];
        }
    }

    private void CheckForShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(currentGun == guns[1])
            {
                if (ammunitionManager.ConsumeAmmo())
                {
                    RaycastHit whatIHit;
                    if (Physics.Raycast(cameraTransform.position, transform.forward, out whatIHit, Mathf.Infinity))
                    {
                        IDamageable damageable = whatIHit.collider.GetComponent<IDamageable>();
                        if (damageable != null)
                        {
                            float normalDistance = whatIHit.distance / currentGun.maximumRange;
                            if (normalDistance <= 1)
                            {
                                damageable.DealDamage(Mathf.RoundToInt(Mathf.Lerp(currentGun.maxDamage, currentGun.minDamage, normalDistance)));
                            }
                        }
                    }
                }
            }
            else
            {
                RaycastHit whatIHit;
                if (Physics.Raycast(cameraTransform.position, transform.forward, out whatIHit, Mathf.Infinity))
                {
                    IDamageable damageable = whatIHit.collider.GetComponent<IDamageable>();
                    if (damageable != null)
                    {
                        float normalDistance = whatIHit.distance / currentGun.maximumRange;
                        if (normalDistance <= 1)
                        {
                            damageable.DealDamage(Mathf.RoundToInt(Mathf.Lerp(currentGun.maxDamage, currentGun.minDamage, normalDistance)));
                        }
                    }
                }
            }
        }
    }
}
