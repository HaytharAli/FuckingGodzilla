using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CartersController : MonoBehaviour
{
    /*[SerializeField]*/ float playerSpeed = 6.0f;
    /*[SerializeField]*/ float playerLookSpeed = 180.0f;

    [SerializeField] float bulletLifetime = 1.0f;
    [SerializeField] int maxBullets = 16;

    [SerializeField] AudioClipRandomizer footsteps;

    [SerializeField] int playerNumber = 1;

    [SerializeField] GameObject muzzle;
    [SerializeField] GameObject bulletTarget;

    bool isMoving = false;
    bool isCoroutineRunning = false;
    string axisName;
    int bulletCount = 0;
    bool gunCooldown = false;

    public void Movement(Vector3 thumbstick)
    {
        Vector3 oldPos = transform.position;

        transform.position = new Vector3(
        transform.position.x + (thumbstick.x * playerSpeed * Time.deltaTime),
        transform.position.y,
        transform.position.z + (thumbstick.z * playerSpeed * Time.deltaTime));

        if (oldPos == transform.position)
            isMoving = true;

        if (!isCoroutineRunning)
            StartCoroutine(Footsteps());
    }

    public void Aiming()
    {
        transform.Rotate(0, Input.GetAxis(axisName + "RS_hori") * playerLookSpeed * Time.deltaTime, 0);
    }

    public void Fire()
    {
        if (gunCooldown || bulletCount >= maxBullets)
        {
            return;
        }
        gunCooldown = true;
        StartCoroutine(FireGun());
    }

    IEnumerator Footsteps()
    {
        isCoroutineRunning = true;
        if (isMoving)
        {
            //footsteps.PlaySFX();

            yield return new WaitForSeconds(playerSpeed / 12.0f);
        }
        isCoroutineRunning = false;
    }
    IEnumerator FireGun()
    {
        Object bullet = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Bullet.prefab", typeof(GameObject));
        GameObject bulletClone = Instantiate(bullet, transform) as GameObject;
        Vector3 startPos = muzzle.transform.position;
        Vector3 targetPos = bulletTarget.transform.position;
        bulletCount++;
        bool oneTimeCheck = false;

        float currentTime = 0.0f;

        while (currentTime < bulletLifetime) {
            Vector3 pos = new Vector3(Mathf.Lerp(startPos.x, targetPos.x, currentTime / bulletLifetime),
                Mathf.Lerp(startPos.y, targetPos.y, currentTime / bulletLifetime),
                Mathf.Lerp(startPos.z, targetPos.z, currentTime / bulletLifetime));

            bulletClone.transform.position = pos;


            if (currentTime > 0.25f && !oneTimeCheck)
            {
                gunCooldown = false;
                oneTimeCheck = true;
            }

            currentTime += Time.deltaTime;

            yield return null;
        }

        Destroy(bulletClone);
        bulletCount--;

        yield break;
    }

    public int PlayerNumber
    {
        get => playerNumber;
    }
}
