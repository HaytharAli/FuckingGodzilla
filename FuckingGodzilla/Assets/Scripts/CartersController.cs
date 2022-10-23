using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class CartersController : MonoBehaviour
{
    /*[SerializeField]*/ float playerSpeed = 6.0f;
    /*[SerializeField]*/ float playerLookSpeed = 180.0f;

    [SerializeField] float bulletLifetime = 1.0f;
    [SerializeField] int maxBullets = 16;

    [SerializeField] AudioClipRandomizer footsteps;

    [SerializeField] int playerNumber = 1;
    [SerializeField] int characterNumber = 1;

    [SerializeField] GameObject muzzle;
    [SerializeField] GameObject bulletTarget;

    bool isMoving = false;
    bool isCoroutineRunning = false;
    string axisName;
    int bulletCount = 0;
    bool gunCooldown = false;

    Vector3 spawnPoint = Vector3.zero;

    UnityAction onRoundStart;
    InputSupervisor inputThang;

    private void Start()
    {
        onRoundStart += returnToSpawn;
        EventChad.instance.onRoundStart.AddListener(onRoundStart);
        inputThang = gameObject.GetComponent<InputSupervisor>();
    }

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

    public void Aiming(Vector3 thumbstick)
    {
        transform.LookAt(transform.position + thumbstick);
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

        Vector3 force = muzzle.transform.right;
        force = force.normalized * 5000;

        bulletClone.transform.position = muzzle.transform.position;
        bulletClone.GetComponent<Rigidbody>().AddForce(force);

        while (currentTime < bulletLifetime) {
            //Vector3 pos = new Vector3(Mathf.Lerp(startPos.x, targetPos.x, currentTime / bulletLifetime),
            //    Mathf.Lerp(startPos.y, targetPos.y, currentTime / bulletLifetime),
            //    Mathf.Lerp(startPos.z, targetPos.z, currentTime / bulletLifetime));

            //bulletClone.transform.position = pos;


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
        set { playerNumber = value; }
    }

    public int CharacterNumber
    {
        get => characterNumber;
        set { characterNumber = value; }
    }

    public void returnToSpawn()
    {
        if(playerNumber == 1)
        {
            spawnPoint.x = -8;
        }
        else
        {
            spawnPoint.x = 8;
        }
        transform.position = spawnPoint;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            Debug.Log("Piss Baby");
            inputThang.stopInput();
        }
    }
}
