using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private GameObject Player;
    public static float speed = 20f;
    public FixedJoystick FixedJoystick;
    public Rigidbody rb;
    public float acceleration = 0.13f;

    private void Awake()
    {
        Player = gameObject;
    }

    public void Update()
    {
        if (this.transform.position.z > -40f)
        {
            rb.constraints |= RigidbodyConstraints.FreezePositionY;
        }
    }

    public void FixedUpdate()
    {
        rb.velocity += Vector3.forward * acceleration;
        Vector3 direction = Vector3.forward * FixedJoystick.Vertical + Vector3.right * FixedJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.GM.Game_Over();
            FindObjectOfType<AudioManager>().Play_Sound("GameOver");
            Player.SetActive(false);
            //FindObjectOfType<AudioManager>().Stop_Sound("BG");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player.
        if (other.CompareTag("Diamondo5side"))
        {
            GameManager.GM.Score(10);
            FindObjectOfType<AudioManager>().Play_Sound("coin1");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Hexgon"))
        {
            GameManager.GM.Score(50);
            FindObjectOfType<AudioManager>().Play_Sound("coin2");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("CubieBeveled"))
        {
            GameManager.GM.Score(100);
            FindObjectOfType<AudioManager>().Play_Sound("coin3");
            Destroy(other.gameObject);
        }
    }
}