using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class UnityChanController : MonoBehaviour
{

    private Animator unichanAnimator;
    private Rigidbody unichanRigidbody;

    private float forwardForce = 800.0f;
    private float forwardBoostForce = 2000.0f;
    private float upForce = 500.0f;
    private float turnForce = 500.0f;
    

    private float movableRange = 3.4f;
    private float coefficient = 0.95f;

    private bool isEnd = false;

    private Text stateText;
    private GameObject scoreText;
    private int score = 0;

    private bool isLButtonDown = false;
    private bool isRButtonDown = false;
    private bool isFButtonDown = false;
    private bool isJButtonDown = false;

    public float speed = 500f;
    float moveX = 0f;
    float moveZ = 0f;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarTag"
            || other.gameObject.tag == "TrafficConeTag")
        {
            this.isEnd = true;
            this.stateText.text = "GAME OVER";

        }
        if (other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            this.stateText.text = "CLEAR!!";
        }
        if (other.gameObject.tag == "CoinTag")
        {
            GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject);
            this.score += 10;
            this.scoreText.GetComponent<Text>().text = "Score" + this.score + "pt";
        }
    }

    void Start()
    {
        this.unichanAnimator = this.GetComponent<Animator>();
        this.unichanAnimator.SetFloat("Speed", 0);

        this.unichanRigidbody = GetComponent<Rigidbody>();
        this.stateText = GameObject.Find("GameResultText").GetComponent<Text>();
        this.scoreText = GameObject.Find("ScoreText");
    }

  
    void Update()
    {

        if (this.isEnd)
        {
            this.forwardForce *= this.coefficient;
            this.turnForce *= this.coefficient;
            this.upForce *= this.coefficient;
            this.unichanAnimator.speed *= this.coefficient;
            this.forwardBoostForce *= this.coefficient;        }

        


        
        //if (Input.GetKey(KeyCode.Z) || this.isFButtonDown)
        //{
           
        //    this.unichanAnimator.SetFloat("Speed", 1);
        //    this.isFButtonDown= true;

        //    if (Input.GetKey(KeyCode.X))
        //    {
        //        this.unichanRigidbody.AddForce(this.transform.forward * this.forwardBoostForce);

        //        ///問題点１．ZとX同時押し（ダッシュ）中にジャンプができていない
        //        ///問題点２．ダッシュ中、車やコーンに触れてもGAMEOVERにならない


        //    }
        //    else
        //    {
        //        this.unichanRigidbody.AddForce(this.transform.forward * this.forwardForce);

        //    }
        //}
        //if (Input.GetKeyUp(KeyCode.Z)|| this.isFButtonDown==false)
           
           
        //{
        //    this.isFButtonDown = false;
        //    this.unichanRigidbody.AddForce(this.transform.forward * 0f);
        //    this.unichanAnimator.SetFloat("Speed", 0);
        //    //unichanRigidbody.velocity = new Vector3(moveX, this.transform.position.y, moveZ);
        //}

        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
        //   || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        //{
        //    this.unichanAnimator.SetFloat("Speed", 1);
        //}

        moveX = CrossPlatformInputManager.GetAxisRaw("Hrizontal");
        moveZ = CrossPlatformInputManager.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(moveX, this.transform.position.y, moveZ).normalized;
        unichanRigidbody.velocity = new Vector3(moveX, this.transform.position.y, moveZ);

        //moveX = Input.GetAxis("Horizontal") * speed;
        //moveZ = Input.GetAxis("Vertical") * speed;
        //Vector3 direction = new Vector3(moveX, this.transform.position.y, moveZ);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown
        //    && -this.movableRange < this.transform.position.x)
        //{
        //    this.unichanRigidbody.AddForce(-this.turnForce, 0, 0);
        //}
        //else if (Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown
        //    && this.transform.position.x < this.movableRange)
        //{
        //    this.unichanRigidbody.AddForce(this.turnForce, 0, 0);
        //}



        if (this.unichanAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.unichanAnimator.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.Space)|| this.isJButtonDown
            && this.transform.position.y < 0.5f)
        {
            Debug.Log("ジャンプ");
            this.unichanAnimator.SetBool("Jump", true);

            this.unichanRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }

    //private void FixedUpdate()
    //{
    //    unichanRigidbody.velocity = new Vector3(moveX, this.transform.position.y, moveZ);
    //}

    public void GetMyLefftButtonDown()
    {
        this.isLButtonDown = true;
    }

    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }

    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }

    public void GetMyForwardButtonDown()
    {
        this.isFButtonDown = true;
    }

    public void GetMyForwardButtonUp()
    {
        this.isFButtonDown = false;
    }

    public void GetMyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }
    public void GetMyJumpButtonUp()
    {
        this.isJButtonDown = false;
    }
}
