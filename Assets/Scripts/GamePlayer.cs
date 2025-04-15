using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public GameObject TextTimer;
    public GameObject TextHp;
    public GameObject TextScore;
    public GameObject TextName;

    public GameObject ItemContainer;
    public GameObject EnemyContainer;

    public GameObject Item;
    public GameObject Enemy;

    public int itemcount = 30;
    public int itemSpawnSize = 40;
    public int enemycount = 20;
    public float MapSize = 30;



    // 맞냐 틀리냐 (True or False)
    public bool IsPlaying;

    //함수
    //Debug.Log("안녕하세요"); 
    //Destroy(); <-오브젝트파괴
    //Instantiate(); <-오브젝트생성

    private void Start()
    {
        Debug.Log("Start");
        TextName.GetComponent<TMP_Text>().text = PlayerName;
        int count;

        for (count=1;count<=enemycount ;count++ )
        {
            float halfSize = MapSize / 2;
            float RandomX = Random.Range(-halfSize, halfSize);
            float RandomZ = Random.Range(-halfSize, halfSize);
            float RandomRotationY = Random.Range(0, 360);
            Instantiate(Enemy, EnemyContainer.transform);
            Enemy.transform.position = new Vector3(RandomX, 0, RandomZ);
            Enemy.transform.rotation = Quaternion.Euler(0, RandomRotationY, 0);

        }
        for (count = 1; count <= itemcount; count++)
        {
            float itemhalfSize = itemSpawnSize / 2;
            float ITemRandomX = Random.Range(-itemhalfSize, itemhalfSize);
            float ITemRandomZ = Random.Range(-itemhalfSize, itemhalfSize);
            Instantiate(Item, ItemContainer.transform);
            Item.transform.position = new Vector3(ITemRandomX, 0, ITemRandomZ);

        }
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

        TextTimer.GetComponent<TMP_Text>().text = GameTimer.ToString("F1");
        TextHp.GetComponent<TMP_Text>().text = Hp.ToString();
        TextScore.GetComponent<TMP_Text>().text = Score.ToString();

        // Instantiate (Enemy, position, rotation);

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
