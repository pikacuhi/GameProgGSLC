using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 2f;
    public float directionChangeInterval = 3f;
    public float boundaryRadius = 5f;

    private Vector3 movement;
    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
        StartCoroutine(ChangeMovementDirection());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        //keep annoyance at boundary
        Vector3 distanceFromStart = transform.position - startingPosition;
        if (distanceFromStart.magnitude > boundaryRadius)
        {
            Vector3 fromOriginToObject = transform.position - startingPosition;
            fromOriginToObject *= boundaryRadius / fromOriginToObject.magnitude;
            transform.position = startingPosition + fromOriginToObject;
        }
    }
    System.Collections.IEnumerator ChangeMovementDirection()
    {
        while (true)
        {
            float angle = Random.Range(0f, 360f);
            movement = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

}
