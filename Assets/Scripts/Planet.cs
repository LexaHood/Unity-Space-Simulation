using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
    private HashSet<Rigidbody> effectBodies = new HashSet<Rigidbody>();
    private Rigidbody componentRigitBody = null;
    private const int gravityConst = 3;
    void Start() {
        componentRigitBody = GetComponent <Rigidbody>(); //получаем массу из компонента риджетбоди
    }

    private void OnTriggerEnter(Collider other) {
        if (other.attachedRigidbody != null) { //если на объекте есть риджет боди, то будем добовлять его в наш список
            effectBodies.Add(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit(Collider other) { //если объект покидает тригер и у него есть риджетбади, то удалем его из хэша
        if (other.attachedRigidbody != null) { 
            effectBodies.Remove(other.attachedRigidbody);
        }
    }

    void FixedUpdate() {
        foreach (Rigidbody body in effectBodies) {
            Vector3 directionTopPlanet = (transform.position - body.position).normalized; //вектор по направлению к планете
            float distance = (transform.position - body.position).magnitude; //расстояние между центрами планет
            float strenght = (body.mass * componentRigitBody.mass / Mathf.Pow(distance, 2)) * gravityConst; //вычисляем силу с которой планеты действуют друг на друга
            body.AddForce(directionTopPlanet * strenght);
        }
    }
}
