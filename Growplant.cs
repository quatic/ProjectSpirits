using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantGrowth : MonoBehaviour
{
    // timer will show the current state of growth in terms of time passed
    public float timer = 0f;

    // growTime is the total time needed for a plant to grow
    public float growTime = 10f;

    // maxSize represents the scale at full growth
    public float maxSize = 4f;

    public bool isMaxSize = false;

    void Start() 
    // if the plant is not at max size, it will progress towards max size
    {
        if(isMaxSize == false)
        {
            StartCoRoutine(Grow());
        }
    }

    private IEnumerator Grow()
    {
        // changes scale. Can probably adjust to grow directionally
        Vector2 minScale = transform.localScale;
        Vector2 maxScale = new Vector2(maxSize, maxSize);

        // check my logic on this do while loop before running. Dangerous conditional. I think it's fine
        do
        {
            transform.localScale = Vector3.Lerp(minScale, maxScale, timer/growTime);
            timer += Time.deltaTime;
            yield return null;
        } 
        while (timer < growTime);

        isMaxSize = true;
    }
}
