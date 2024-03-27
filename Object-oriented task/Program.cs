using System;
using System.Collections.Generic;

class Peson
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }

}

class Student : Person
{
    public string Major { get; set; }
    public Student(string name, int age, string major) : base(name, age)
    {
        Major = major;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Student - Name: {Name}, Age: {Age}, Major: {Major}");
    }
}

class Teacher : Person
{
    public string Subject { get; set; }
    public Teacher(string name, int age, string subject) : base(name, age)
    {
        Subject = subject;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Teacher - Name: {Name}, Age: {Age}, Subject: {Subject}");
    }
}

class Course
{
    public string Name { get; set; }
    public string Description { get; set; }
}

class College
{
    private List<Student> studets = new List<Student>();
    private List<Teacher> teachers = new List<Teacher>();
    private List<Course> course = new List<Course>();

    public void RegisterStudent(Student student)
    {
        students.Add(student);
    }

    public void AssignStudentToCourse(Student student, Course course)
    {
        course.EnrolledStudents.Add(student);
    }

    public void AssignTeacherToCourse(Teacher teacher, Course course)
    {
        course.Teacher = teacher;
    }
}

class Program
{
    static void Main()
    {
        College college = new College();

        Student newStudent = new Student("John Doe", 28, "Computer Science");
        college.RegisterStudent(newStudent);

        Course programmingCourse = new Course { Name = "Programming 101", Description = "Introduction to Programming" };
        college.AssignStudentToCourse(newStudent, programmingCourse);

        Teacher newTeacher = new Teacher("Prof. Seregina", 35, "Computer Science");
        college.AssignTeacherToCourse(newTeacher, programmingCourse);

        Console.WriteLine("Registered Students: ");
        foreach (var student in college.GetRegisteredStudents())
        {
            student.DisplayInfo();
        }

        Console.WriteLine("\nRegistered Teachers: ");
        foreach (var teacher in college.GetRegisteredTeachers())
        {
            teacher.DisplayInfo();
        }

        Console.WriteLine("\nAvailable Courses: ");
        foreach (var course in college.GetAvaliableCourses())
        {
            Console.WriteLine($"Course: {course.Name}, Description: {course.Description}");
        }
    }
}

