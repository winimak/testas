using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
    public Rigidbody rb;
    public GameObject scaryImage;
    public NavMeshAgent agent;


    void Update()
    {

        if (!target) return;

        transform.LookAt(target);
        rb.velocity = transform.forward * speed;

        var dist = Vector3.Distance(transform.position, target.position);
        if (dist < 7)
        {
            SceneManager.LoadScene(1);
            print("boo");
        }

        /*if (distanceToTarget > 20)
        {
            target = null;
        }*/
    }
}
