using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        anim.SetBool("BridgeOpen", true);
        anim.SetBool("BridgeOpen2", false);
    }

    public void Close()
    {
        anim.SetBool("BridgeOpen", false);
        anim.SetBool("BridgeOpen2", true);
    }
}
