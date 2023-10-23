using EHLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using 언어_특성_활용하기;

namespace 언어_특성_활용하기
{

    public class CampusLife
    {
        private static readonly Lazy<CampusLife> _instance =
          new Lazy<CampusLife>(() => new CampusLife());
        public static CampusLife Instance
        {
            get { return _instance.Value; }
        }
        private CampusLife() { }


        private Campus cp;
        private Place dormitory;
        private Place lectureRoom;
        private Place library;
        private Student[] stues;

        internal Campus CP
        {
            get { return cp; }
            set { cp = value; }
        }
        internal Place DORMITORY
        {
            get { return dormitory; }
            set { dormitory = value; }
        }
        internal Place LECTUREROOM
        {

            get { return lectureRoom; }
            set { lectureRoom = value; }
        }
        internal Place LIBRARY
        {
            get { return library; }
            set { library = value; }
        }
        internal Student[] STUDENTS
        {
            get { return stues; }
            set { stues = value; }
        }

        public void Init()
        {
            Console.WriteLine("===================");
            Console.WriteLine("+++캠퍼스 라이프+++");
            Console.WriteLine("===================");


            CP = new Campus();
            DORMITORY = new Dormitory();
            LECTUREROOM = new LectureRoom();
            LIBRARY = new Library();
            CP.GenStudents(); //학생 생성
        }

        public void Run()
        {
            ConsoleKey key = ConsoleKey.NoName;
            while ((key = SelectMenu()) != ConsoleKey.Escape)
            {
                switch (key)
                {
                    //학생 이동
                    case ConsoleKey.F1: MoveStudent(); break;
                    //초점 이동
                    case ConsoleKey.F2: MoveFocus(); break;
                    //전체 정보 보기
                    case ConsoleKey.F3: AllStuInfo(); break;
                    case ConsoleKey.Escape: break;
                    default: Console.WriteLine("잘못 선택하였습니다."); break;
                }
            }
        }

        private void AllStuInfo()
        {
            Console.Clear();
            Console.WriteLine("전체 학생 정보 보기");
            foreach (Student stu in STUDENTS)
            {
                Console.WriteLine(stu.ToString());
            }
            Console.WriteLine("아무나 키나 눌러 주세요");
            Console.ReadKey(true);
        }

        private void MoveFocus()
        {
            Console.Clear();
            ConsoleKey key = ConsoleKey.NoName;
            do
            {
                key = SelectPlace("=== 포커스 이동 ===");

                switch (key)
                {
                    case ConsoleKey.F1:
                        lectureRoom.SelectDo();
                        break;
                    case ConsoleKey.F2:
                        library.SelectDo();
                        break;
                    case ConsoleKey.F3:
                        dormitory.SelectDo();
                        break;
                    default:
                        Console.WriteLine("잘못 선택하였습니다.");
                        break;
                }
            } while (key != ConsoleKey.F1 && key != ConsoleKey.F2 && key != ConsoleKey.F3);
            Console.WriteLine("아무 키나 누르세요.");
            Console.ReadKey(true);
        }

        private void MoveStudent()
        {
            Console.WriteLine("=== 학생 이동 ===");

            foreach (Student stu in STUDENTS)
            {
                Console.WriteLine(stu);
            }
            Student selectedstu = SelectStudent("이동할 학생");


            ConsoleKey key = ConsoleKey.NoName;
            do
            {
                key = SelectPlace("=== 장소 이동 ===");

                switch (key)
                {
                    case ConsoleKey.F1:
                        selectedstu.place = "강의실";
                        break;
                    case ConsoleKey.F2:
                        selectedstu.place = "도서관";
                        break;
                    case ConsoleKey.F3:
                        selectedstu.place = "기숙사";
                        break;
                    default:
                        Console.WriteLine("잘못 선택하였습니다.");
                        break;
                }
            } while (key != ConsoleKey.F1 && key != ConsoleKey.F2 && key != ConsoleKey.F3);

            Console.WriteLine($"{selectedstu.name}는 {selectedstu.place}으로 이동했습니다. ");
            Console.WriteLine("아무나 키나 눌러 주세요");
            Console.ReadKey(true);
        }

        private Student SelectStudent(string msg)
        {
            Console.WriteLine(msg);
            int num = EH.InputNum("번호:");
            if ((num > 0) && (num <= stues.Length))
            {
                return stues[num - 1];
            }
            return null;
        }
        private ConsoleKey SelectPlace(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
            Console.WriteLine("* F1: 강의실");
            Console.WriteLine("* F2: 도서관");
            Console.WriteLine("* F3: 기숙사");
            return Console.ReadKey(true).Key;
        }

        private ConsoleKey SelectMenu()
        {
            Console.Clear();
            Console.WriteLine("===    메뉴   ===");
            Console.WriteLine("* F1: 학생 이동");
            Console.WriteLine("* F2: 초점 이동");
            Console.WriteLine("* F3: 전체 정보 보기");
            Console.WriteLine("* ESC: 프로그램 종료");
            return Console.ReadKey(true).Key;
        }
    }

}
