using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public GameObject player;
    public Image line;
    bool toLight = false;
    float moveSpeed = 3.0f;
    float sharpSpeed = 0.005f;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        //Move
        float mH = Input.GetAxis("Horizontal") * moveSpeed;
        float mV = Input.GetAxis("Vertical") * moveSpeed;
        player.transform.position += new Vector3(mH, mV, 0.0f);

        //Board
        float x = player.transform.localPosition.x;
        float y = player.transform.localPosition.y;
        float fx = Mathf.Clamp(x, -216, 216);
        float fy = Mathf.Clamp(y, -384, 100);
        player.transform.localPosition = new Vector3(fx, fy, 0.0f);

        WarningLine(fy);

        //Shoot
        if (Input.GetKeyUp(KeyCode.Space)) {
            GameObject bullet = Instantiate(Resources.Load<GameObject>("Bullet"));
            bullet.name = "Bullet";
            bullet.transform.SetParent(transform);
            bullet.transform.position = player.transform.position + new Vector3(0.0f, 80.0f, 0.0f);
        }
    }

    void WarningLine(float fy) {
        if (fy > 20) {
            float a = line.color.a;
            if (toLight) {
                line.color = new Color(1.0f, 0.0f, 0.0f, a + sharpSpeed);
                if (a >= 1.0f) toLight = false;
            } else {
                line.color = new Color(1.0f, 0.0f, 0.0f, a - sharpSpeed);
                if (a <= 0.0f) toLight = true;
            }
            line.transform.GetChild(0).GetComponent<Text>().color = line.color;
        } else {
            float a = line.color.a;
            if (a >= 0.0f) line.color = new Color(1.0f, 0.0f, 0.0f, a - sharpSpeed);
            else line.color = new Color(1.0f, 0.0f, 0.0f, 0.0f);
            line.transform.GetChild(0).GetComponent<Text>().color = line.color;
            toLight = true;
        }
    }
}
