using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpoint1 : MonoBehaviour
{
    private int playerInfo;
    private int originScore;
    public GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit)
    {
        // 接触したオブジェクトのタグが"Player"の場合
        if (hit.gameObject.CompareTag("Player"))
        {
            playerInfo = a.GetComponent<PlayerController>().stock;
            originScore = playerInfo;
            LoadScore();
   
        }

    }
    public void LoadScore()
    {
        SceneManager.sceneLoaded += GameSceneLoaded;

        SceneManager.LoadScene("map2");//""の中身は次のシーンの名前
    }

    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        var loadScore = GameObject.Find("Player").GetComponent<PlayerController2>();
        loadScore.stock = originScore;

        SceneManager.sceneLoaded -= GameSceneLoaded;

    }
}
