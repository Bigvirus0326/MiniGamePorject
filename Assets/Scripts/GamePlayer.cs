using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GamePlayer : MonoBehaviour
{
    // ����
    public string PlayerName; //���� - string
    public int Score; // ���� - int
    public int Hp;
    public float GameTimer;

    // �³� Ʋ���� (True or False)
    public bool IsPlaying;

    //�Լ�
    //Debug.Log("�ȳ��ϼ���"); 
    //Destroy(); <-������Ʈ�ı�
    //Instantiate(); <-������Ʈ����

    private void Start()
    {
        Debug.Log("Start");
    }

    private void Update()
    {
        if (!IsPlaying)
        {
            Debug.Log("Game Over");
            return;
        }
        GameTimer = GameTimer - Time.deltaTime;
        if (GameTimer < 0)
        {
            IsPlaying = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isEnemy = other.gameObject.tag == "Enemy";
        bool isItem = other.gameObject.tag == "Item";

        if (isEnemy)
        {
            Debug.Log("Enemy Check");
            Hp = Hp - 1;
            if (Hp <= 0)
            {
                IsPlaying = false;
            }
        }
        if (isItem)
        {
            Debug.Log("Item Check");
            Score = Score + 1;
        }

        // ������ ����.
        Destroy(other.gameObject);
    }
}
