using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //トータルスコアを表示するテキスト
    private GameObject scoreText;
    //トータルスコアを初期化
    private int totalScore = 0;

    //スコアを初期化
    private int Score = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");

        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        //トータルスコアを表示
        this.scoreText.GetComponent<Text>().text = "Score: " + this.totalScore;

        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag" || other.gameObject.tag == "SmallCloudTag")
        {
            this.Score = 5;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.Score = 10;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.Score = 20;
        }

        this.totalScore += this.Score;
    }
}