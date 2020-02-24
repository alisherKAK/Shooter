using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float damage, range, shootSpeed;

    [SerializeField]
    private int maxAmmo, maxClipAmmo;
    private int currentClipAmmo, currentAmmo, score;

    [SerializeField]
    private ParticleSystem shootEffect;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private GameObject hitEffect;

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private Text ammoCountText, scoreText;

    private void Start()
    {
        currentClipAmmo = maxClipAmmo;
        currentAmmo = maxAmmo;

        score = 0;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(currentAmmo > 0)
            {
                Shoot();
            }
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            shootEffect.Play();

            GameObject effect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(effect, 1f);

            GameObject hitObject = hit.transform.gameObject;

            if(hit.collider.tag == "Enemy")
            {
                Enemy enemy = hitObject.GetComponent<Enemy>();
                enemy.TakeDamage(damage);
                if(!enemy.IsAlive())
                {
                    score += (int)enemy.GetEnemyType();
                    ShowScore();
                    Destroy(hitObject);
                }
            }

            currentAmmo--;
            ShowAmmo();
        }
    }

    private void Reload()
    {
        int needAmmoCount = maxAmmo - currentAmmo;

        if(currentClipAmmo >= needAmmoCount)
        {
            currentAmmo += needAmmoCount;
            currentClipAmmo -= needAmmoCount;
        }
        else
        {
            currentAmmo += currentClipAmmo;
        }

        ShowAmmo();
    }

    private void ShowAmmo()
    {
        ammoCountText.text = currentAmmo + " || " + currentClipAmmo;
    }

    private void ShowScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void LoadAmmo(int ammoCount)
    {
        int needClipAmmoCount = maxClipAmmo - currentClipAmmo;
        if(needClipAmmoCount < ammoCount)
        {
            currentClipAmmo += needClipAmmoCount;
            ammoCount -= needClipAmmoCount;
        }
        else
        {
            currentClipAmmo += ammoCount;
            ShowAmmo();
            return;
        }

        int needAmmoCount = maxAmmo - currentAmmo;
        if(needAmmoCount < ammoCount)
        {
            currentAmmo += needAmmoCount;
        }
        else
        {
            currentAmmo += ammoCount;
        }

        ShowAmmo();
    }
}
