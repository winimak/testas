using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;



public class movement : MonoBehaviour
{
    public float speed = 10.0f; // скорость перемещения корабля
    public float rotationSpeed = 100.0f; // скорость поворота корабля
    public Transform dist;
    public float shit_speed = 2.0f;
    

    bool rotateUp = false;
    bool rotateDown = false;
    bool rotateRight = false;
    bool rotateLeft = false;
    bool shift = false;

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shift = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shift = false;
        }


        // перемещение корабля
        float moveForward = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveForward);

        if (shift)
        {
            transform.Translate(movement * speed * 2 * Time.deltaTime);
        }
        else
        {
            transform.Translate(movement * speed * Time.deltaTime);
        }

        // поворот корабля вверх и вниз при нажатии клавиш R и F соответственно
        if (Input.GetKeyDown(KeyCode.I))
        {
            rotateUp = true;
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            rotateUp = false;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            rotateDown = true;
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            rotateDown = false;
        }

        // поворот корабля вправо и влево при нажатии клавиш Z и X соответственно
        if (Input.GetKeyDown(KeyCode.L))
        {
            rotateRight = true;
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            rotateRight = false;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            rotateLeft = true;
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            rotateLeft = false;
        }


        // вращение корабля, пока соответствующие клавиши нажаты
        if (rotateUp)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
        if (rotateDown)
        {
            transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        }
        if (rotateRight)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (rotateLeft)
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }

        var distance = Vector3.Distance(transform.position, dist.position);
        if (distance > 150)
        {
            print("boo");
            SceneManager.LoadScene(0);
        }
    }
}
