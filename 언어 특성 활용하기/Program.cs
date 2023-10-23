using System;

namespace 언어_특성_활용하기
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CampusLife campusLife = CampusLife.Instance;
            campusLife.Init();
            campusLife.Run();
        }
    }
}
