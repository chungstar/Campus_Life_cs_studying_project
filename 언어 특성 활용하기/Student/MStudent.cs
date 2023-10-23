using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 언어_특성_활용하기
{
    internal class MStudent:Student
    {
        public MStudent(string name) : base(name)
        {
        }
        public override void WatchingTV()
        {
            base.WatchingTV();
            HP -= 1;
        }
    }
}
