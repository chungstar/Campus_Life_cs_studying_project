using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 언어_특성_활용하기
{
    internal class LectureRoom:Place
    {
        internal LectureRoom()
        {
            Console.WriteLine("강의실 생성");
        }
        public override void SelectDo()
        {
            stues = FindStudentsInPlace("강의실");
            if (stues != null)
            {
                ConsoleKey key = ConsoleKey.NoName;
                while ((key = SelectDoMenu()) != ConsoleKey.Escape)
                {
                    switch (key)
                    {
                        case ConsoleKey.F1: StartLecture(); break;
                        case ConsoleKey.F2: SpeechSeminar(); break;
                        default: Console.WriteLine("잘못 선택하였습니다."); break;
                    }
                    Console.WriteLine("아무 키나 누르세요.");
                    Console.ReadKey(true);
                }
            }
            else
            { Console.WriteLine("강의실에는 아무도 없습니다..."); }
        }

        private void SpeechSeminar()
        {
            Console.WriteLine("+토론 수업+");
            foreach (Student stu in stues)
            {
                stu.LeadSeminar();
                if (stu is PStudent)
                {
                    stu.Sleep();
                }
            }
            Console.WriteLine("아무키나 눌러주세요");
            Console.ReadKey(true);
        }

        private void StartLecture()
        {
            Console.WriteLine("+강의 듣기+");
            foreach (Student stu in stues)
            {
                stu.ListenLecture();
            }
            Console.WriteLine("아무키나 눌러주세요");
            Console.ReadKey(true);
        }

        private ConsoleKey SelectDoMenu()
        {
            Console.Clear();
            Console.WriteLine("===    메뉴   ===");
            Console.WriteLine("* F1: 판서 강의");
            Console.WriteLine("* F2: 토론 수업");
            Console.WriteLine("* ESC: 뒤로 가기");
            return Console.ReadKey(true).Key;
        }
    }
}
