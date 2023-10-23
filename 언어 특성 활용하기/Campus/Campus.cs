using EHLib;
using System;

namespace 언어_특성_활용하기
{
    internal class Campus
    {
        internal Campus()
        {
            Console.WriteLine("캠퍼스 생성");
        }
        public void GenStudents()
        {
            CampusLife campusLife = CampusLife.Instance;
            int num = EH.InputNum("최대 학생 수:");
            while(num <= 0)
            {
                Console.WriteLine("1보다 큰 수를 적어주세요");
                num = EH.InputNum("최대 학생 수:");
            }

            campusLife.STUDENTS = new Student[num];
            
            for (int i = 0; i < num; i++)
            {
                Console.Clear();
                Console.WriteLine("{0} 번째 학생 이름:", i + 1);
                string name = Console.ReadLine();
                ConsoleKey key;

                do
                {
                    Console.WriteLine($"{name}의 성격을 골라주세요");
                    key = SelectCharacter();

                    switch (key)
                    {
                        case ConsoleKey.F1:
                            campusLife.STUDENTS[i] = new CStudent(name);
                            break;
                        case ConsoleKey.F2:
                            campusLife.STUDENTS[i] = new MStudent(name);
                            break;
                        case ConsoleKey.F3:
                            campusLife.STUDENTS[i] = new PStudent(name);
                            break;
                        default:
                            Console.WriteLine("잘못 선택하였습니다.");
                            break;
                    }
                } while (key != ConsoleKey.F1 && key != ConsoleKey.F2 && key != ConsoleKey.F3);

                Console.WriteLine($"{name}은 성공적으로 생성되어 캠퍼스로 이동합니다...");
                Console.WriteLine("아무키나 눌러주세요");
                Console.ReadKey(true);
            }
        }

        private ConsoleKey SelectCharacter()
        {
            Console.WriteLine("====  학생 성격  ====");
            Console.WriteLine("* F1: 도전적인 학생");
            Console.WriteLine("* F2: 보수적인 학생");
            Console.WriteLine("* F3: 수동적인 학생");
            return Console.ReadKey(true).Key;
        }
        public string GetStuInfo(int index)
        {
            CampusLife campusLife = CampusLife.Instance;
            if (index >= 0)
            {
                return campusLife.STUDENTS[index].ToString();
            }

            return "해당 학생 정보 없음";
        }
    }
}