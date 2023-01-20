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
            return; // ���̃v���O���������s����Ȃ��悤�ɂ����ŕԂ�
        }

        // velocity ->�u���x�v
        var velocity = _rb2d.velocity;

        // ���x��1�����Ȃ���Z���A1�ȏ�Ȃ���Z���Z������
        if (_rb2d.velocity.x < 1)
        {
            var random = Random.Range(0f, 0.01f); // 0����0.01�̊ԂŃ����_��
            velocity.x += random;
        }
        else
        {
            var random = Random.Range(-0.01f, 0.01f); // -0,01����0.01�̊ԂŃ����_��
            velocity.x += random;
        }

        _rb2d.velocity = velocity; // ���ۂ� Rigidbody2D �� velocity �Ɍv�Z���ʂ𔽉f
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ScreenOutLine")
        {
            Debug.Log("��ʊO");
            _isMove = false;                // �������~�߂�
            _rb2d.velocity = Vector2.zero;  // velocity �� Vector2.zero -> (0, 0) �����邱�ƂŁA��~������
            _rb2d.isKinematic = true;       // isKinematic �ŕ����^�����~������
            _rb2d.Sleep();                  // Sleep() ��Rigitbody2D ���ꎞ�I��
        }
    }
}
