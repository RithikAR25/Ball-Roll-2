using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject PlanePrefab;
    public GameObject Player;
    private float spawn_point_z = 0f;
    private float Plane_spawn_z = 100f;
    public GameObject instantiatedPlane;

    private void FixedUpdate()
    {
        if (Player != null)
        {
            if (Player.transform.position.z > spawn_point_z)
            {
                Spawner();
            }
        }
    }

    //rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
    private void Spawner()
    {
        spawn_point_z += 50;
        instantiatedPlane = Instantiate(PlanePrefab, new Vector3(0f, 0f, Plane_spawn_z), Quaternion.identity);
        Plane_spawn_z += 100;
    }
}