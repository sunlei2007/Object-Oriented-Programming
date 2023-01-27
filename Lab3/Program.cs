using Lab3;
using System.Linq.Expressions;

//Create courses
Course softwareDevelop = new Course(101, "Software develop", 20);
Course webDesign = new Course(102, "Web design", 20);

//Create students
Student s1 = new Student(1,"Jim","A");
Student s2 = new Student(2, "Jim", "B");
Student s3 = new Student(3, "Jim", "C");
Student s4 = new Student(4, "Jim", "D");
Student s5 = new Student(5, "Jim", "E");


//Create course and student relational
List<CourseToStudent> lstRelation = new List<CourseToStudent>();

//Add course and student
RegStudent(softwareDevelop,s1);
RegStudent(softwareDevelop, s2);
RegStudent(softwareDevelop, s3);
RegStudent(softwareDevelop, s4);
RegStudent(softwareDevelop, s5);

RegStudent(webDesign, s1);
RegStudent(webDesign, s2);
RegStudent(webDesign, s3);
RegStudent(webDesign, s4);
RegStudent(webDesign, s5);

//Remove course and student
DeRegStudent(softwareDevelop, s3);
DeRegStudent(webDesign,s4);

void RegStudent(Course course,Student student)
{
    bool isAdded = false;
   foreach(var item in lstRelation)
    {
        if(item.Course.CourseId== course.CourseId && item.Student.StudentId == student.StudentId)
        {
            isAdded = true;
        }
    }
    if (!isAdded)
    {
        if(GetCourseCount(course)<course.Capacity)
          lstRelation.Add(new CourseToStudent(1000+lstRelation.Count+1, course, student, DateTime.Now));
    }
}

void DeRegStudent(Course course, Student student)
{
    foreach (var item in lstRelation)
    {
        if (item.Course.CourseId == course.CourseId && item.Student.StudentId == student.StudentId)
        {
            lstRelation.Remove(item);
            break;
        }
    }
}

int GetCourseCount(Course course)
{
    int count=1;
    foreach (var item in lstRelation)
    {
        if (item.Course.CourseId == course.CourseId)
        {
            count++;
        }
    }
    return count;
}



