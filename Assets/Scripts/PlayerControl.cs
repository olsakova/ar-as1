using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    private GameObject rocks = GameObject.FindWithTag("rocktarget");

    Transform target1;
    Transform target2;
    UnityEngine.AI.NavMeshAgent nav;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        target1 = GameObject.FindGameObjectWithTag("target1").transform;
        target2 = GameObject.FindGameObjectWithTag("target2").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        nav.SetDestination(target1.position);
        nav.SetDestination(target2.position);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
}
