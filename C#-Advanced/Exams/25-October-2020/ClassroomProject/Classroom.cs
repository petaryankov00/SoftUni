using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }
        public int Capacity { get; set; }

        public int Count { get => this.students.Count; }


        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student studentToBeRemoved = students.FirstOrDefault(f => f.FirstName == firstName && f.LastName == lastName);
            if (studentToBeRemoved == null)
            {
                return "Student not found";
            }
            else
            {
                students.Remove(studentToBeRemoved);
                return $"Dismissed student {firstName} {lastName}";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            if (!this.students.Exists(s => s.Subject == subject))
            {
                return "No students enrolled for the subject";
            }
            else
            {
                StringBuilder result = new StringBuilder();
                result.AppendLine($"Subject: {subject}");
                result.AppendLine($"Students:");
                foreach (var student in students)
                {
                    if (student.Subject == subject)
                    {
                        result.AppendLine($"{student.FirstName} {student.LastName}");
                    }
                }

                return result.ToString().Trim();
            }
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student searchedStudent = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return searchedStudent;
        }
    }
}

