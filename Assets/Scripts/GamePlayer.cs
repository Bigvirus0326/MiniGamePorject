using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GamePlayer : MonoBehaviour
{
    // 숫자
    public string PlayerName; //문자 - string
    public int Score; // 숫자 - int
    public int Hp;
    public float GameTimer;

    // 맞냐 틀리냐 (True or False)
    public bool IsPlaying;

    //함수
    //Debug.Log("안녕하세요"); 
    //Destroy(); <-오브젝트파괴
    //Instantiate(); <-오브젝트생성

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

        // 아이템 습득.
        Destroy(other.gameObject);
    }
}
