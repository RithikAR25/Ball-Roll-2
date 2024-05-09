using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterPlayerPass : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (GameManager.GM.player.transform.position.z > (70 + this.transform.position.z))
        {
            Destroy(gameObject);
        }
    }
}