//创建日期：2019/3/27
//版本：    v0.01
//说明：    记录发射的飞剑内核数据（可追踪所属武器）

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._02.Scripts
{
    [Serializable]
    public class BulletCore
    {
        public Weapon belongWeapon;
        public myVector3 position;
        public myVector3 velocity;

        public BulletCore()
        {
            belongWeapon = new Weapon();
        }
    }
}
