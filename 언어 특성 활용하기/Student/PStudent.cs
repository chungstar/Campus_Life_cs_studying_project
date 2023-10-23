using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 언어_특성_활용하기
{
    internal class PStudent:Student
    {
        public PStudent(string name) : base(name)
        {
        }
        public override void Sleep()
        {
            Console.WriteLine($"{this} 잠꼬대를 한다 음냐링~");
            base.Sleep();
            HP -= 1;
            IQ += 1;
        }

    }
}
