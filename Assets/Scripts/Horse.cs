using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private bool _isMove;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _isMove = true;
    }

    void Update()
    {
        if(_isMove == false)
        {
            return; // 下のプログラムが実行されないようにここで返す
        }

        // velocity ->「速度」
        var velocity = _rb2d.velocity;

        // 速度が1未満なら加算し、1以上なら加算減算させる
        if (_rb2d.velocity.x < 1)
        {
            var random = Random.Range(0f, 0.01f); // 0から0.01の間でランダム
            velocity.x += random;
        }
        else
        {
            var random = Random.Range(-0.01f, 0.01f); // -0,01から0.01の間でランダム
            velocity.x += random;
        }

        _rb2d.velocity = velocity; // 実際に Rigidbody2D の velocity に計算結果を反映
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ScreenOutLine")
        {
            Debug.Log("画面外");
            _isMove = false;                // 動きを止める
            _rb2d.velocity = Vector2.zero;  // velocity に Vector2.zero -> (0, 0) を入れることで、停止させる
            _rb2d.isKinematic = true;       // isKinematic で物理運動を停止させる
            _rb2d.Sleep();                  // Sleep() でRigitbody2D を一時的に
        }
    }
}
