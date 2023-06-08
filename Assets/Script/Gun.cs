using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float impactforce = 50f;
    [SerializeField] float range = 100f;
    [SerializeField] float firingRate = 5f;
    [SerializeField] Camera FPScam;
    [SerializeField] float nextTimeToFire = 0f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gunEnd;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time / firingRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(/*gunEnd.position*/FPScam.transform.position, FPScam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            if (hit.collider != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactforce);
            }
            else
            {
                hit.rigidbody.AddForce(-hit.normal*1);
            }
        }
        GameObject bullet = Instantiate(bulletPrefab, /*FPScam.transform.*/gunEnd.position, FPScam.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = FPScam.transform.forward * 50f;
    }
}




