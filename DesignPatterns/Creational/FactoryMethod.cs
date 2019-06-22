using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational
{
    public class FactoryMethod
    {
        public static Person CreatePerson(string typeName)
        {
            if (typeName == nameof(Student))
            {
                var s = new Student("Will", "Li", "ABC High School", 3, 1);

                return s;
            }
            else if (typeName == nameof(Teacher))
            {
                var t = new Teacher("Joyce", "Zhang", "ABC High School", "English");
                t.AssignClass(3, 1);
                t.AssignClass(3, 2);

                return t;
            }

            throw new NotSupportedException(typeName);
        }
    }

    public abstract class Person
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }

    public class Student : Person
    {
        public Student(string firstName, string lastName, string school, int grade, int classs)
            :base(firstName, lastName)
        {
            this.School = school;
            this.Grade = grade;
            this.Class = classs;
        }

        public string School { get; private set; }

        public int Grade { get; private set; }

        public int Class { get; private set; }

        public void TakeExam(string exam)
        {

        }
    }

    public class Teacher : Person
    {
        private readonly List<ValueTuple<int, int>> _gradeClass;

        public Teacher(string firstName, string lastName, string school, string subject)
            : base(firstName, lastName)
        {
            this.School = school;
            this.Subject = subject;
            this._gradeClass = new List<(int, int)>(1);
        }

        public string School { get; private set; }

        public string Subject { get; private set; }

        public IReadOnlyList<ValueTuple<int, int>> GradeClass { get { return this._gradeClass.AsReadOnly(); } }

        public void AssignClass(int grade, int classs)
        {
            this._gradeClass.Add((grade, classs));
        }
    }

    public abstract class PersonFactory
    {
        public abstract Person CreatePerson();
    }

    public class StudentFactory : PersonFactory
    {
        public override Person CreatePerson()
        {
            return new Student("will", "li", "ABC High School", 3, 1);
        }
    }

    public class TeacherFactory : PersonFactory
    {
        public override Person CreatePerson()
        {
            return new Teacher("joyce", "zhao", "ABC High School", "English");
        }
    }
}
