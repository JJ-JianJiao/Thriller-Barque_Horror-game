using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float vInput, hInput, movementSpeed, rotationSpeed;

    public Camera cam;
    [SerializeField]
    private float mouseXInput, mouseYInput;

    [SerializeField]
    private Animator moveAnim;

    private float xAngle;
    private float yAngle;

    //private bool isFire;
    //private float timeStamp;
    //private float fireRate;

    private bool isJump;
    private bool needFallAudio;
    private bool isGround;

    internal bool isWeaponed;

    private bool isWalk;
    // Start is called before the first frame update
    void Start()
    {
        isWalk = false;
        isWeaponed = false;
        //fireRate = 0.5f;
        //timeStamp = 0f;
        movementSpeed = 3.0f;
        rotationSpeed = 100.0f;
        //isFire = false;
        isGround = true;
        needFallAudio = false;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerSoundsManager.instance!=null && !PlayerSoundsManager.instance.IsBGMPlaying() && Time.timeScale!=0)
            PlayerSoundsManager.instance.PlayBGM();
        GetInput();
    }

    private void FixedUpdate()
    {
        Movement();
        CamControl();
        Jump();
        Animation();
    }

    private void Animation()
    {
        if (isWalk)
        {
            moveAnim.SetBool("Walk", true);
        }
        else {
            moveAnim.SetBool("Walk", false);
        }
    }

    void GetInput() {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        mouseXInput = Input.GetAxis("Mouse X");
        mouseYInput = Input.GetAxis("Mouse Y");

        //if (Input.GetAxis("Fire1") != 0 && Time.time > timeStamp + fireRate && isWeaponed) {
        //    //isFire = true;
        //    timeStamp = Time.time;
        //}

        if (Input.GetAxis("Jump") != 0 && isGround ) {
            isJump = true;
            isGround = false;
        }
    }

    void Movement() {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * movementSpeed * vInput);
        transform.Rotate(Vector3.up * Time.fixedDeltaTime * rotationSpeed * hInput);
        if (Mathf.Abs(vInput) >0.9f && isGround)
        {
            PlayerSoundsManager.instance.Run();
        }
        float xAngle = rotationSpeed * Time.fixedDeltaTime * mouseYInput;
        float yAngle = rotationSpeed * Time.fixedDeltaTime * mouseXInput;
        if (Math.Abs(vInput) < 0.2f)
        {
            isWalk = false;
        }
        else {
            isWalk = true;
        }
    }

    void Jump() {

        if (isJump) {
            isJump = false;
            needFallAudio = true;
            PlayerSoundsManager.instance.Jump();
            gameObject.transform.GetComponent<Rigidbody>().velocity = transform.up * Time.fixedDeltaTime * 200f;
        }
    }

    void CamControl() {
        cam.transform.Rotate(-rotationSpeed * Time.fixedDeltaTime * mouseYInput, 0, 0);
        Vector3 camAngle = cam.transform.localEulerAngles;
        if (camAngle.z != 0) {
            cam.transform.localEulerAngles = new Vector3(camAngle.x, camAngle.y, 0);
        }
        if (camAngle.x > 30 && camAngle.x < 90)
        {
            cam.transform.localEulerAngles = new Vector3(30.0f, camAngle.y, 0);
        }
        else if (camAngle.x < 330 && camAngle.x > 270)
        {
            cam.transform.localEulerAngles = new Vector3(330.0f, camAngle.y, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground")) {
            StartCoroutine("PlayFallClip");
        }
    }

    IEnumerator PlayFallClip() {
        //if(gameObject.GetComponent<Rigidbody>().velocity.y != 0)
        if (needFallAudio)
        {
            PlayerSoundsManager.instance.Fall();
            needFallAudio = false;
        }
        yield return new WaitForSeconds(0.481f);
        isGround = true;
    }

}
