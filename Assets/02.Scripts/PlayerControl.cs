//创建日期：2019/3/27
//修改日期：2019/3/27
//版本：    v0.01
//说明：    控制角色的行为



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._02.Scripts;

public class PlayerControl : MonoBehaviour {
    public PlayerCore playerCore;

    public GameObject bulletSword;

    public float atn = 10;
    public float hit = 0.6f;
    public float spd = 8f;
    public int mp = 20;
    private float preShootTime = 0f;

    private Vector2 moveDir;
    private Vector3 mouseWorldPos;

    private Rigidbody2D rigidbody;

    // Use this for initialization
    private void Awake()
    {
        playerCore = new PlayerCore(spd, mp, atn, hit);
        playerCore.equipedWeapon = new Weapon();
        moveDir = Vector2.zero;
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        if (moveDir.x < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;
        rigidbody.velocity = playerCore.SPD * moveDir;

        if (Input.GetButton("Fire1") && (Time.time - preShootTime) > (1 / playerCore.equipedWeapon.ATS))
        {
            preShootTime = Time.time;
            GameObject bullet = Instantiate(bulletSword,transform.position,new Quaternion());
            mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0.0f;
            bullet.transform.LookAt(mouseWorldPos,Vector3.up);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.GetComponent<BulletSwordCtrl>().bulletCore.belongWeapon.FLYSPD * bullet.transform.forward;
        }


	}

    void SynchronizeCore()
    {
        playerCore.ATN = atn;
        playerCore.HIT = hit;
        playerCore.MP = mp;
        playerCore.SPD = spd;
    }

    
}
