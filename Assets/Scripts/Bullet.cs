using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    float bulletSpeed = 6.0f;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (transform.localPosition.y >= 400) {
            Destroy(gameObject);
        } else {
            transform.localPosition += new Vector3(0.0f, bulletSpeed, 0.0f);
        }
    }

    public void Hit() {
        Destroy(gameObject);
    }
}