using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    float health; //����ֵ
    float speed; //�ٶ�
    float defense; //������
    [SerializeField] Slider healthBar; //������
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

    //ײ��������
    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject hitter = collision.gameObject;
        //�� <��ҵ���ͨ�ӵ�> ������
        if (hitter.name.Equals("Bullet")) {
            hitter.GetComponent<Bullet>().Hit();
            health -= 10;
        }

        //ͬ����������Ѫ�ٱ��ɫ��
        healthBar.value = health;
        if ((healthBar.value / healthBar.maxValue) <= 0.33) {
            healthBar.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = Color.red;
        }

        //����
        if (health <= 0) {
            //�ӷ�
            area.GetComponent<Spawn>().AddPoint(20);
            //ɾ�������ڿռ�
            Destroy(gameObject);
        }
    }
}
