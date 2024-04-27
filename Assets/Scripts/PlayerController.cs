using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Скорость перемещения игрока")]
    public float speed = 7f;
    [Header("Скорость перемещения игрока при беге")]
    public float runSpeed = 15f;
    [Header("Сила прыжка")]
    public float jumpForce = 200f;
    [Header("Мы на земле?")]
    public bool ground;
    public Rigidbody rigidbody;
    [SerializeField] public bool isInputBlocked = false;

    private void Update()
    {
        if (!isInputBlocked && Cursor.lockState == CursorLockMode.Locked)
            GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.localPosition += transform.forward * runSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += transform.forward * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.localPosition += -transform.forward * runSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += -transform.forward * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.localPosition += -transform.right * runSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += -transform.right * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.localPosition += transform.right * runSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += transform.right * speed * Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && ground == true)
        {
            rigidbody.AddForce(transform.up * jumpForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Furniture") 
        {
            ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = false;
        }
    }
}
