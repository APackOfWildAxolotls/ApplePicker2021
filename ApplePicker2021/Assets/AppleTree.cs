using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //prfab for instanioating apples
    public GameObject applePrefab;
    //apple speed
    public float speed = 1f;
    //distance before apple tree floats
    public float leftandRightEdge = 10f;
    //treechance to change Directions
    public float ChanceToChangeDirection = 0.1f;
    //apple create rate
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //dropping apples every seccond
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;


        //changing direction
        if (pos.x < -leftandRightEdge)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftandRightEdge)
        {
            speed = -Mathf.Abs(speed);
        } 

    }

    private void FixedUpdate()
    {
        if (Random.value < ChanceToChangeDirection)
        {
            speed *= -1;
        }
    }


}
