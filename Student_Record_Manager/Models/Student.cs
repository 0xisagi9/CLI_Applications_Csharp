using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Student_Record_Manager.Models
{
    internal class Student
    {
        private int _id;
        private string _name = string.Empty;
        private decimal _grade;
        public int Id
        {
            get => this._id; set
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                this._id = value;
            }
        }
        public string Name
        {
            get => this._name; set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(value);
                this._name = value;
            }
        }
        public int Age { get; set; }
        public decimal Grade
        {
            get => this._grade; set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(value.ToString());
                this._grade = value;
            }
        }

        public Student(int id, string name, int age, decimal grade)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }
        public override string ToString()
        {
            return $"[ID: {this._id}]  Name: {this._name,-12} | Age: {this.Age,2} | Grade: {this._grade,6:F2}";
        }
    }
}
