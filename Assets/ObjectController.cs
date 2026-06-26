using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControler : MonoBehaviour
{
    // 移動速度
    public float speed = 5f;

    void Update()
    {
        // 右へ移動
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Wall3に当たったら左端へ戻る
        if (other.gameObject.name == "Wall3")
        {
            transform.position = new Vector3(-8f, 0.5f, 0f);
        }
    }
}