namespace UniversityManagement
{
    class Student
    {
        public int StudentId;
        public string Name;
        public int Age;
        public List<Course> Courses;

        public Student(int studentId, string name, int age, List<Course> courses)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.Age = age;
            this.Courses = courses;
        }

        public bool Enroll(Course course)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == course.CourseId)
                {
                    return false;
                }
            }

            Courses.Add(course);
            return true;
        }

        public bool IsEnrolledInCourse(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId)
                {
                    return true;
                }
            }

            return false;
        }

        public string PrintDetails()
        {
            string details = "ID: " + StudentId +
                " | Name: " + Name +
                " | Age: " + Age;

            if (Courses.Count == 0)
            {
                details = details + " | Courses: None";
            }
            else
            {
                details = details + " | Courses:";

                for (int i = 0; i < Courses.Count; i++)
                {
                    details = details + " " + Courses[i].Title;
                }
            }

            return details;
        }
    }

    class Instructor
    {
        public int InstructorId;
        public string Name;
        public string Specialization;

        public Instructor(int instructorId, string name, string specialization)
        {
            this.InstructorId = instructorId;
            this.Name = name;
            this.Specialization = specialization;
        }

        public string PrintDetails()
        {
            return "ID: " + InstructorId +
                " | Name: " + Name +
                " | Specialization: " + Specialization;
        }
    }

    class Course
    {
        public int CourseId;
        public string Title;
        public Instructor Instructor;

        public Course(int courseId, string title, Instructor instructor)
        {
            this.CourseId = courseId;
            this.Title = title;
            this.Instructor = instructor;
        }

        public string PrintDetails()
        {
            return "ID: " + CourseId +
                " | Title: " + Title +
                " | Instructor: " + Instructor.Name;
        }
    }

    class StudentManagement
    {
        List<Student> Students;
        List<Course> Courses;
        List<Instructor> Instructors;

        public StudentManagement(
            List<Student> students,
            List<Course> courses,
            List<Instructor> instructors)
        {
            this.Students = students;
            this.Courses = courses;
            this.Instructors = instructors;
        }

        public bool AddStudent(Student student1)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == student1.StudentId)
                {
                    return false;
                }
            }

            Students.Add(student1);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructor.InstructorId)
                {
                    return false;
                }
            }

            Instructors.Add(instructor);
            return true;
        }

        public bool AddCourse(Course course)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == course.CourseId)
                {
                    return false;
                }
            }

            Courses.Add(course);
            return true;
        }

        public Student FindStudent(int studentId)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == studentId)
                {
                    return Students[i];
                }
            }

            return null;
        }

        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId)
                {
                    return Courses[i];
                }
            }

            return null;
        }

        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructorId)
                {
                    return Instructors[i];
                }
            }

            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);

            if (student == null || course == null)
            {
                return false;
            }

            return student.Enroll(course);
        }

        public void ShowAllStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            for (int i = 0; i < Students.Count; i++)
            {
                Console.WriteLine(Students[i].PrintDetails());
            }
        }

        public void ShowAllCourses()
        {
            if (Courses.Count == 0)
            {
                Console.WriteLine("No courses found.");
                return;
            }

            for (int i = 0; i < Courses.Count; i++)
            {
                Console.WriteLine(Courses[i].PrintDetails());
            }
        }

        public void ShowAllInstructors()
        {
            if (Instructors.Count == 0)
            {
                Console.WriteLine("No instructors found.");
                return;
            }

            for (int i = 0; i < Instructors.Count; i++)
            {
                Console.WriteLine(Instructors[i].PrintDetails());
            }
        }

        public void SearchStudentsByName(string name)
        {
            bool found = false;

            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].Name == name)
                {
                    Console.WriteLine(Students[i].PrintDetails());
                    found = true;
                }
            }

            if (found == false)
            {
                Console.WriteLine("No student with this name.");
            }
        }

        public void SearchCoursesByTitle(string title)
        {
            bool found = false;

            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].Title == title)
                {
                    Console.WriteLine(Courses[i].PrintDetails());
                    found = true;
                }
            }

            if (found == false)
            {
                Console.WriteLine("No course with this title.");
            }
        }

        public void ShowInstructorByCourseTitle(string title)
        {
            bool found = false;

            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].Title == title)
                {
                    Console.WriteLine(
                        "Course ID: " + Courses[i].CourseId +
                        " | Instructor: " + Courses[i].Instructor.Name);

                    found = true;
                }
            }

            if (found == false)
            {
                Console.WriteLine("No course with this title.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();
            List<Instructor> instructors = new List<Instructor>();

            StudentManagement studentManagement =
                new StudentManagement(students, courses, instructors);

            int choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("University Management");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Add instructor");
                Console.WriteLine("3. Add course");
                Console.WriteLine("4. Enroll student in course");
                Console.WriteLine("5. Show all students");
                Console.WriteLine("6. Show all courses");
                Console.WriteLine("7. Show all instructors");
                Console.WriteLine("8. Find student by ID or name");
                Console.WriteLine("9. Find course by ID or name");
                Console.WriteLine("10. Exit");
                Console.WriteLine("Bonus:");
                Console.WriteLine("11. Check student enrollment");
                Console.WriteLine("12. Find instructor by course name");

                Console.Write("Choose: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Student ID: ");
                    int addid = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Student name: ");
                    string addname = Console.ReadLine();

                    Console.Write("Student age: ");
                    int addage = Convert.ToInt32(Console.ReadLine());

                    if (addid <= 0 || addname == "" || addage <= 0)
                    {
                        Console.WriteLine(
                            "Use a positive ID and age, and a non-empty name.");
                    }
                    else
                    {
                        Student student1 = new Student(
                            addid, addname, addage, new List<Course>());

                        bool added = studentManagement.AddStudent(student1);

                        if (added)
                        {
                            Console.WriteLine("Student added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Student ID already exists.");
                        }
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Instructor ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Instructor name: ");
                    string name = Console.ReadLine();

                    Console.Write("Specialization: ");
                    string specialization = Console.ReadLine();

                    if (id <= 0 || name == "" || specialization == "")
                    {
                        Console.WriteLine(
                            "Use a positive ID and non-empty text.");
                    }
                    else
                    {
                        Instructor instructor =
                            new Instructor(id, name, specialization);

                        if (studentManagement.AddInstructor(instructor))
                        {
                            Console.WriteLine("Instructor added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Instructor ID already exists.");
                        }
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Course ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Course title: ");
                    string title = Console.ReadLine();

                    Console.Write("Instructor ID: ");
                    int instructorId = Convert.ToInt32(Console.ReadLine());

                    Instructor instructor =
                        studentManagement.FindInstructor(instructorId);

                    if (id <= 0 || title == "")
                    {
                        Console.WriteLine(
                            "Use a positive ID and a non-empty title.");
                    }
                    else if (instructor == null)
                    {
                        Console.WriteLine(
                            "Instructor not found. Add the instructor first.");
                    }
                    else
                    {
                        Course course = new Course(id, title, instructor);

                        if (studentManagement.AddCourse(course))
                        {
                            Console.WriteLine("Course added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Course ID already exists.");
                        }
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Student ID: ");
                    int studentId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Course ID: ");
                    int courseId = Convert.ToInt32(Console.ReadLine());

                    Student student =
                        studentManagement.FindStudent(studentId);

                    Course course =
                        studentManagement.FindCourse(courseId);

                    if (student == null)
                    {
                        Console.WriteLine("Student not found.");
                    }
                    else if (course == null)
                    {
                        Console.WriteLine("Course not found.");
                    }
                    else if (
                        studentManagement.EnrollStudentInCourse(
                            studentId, courseId))
                    {
                        Console.WriteLine("Student enrolled successfully.");
                    }
                    else
                    {
                        Console.WriteLine(
                            "Student is already enrolled in this course.");
                    }
                }
                else if (choice == 5)
                {
                    studentManagement.ShowAllStudents();
                }
                else if (choice == 6)
                {
                    studentManagement.ShowAllCourses();
                }
                else if (choice == 7)
                {
                    studentManagement.ShowAllInstructors();
                }
                else if (choice == 8)
                {
                    Console.WriteLine("1. Search by ID");
                    Console.WriteLine("2. Search by name");
                    Console.Write("Choose search type: ");
                    int searchChoice = Convert.ToInt32(Console.ReadLine());

                    if (searchChoice == 1)
                    {
                        Console.Write("Student ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Student student = studentManagement.FindStudent(id);

                        if (student == null)
                        {
                            Console.WriteLine("Student not found.");
                        }
                        else
                        {
                            Console.WriteLine(student.PrintDetails());
                        }
                    }
                    else if (searchChoice == 2)
                    {
                        Console.Write("Student name: ");
                        string name = Console.ReadLine();

                        studentManagement.SearchStudentsByName(name);
                    }
                    else
                    {
                        Console.WriteLine("Invalid search choice.");
                    }
                }
                else if (choice == 9)
                {
                    Console.WriteLine("1. Search by ID");
                    Console.WriteLine("2. Search by name");
                    Console.Write("Choose search type: ");
                    int searchChoice = Convert.ToInt32(Console.ReadLine());

                    if (searchChoice == 1)
                    {
                        Console.Write("Course ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Course course = studentManagement.FindCourse(id);

                        if (course == null)
                        {
                            Console.WriteLine("Course not found.");
                        }
                        else
                        {
                            Console.WriteLine(course.PrintDetails());
                        }
                    }
                    else if (searchChoice == 2)
                    {
                        Console.Write("Course name: ");
                        string title = Console.ReadLine();

                        studentManagement.SearchCoursesByTitle(title);
                    }
                    else
                    {
                        Console.WriteLine("Invalid search choice.");
                    }
                }
                else if (choice == 10)
                {
                    Console.WriteLine("Goodbye.");
                }
                else if (choice == 11)
                {
                    Console.Write("Student ID: ");
                    int studentId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Course ID: ");
                    int courseId = Convert.ToInt32(Console.ReadLine());

                    Student student =
                        studentManagement.FindStudent(studentId);

                    Course course =
                        studentManagement.FindCourse(courseId);

                    if (student == null)
                    {
                        Console.WriteLine("Student not found.");
                    }
                    else if (course == null)
                    {
                        Console.WriteLine("Course not found.");
                    }
                    else if (student.IsEnrolledInCourse(courseId))
                    {
                        Console.WriteLine(
                            "Student is enrolled in this course.");
                    }
                    else
                    {
                        Console.WriteLine(
                            "Student is not enrolled in this course.");
                    }
                }
                else if (choice == 12)
                {
                    Console.Write("Course name: ");
                    string title = Console.ReadLine();

                    studentManagement.ShowInstructorByCourseTitle(title);
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
            while (choice != 10);
        }
    }
}