using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 언어_특성_활용하기
{
    internal class CStudent: Student
    {
        public CStudent(string name) : base(name)
        {
        }
        public override void ReadBook()
        {
            base.ReadBook();
            CP += 1;
        }
        public override void ListenLecture()
        {
            base.ListenLecture();
            IQ += 1;
            CP += 1;
        }
    }
}
