using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 언어_특성_활용하기
{

    internal class Student
    {
        readonly int sn;
        public string name;
        public string NAME {  get; set; }

        //place
        public string place = "캠퍼스";
        public string PLACE
        {  get; set; }

        //IQ
        const int init_iq = 80;
        const int min_iq = 60;
        const int max_iq = 200;

        int iq;
        public int IQ 
        { 
            get 
            { 
                return iq; 
            }
            set
            {
                if(value<min_iq)
                {
                    value = min_iq;
                }
                if (value > max_iq)
                {
                    value = max_iq;
                }
                iq = value;
            }
        }
        //HP
        int hp;
        const int init_hp = 50;
        const int min_hp = 0;
        const int max_hp = 100;
        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                if (value < min_hp)
                {
                    value = min_hp;
                }
                if (value > max_hp)
                {
                    value = max_hp;
                }
                hp = value;
            }
        }
        //CP
        int cp;
        const int init_cp = 0;
        const int min_cp = 0;
        const int max_cp = 100;
        public int CP
        {
            get
            {
                return cp;
            }
            set
            {
                if (value < min_cp)
                {
                    value = min_cp;
                }
                if (value > max_cp)
                {
                    value = max_cp;
                }
                cp = value;
            }
        }
        static int last_sn;
        public Student(string name)
        {
            this.name = name;
            last_sn++;
            this.sn = last_sn;
            CP = init_cp;
            HP = init_hp;
            IQ = init_iq;
            PLACE = place;

        }

        public virtual void ListenLecture()
        {
            IQ += 5;
            HP -= 4;
            CP -= 1;
        }
        public void LeadSeminar()
        {
            CP += 3;
            HP -= 2;
        }
        public void ListenSeminar()
        {
            IQ += 5;
            HP -= 4;
        }
        public virtual void ReadBook()
        {
            IQ += 2;
            CP += 2;
        }
        public virtual void WatchingTV()
        {
            HP -= 2;
        }
        public virtual void Sleep()
        {
            HP += 2;
        }
        public override string ToString()
        {
            return string.Format("번호:{0} 이름:{1} 현재장소: {2}", sn, name, place);
        }
    }
}
