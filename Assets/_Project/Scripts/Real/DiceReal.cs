using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceReal : MonoBehaviour
{
    public Rigidbody rb;
    public float throwForce;
    public float torqueForce;

    [Button]
    public void Roll()
    {
        rb.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 2f), Random.Range(-1f, 1f)) * throwForce, ForceMode.Impulse);
        //rb.AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * torqueForce, ForceMode.Impulse);
        Invoke("RollTorque", 0.1f);
    }
    public void RollTorque()
    {
        rb.AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * torqueForce, ForceMode.Impulse);
    }

}