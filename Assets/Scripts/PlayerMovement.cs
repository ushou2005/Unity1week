using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
     [SerializeField] float MoveSpeed = 1.0f;
     [SerializeField] float JumpPower = 1.0f;
     [SerializeField] float Timer;

    private Rigidbody rb;

    public enum Stages
    {
        stage1,
        stage2,
        stage3
    }

    // Start is called before the first frame update
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        transform.position += new Vector3(MoveSpeed * Time.deltaTime, 0, 0);

        //Player移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(0, 0, MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0, 0, -MoveSpeed * Time.deltaTime);
        }

        //ジャンプ
        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(0, JumpPower, 0);
        
    }
    //障害物にあたった
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("gameOver");
        }
    }
    //goal
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("Clear");
        }
    }

}
