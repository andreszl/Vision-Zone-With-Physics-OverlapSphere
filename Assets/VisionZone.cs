using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class VisionZone : MonoBehaviour {
    public float range = 10f;
    public List<Collider> enemies;
    private float lastId = 0;
    public Collider[] elements;

    void FixedUpdate() {
        elements = Physics.OverlapSphere(transform.position, 10f);

        foreach (var element in elements) {
            if (element.tag == "Enemy") {

                if (element.name == "Enemy") {
                    AddEnemy(element);
                } else {
                    Collider value = enemies.Find(enemy => enemy.name == element.name);
                    
                    if (value == null) {
                        AddEnemy(element);
                    }
                }
            }
        }
    }

    void AddEnemy(Collider enemy) {
        lastId++;
        enemy.name = "Enemy" + lastId;
        enemies.Add(enemy);
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}