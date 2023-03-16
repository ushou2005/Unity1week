using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpPower;
    [SerializeField] float Timer;

    [SerializeField] GameObject Ground;

    [SerializeField] bool isGround ;
    [SerializeField] bool isGenerate;

    private int StageCount = 0;

    private Rigidbody rb;

    private Vector3 GeneratePosition = new Vector3(240, 0, 0);

    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject ClearUI;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void Start()
    {
        //最初に生成して伸ばす
        Instantiate(Ground, GeneratePosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime;

        //Player移動
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, -MoveSpeed * Time.deltaTime);
        }

        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(0, JumpPower, 0);
            isGround = false;
        }
    }
    //障害物にあたった
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("gameOver");
            GameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
    //goal
    private void OnTriggerEnter(Collider other)
    {
        isGenerate = true;
        if (other.gameObject.tag == "Goal" && isGenerate)
        {
            Instantiate(Ground, GeneratePosition, Quaternion.identity);
            StageCount++;
            isGenerate = false;
            //４回ゴールしたらクリア
            if (StageCount == 5)
            {
                ClearUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    //リトライ
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    }
