using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    //speedを制御
    public float speed = 10;
    [SerializeField]
    public int stock;
    [SerializeField]
    private LifeStock lifeStock;

    void Start()
    {
 
        lifeStock.SetLifeGauge(stock);
    }

    void FixedUpdate()
    {
        //入力をxとzに代入
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //同一のGameObjectが持つRigidbodyコンポーネントを取得
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.AddForce(x * speed, 0, z * speed);
    }
    public void Damage(int damage)
    {
        stock -= damage;
        stock = Mathf.Max(0, stock);

        if (stock >= 0)
        {
            lifeStock.SetLifeGauge(stock);
        }
    }



}
