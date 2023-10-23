using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 언어_특성_활용하기
{
    internal class Place
    {
        protected Student[] stues = null;

        public virtual void SelectDo()
        {
            //아마 select는 상속받은 장소에서만 할듯?
            Console.WriteLine("여기는 아무것도 할 수 없는 장소입니다.");
        }
        public Student[] FindStudentsInPlace(string place)
        {
            CampusLife cp = CampusLife.Instance;
            Student[] stues = cp.STUDENTS;
            List<Student> studentsInPlace = new List<Student>();

            foreach (Student student in stues)
            {
                if (student != null && student.place == place)
                {
                    studentsInPlace.Add(student);
                }
            }

            if (studentsInPlace.Count > 0)
            {
                return studentsInPlace.ToArray();
            }
            else
            {
                Console.WriteLine("현재 해당 장소에 학생이 없습니다.");
                return null;
            }
        }

    }
}
