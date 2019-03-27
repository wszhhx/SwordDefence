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
        public float ATK
        {
            get
            {
                return _atk;
            }
            
        }
        public float ATS
        {
            get
            {
                return ATS;
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
        }
    }
}
