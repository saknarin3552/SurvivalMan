using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    private Animator _animator;

    private CharacterController _characterController;

    public float Speed = 5.0f;

    public float RotationSpeed = 240.0f;

    private float Gravity = 20.0f;

    Rigidbody rd;

    private Vector3 _moveDir = Vector3.zero;

    public GameObject axe;
    public bool showAxe = false;
    public bool isAttack = false;
    public static PlayerCon instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        rd = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (v < 0)
            v = 0;

        transform.Rotate(0, h * RotationSpeed * Time.deltaTime, 0);

        if(_characterController.isGrounded)
        {
            bool move = (v > 0) || (h != 0);

            _animator.SetBool("run", move);

            _moveDir = Vector3.forward * v;

            _moveDir = transform.TransformDirection(_moveDir);
            _moveDir *= Speed;
        }
        if(Input.GetMouseButtonDown(0) && PlayerCon.instance.showAxe)
        {
            _animator.SetTrigger("Attack");
            PlayerCon.instance.isAttack = true;
        }
        if (Input.GetMouseButtonDown(0) && PlayerCon.instance.showAxe)
        {
            PlayerCon.instance.isAttack = false;
        }

        _moveDir.y -= Gravity * Time.deltaTime;

        _characterController.Move(_moveDir * Time.deltaTime);
    }

    public void ShowAxe()
    {
        axe.SetActive(true);
        showAxe = true;
    }


}
