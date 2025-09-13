using Student_Record_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Student_Record_Manager.Services
{
    internal class StudentManager
    {
        private readonly List<Student> _students;

        public StudentManager()
        {
            _students = [];
        }

        public void AddStudent(Student student)
        {
            if (_students.Any(s => s.Id == student.Id))
                throw new Exception("Student with Same Id Already Exist");
            _students.Add(student);
        }

        public void UpdateStudent(int id, string name, int age, decimal grade)
        {
            Student? findedStudent = _students.FirstOrDefault(s => s.Id == id) ?? throw new Exception("Student Not Found");
            findedStudent.Name = name;
            findedStudent.Age = age;
            findedStudent.Grade = grade;
        }

        public void DeleteStudent(int id)
        {
            Student student = _students.FirstOrDefault(s => s.Id == id) ?? throw new Exception("Student Not Found");
            _students.Remove(student);
        }

        public void DisplayStudent(int id)
        {
            Student student = _students.FirstOrDefault(student => student.Id == id) ?? throw new Exception("Student Not Found");
            Console.WriteLine(student.ToString());
        }

        public void PrintStudents()
        {
            if (this._students.Count == 0)
            {
                Console.WriteLine("There is No Students");
                return;
            }
            Console.WriteLine($"{"ID",-5} {"Name",-15} {"Grade",8}");
            Console.WriteLine(new string('-', 32));

            foreach (var s in _students)
                Console.WriteLine($"{s.Id,-5} {s.Name,-15} {s.Grade,8:F2}");


        }
    }

}
