using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed;
    public Transform pointA, pointB;
    private Vector3 currentTarget;
    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        sr  = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            sr.flipX = false;
            Debug.Log("Yendo a Punto B.");
        }
        else if(transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            sr.flipX = true;
            Debug.Log("Yendo a Punto A.");
        }




        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);


    }
}
