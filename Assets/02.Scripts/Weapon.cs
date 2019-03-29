//创建日期：2019/3/27
//版本：    v0.01
//说明：    记录武器内核数据

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._02.Scripts
{
    public class Weapon
    {
        private float _atk;
        private float _ats;
        private float _flyspd;
        private float _atkspd;
        public float ATK
        {
            get
            {
                return _atk;
            }
            
        }
        public float ATS    //一秒攻击的次数
        {
            get
            {
                return _ats;
            }
        }
        public float FLYSPD
        {
            get
            {
                return _flyspd;
            }
        }   

        public Weapon()
        {
            _flyspd = 10f;
            _atk = 12.0f;
            _ats = 2.0f;
            _atkspd = 2.0f;
        }
    }
}
