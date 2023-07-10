using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimationEnd : MonoBehaviour
{
    public float delay = 0f;

    private void Start()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length + delay);
    }
}
