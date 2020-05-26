using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {
    public Vector3 Force;
    void Start()  {
        GetComponent<Rigidbody>().AddForce(Force);
    }
}
