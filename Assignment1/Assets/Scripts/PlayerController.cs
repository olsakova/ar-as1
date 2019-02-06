using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;

    Transform player;
    Transform target1;
    Transform target2;
    Animation anim;
    public bool firstTarget = false;
    public bool secondTarget = false;
    public bool spinning = false;

    // Time when the movement started.
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        anim = GetComponent<Animation>();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    anim.Play("Spin");
    //}

    void OnTriggerEnter(Collider col)
    {
        spinning = true;
    }


    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        float step = speed * Time.deltaTime; // calculate distance to move
        if (!firstTarget)
        {
            target1 = GameObject.FindGameObjectWithTag("target1").transform;

            Vector3 targetDir = target1.position - player.position;
            Vector3 newDir = Vector3.RotateTowards(player.forward, targetDir, step, 0.0f);
            player.rotation = Quaternion.LookRotation(newDir);
            player.position = Vector3.MoveTowards(player.position, target1.position, step);
            if (Vector3.Distance(player.position, target1.position) < 0.01f)
            {
                firstTarget = true;
            }
        }
        else if (!secondTarget)
        {
            target2 = GameObject.FindGameObjectWithTag("target2").transform;

            Vector3 targetDir2 = target2.position - player.position;
            Vector3 newDir2 = Vector3.RotateTowards(player.forward, targetDir2, step, 0.0f);
            player.rotation = Quaternion.LookRotation(newDir2);
            player.position = Vector3.MoveTowards(player.position, target2.position, step);
            if (Vector3.Distance(player.position, target2.position) < 0.01f)
            {
                secondTarget = true;
            }
        }
        else if (spinning){
            anim.Play("Spin");
        }

    }
}
