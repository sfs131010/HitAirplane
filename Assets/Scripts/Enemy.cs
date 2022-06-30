using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    float health; //生命值
    float speed; //速度
    float defense; //防御力
    [SerializeField] Slider healthBar; //生命条
    GameObject area;

    // Start is called before the first frame update
    void Start() {
        defense = 10;
        healthBar.maxValue = 80;
        healthBar.value = health = 80;
        area = GameObject.Find("Area");
    }

    void GetDamage(float damage) {
        float final = damage - defense;
        if (final <= 0) return;
        health -= final;
    }

    //撞到东西了
    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject hitter = collision.gameObject;
        //被 <玩家的普通子弹> 打中了
        if (hitter.name.Equals("Bullet")) {
            hitter.GetComponent<Bullet>().Hit();
            health -= 10;
        }

        //同步生命条（血少变红色）
        healthBar.value = health;
        if ((healthBar.value / healthBar.maxValue) <= 0.33) {
            healthBar.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = Color.red;
        }

        //死亡
        if (health <= 0) {
            //加分
            area.GetComponent<Spawn>().AddPoint(20);
            //删除对象腾空间
            Destroy(gameObject);
        }
    }
}
