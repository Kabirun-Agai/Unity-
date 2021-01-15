using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DangerWall3 : MonoBehaviour
{
    [SerializeField]
    public GameObject playerController;
    public GameObject LoserLabelObject;
    int count;
    void Start()
    {
        playerController = GameObject.Find("Player");

    }
    // オブジェクトと接触した時に呼ばれるコールバック
    void OnCollisionEnter(Collision hit)
    {
        // 接触したオブジェクトのタグが"Player"の場合
        if (hit.gameObject.CompareTag("Player"))
        {
            playerController.GetComponent<PlayerController3>().Damage(1);

            // 現在のシーン番号を取得
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            count = playerController.GetComponent<PlayerController3>().stock;
            if (count == 0)
            {
                LoserLabelObject.SetActive(true);

            }


        }
    }
}
