using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {
    int point = 0;
    float randomTime, t = 0;
    [SerializeField] GameObject enemies;
    [SerializeField] Text pointText;
    // Start is called before the first frame update
    void Start() {
        //init
        randomTime = Random.Range(2.0f, 5.0f);
    }
    // Update is called once per frame
    void Update() {
        if (enemies.transform.childCount < 5) t += Time.deltaTime;
        if (t >= randomTime) {
            //reset
            randomTime = Random.Range(2.0f, 5.0f);
            t = 0;
            GameObject enemy = Instantiate(Resources.Load<GameObject>("Enemy"));
            enemy.name = "Enemy";
            enemy.transform.SetParent(enemies.transform);
            enemy.transform.localPosition = new Vector3(Random.Range(-216, 216), 300, 0);
        }
    }

    public void AddPoint(int p) {
        point += p;
        Debug.Log("Point: " + point);
    }
}
