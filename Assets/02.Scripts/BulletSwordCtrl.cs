using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._02.Scripts;

public class BulletSwordCtrl : MonoBehaviour {
    public BulletCore bulletCore;

    private float launchTime;
    // Use this for initialization
    private void Awake()
    {
        bulletCore = new BulletCore();
        launchTime = Time.time;
    }

	
	// Update is called once per frame
	void Update () {
        if (Time.time - launchTime > 3)
        {
            Destroy(gameObject);
        }
	}
}
