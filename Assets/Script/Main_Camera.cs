using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    public Transform target; // Reference to the object you want the camera to follow
    public Vector3 offset;
    public GameObject player;

    private void Update()
    {
        if (player != null)
        {
            transform.position = target.position + offset;
        }
    }
}