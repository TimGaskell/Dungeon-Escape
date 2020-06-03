using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{

    private Spider spider;

    private void Start() {

        spider = transform.parent.GetComponent<Spider>();
    }

    /// <summary>
    /// Starts the spiders acid attack from the animation event
    /// </summary>
    public void Fire() {

        spider.Attack();

    }

}
