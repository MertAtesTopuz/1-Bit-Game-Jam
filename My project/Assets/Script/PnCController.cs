using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PnCController : MonoBehaviour
{
    private Vector2 followSpot;
    [SerializeField] private float speed;
    //[SerializeField] private float perspectiveScale;
    //[SerializeField] private float scaleRatio;
    private Animator anim;
    private Vector2 stuckDistanceCheck;
    public AudioSource walk1;
    public AudioSource walk2;

    void Start()
    {
        followSpot = transform.position;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(1))
        {
            followSpot = new Vector2(mousePos.x, mousePos.y);
        }
        transform.position = Vector2.MoveTowards(transform.position, followSpot, speed * Time.deltaTime);
        // Perspective();
        UpdateAnimation();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        followSpot = transform.position;
    }

    /*
    private void Perspective()
    {
        Vector3 scale = transform.localScale;
        scale.x = perspectiveScale = (scaleRatio - transform.position.y);
        scale.y = perspectiveScale = (scaleRatio - transform.position.y);
        transform.localScale = scale;
    }
    */

    private void UpdateAnimation()
    {
        float distance = Vector2.Distance(transform.position, followSpot);
        if (Vector2.Distance(stuckDistanceCheck, transform.position) == 0)
        {
            anim.SetFloat("distance", 0f);
            return;
        }
        anim.SetFloat("distance", distance);
        if (distance > 0.01)
        {
            Vector3 direction = transform.position - new Vector3(followSpot.x, followSpot.y, transform.position.z);
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            anim.SetFloat("angle", angle);
            stuckDistanceCheck = transform.position;
        }
    }

    public void WalkSound1()
    {
        walk1.Play();
    }

    public void WalkSound2()
    {
        walk2.Play();
    }
}
