using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // 移動速度
    public float speed = 5f;

    private Counter counter;

    void Start()
    {
        counter = GameObject.Find("GameDirector").GetComponent<Counter>();
    }

    void Update()
    {
        // 右へ移動
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Wall3に当たったら左端へ戻る
        if (collision.gameObject.name == "Wall3")
        {
            transform.position = new Vector3(-8f, 0.5f, -1f);
        }

        //Bulletが当たったら
        if (collision.gameObject.CompareTag("Bullet"))
        {
            counter.hitCount--;

            Destroy(collision.gameObject); //Objectだけ消す
        }
    }
}