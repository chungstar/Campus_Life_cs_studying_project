﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 언어_특성_활용하기
{
    internal class Dormitory : Place
    {
        internal Dormitory()
        {
            Console.WriteLine("기숙사 생성");
        }
        public override void SelectDo()
        {
            stues = FindStudentsInPlace("기숙사");
            if (stues != null)
            {
                ConsoleKey key = ConsoleKey.NoName;
                while ((key = SelectDoMenu()) != ConsoleKey.Escape)
                {
                    switch (key)
                    {
                        case ConsoleKey.F1: TurnOnTV(); break;
                        case ConsoleKey.F2: GoBed(); break;
                        default: Console.WriteLine("잘못 선택하였습니다."); break;
                    }
                    Console.WriteLine("아무 키나 누르세요.");
                    Console.ReadKey(true);
                }
            }
            else
            { Console.WriteLine("기숙사에는 아무도 없습니다..."); }
        }

        private void GoBed()
        {
            Console.WriteLine("+잠자기+");
            foreach (Student stu in stues)
            {
                Console.WriteLine(stu);
                stu.Sleep();
            }

            
        }

        private void TurnOnTV()
        {
            Console.WriteLine("+TV 시청+");
            Console.WriteLine("책을 읽을 학생 번호를 입력하세요 (쉼표로 구분하여 여러 개 입력 가능):");
            string input = Console.ReadLine();
            string[] indexes = input.Split(',');

            List<int> studentIndexes = new List<int>();//책을 읽을 학생의 인덱스 저장하는 리스트
            foreach (string index in indexes)
            {
                if (int.TryParse(index, out int studentIndex))
                {
                    studentIndexes.Add(studentIndex);
                }
            }

            foreach (int index in studentIndexes)
            {
                if (index > 0)
                {
                    Student selectedStudent = stues[index - 1];
                    selectedStudent.WatchingTV();
                }
                else
                {
                    // 인덱스가 유효하지 않은 경우에 대한 처리
                    Console.WriteLine("유효하지 않은 학생 번호: " + (index - 1));
                }
            }
        }

        private ConsoleKey SelectDoMenu()
        {
            Console.Clear();
            Console.WriteLine("===    메뉴   ===");
            Console.WriteLine("* F1: TV 틀기");
            Console.WriteLine("* F2: 잠자기");
            Console.WriteLine("* ESC: 뒤로 가기");
            return Console.ReadKey(true).Key;
        }
    }
}
