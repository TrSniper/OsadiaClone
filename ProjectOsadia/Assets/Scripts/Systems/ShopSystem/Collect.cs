using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    //basit collect mant���
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        if (collision != null && collision.collider.CompareTag("Arcadium"))
        {
            PlayerData.arcadiumCount++;
            Destroy(collision.gameObject);
        }
    }
}
