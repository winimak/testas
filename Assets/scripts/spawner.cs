using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRadius = 5.0f;
    public float spawnInterval = 2.0f;
    public float followSpeed = 5.0f;

    public GameObject target;

    private void Start()
    {
        InvokeRepeating("SpawnPrefab", 0.0f, spawnInterval);
    }

    private void SpawnPrefab()
    {
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius + transform.position;
        GameObject newPrefab = Instantiate(prefab, spawnPosition, Quaternion.identity);

        if (target != null)
        {
            FollowTarget follower = newPrefab.AddComponent<FollowTarget>();
            follower.target = target.transform;
            follower.followSpeed = followSpeed;
        }
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
}

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5.0f;

    private void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
            transform.position = newPosition;
        }

        var dist = Vector3.Distance(transform.position, target.position);
        if (dist < 7)
        {
            SceneManager.LoadScene(0);
        }
    }
}

