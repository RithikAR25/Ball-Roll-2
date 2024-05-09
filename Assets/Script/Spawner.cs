using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Spawner : MonoBehaviour
{
    public GameObject Player;
    public GameObject Spawn_obj;
    private bool spawn = false;
    private bool start = false;
    public float spawn_poston;
    public float starttime;
    public float Waittime;
    public float spawn_x1;
    public float spawn_x2;
    public float spawn_y;
    public float spawn_z1;
    public float spawn_z2;

    private void FixedUpdate()
    {
        if (Player.transform.position.z > -40f)
        {
            spawn = true;
            this.transform.position = Player.transform.position;
        }
        if (Player.transform.position.z > spawn_poston && !start)
        {
            StartCoroutine(Spawner_Spawn());
            start = true;
        }
        spawn = Player.activeSelf;
    }

    public IEnumerator Spawner_Spawn()
    {
        yield return new WaitForSeconds(starttime);
        while (spawn == true)
        {
            Vector3 randomPos = new Vector3(UnityEngine.Random.Range(spawn_x1, spawn_x2), spawn_y, UnityEngine.Random.Range(transform.position.z + spawn_z1, transform.position.z + spawn_z2));
            Instantiate(Spawn_obj, randomPos, Quaternion.identity);
            yield return new WaitForSeconds(Waittime);
        }
    }
}