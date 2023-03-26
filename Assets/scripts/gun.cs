using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gun : MonoBehaviour
{
    public GameObject prefab;
    public float speed = 10.0f;
    public float fireRate = 0.2f;
    public int maxAmmo = 10;
    public float ammoRestoreTime = 5.0f;
    public TMP_Text ammoText;
    public AudioSource audio;

    private float nextFireTime;
    private int currentAmmo;
    private float lastRestoreTime;

    private void Start()
    {
        currentAmmo = maxAmmo;
        lastRestoreTime = Time.time;
        UpdateAmmoText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime && currentAmmo > 0)
        {
            nextFireTime = Time.time + fireRate;
            currentAmmo--;

            GameObject newPrefab = Instantiate(prefab, transform.position, transform.rotation);
            Rigidbody rb = newPrefab.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * speed;

            UpdateAmmoText();
        }

        if (currentAmmo < maxAmmo && Time.time >= lastRestoreTime + ammoRestoreTime)
        {
            currentAmmo++;
            lastRestoreTime = Time.time;

            UpdateAmmoText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(this.gameObject);
        audio = GetComponent<AudioSource>();
        audio.Play(0);
    }

    private void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }
}
