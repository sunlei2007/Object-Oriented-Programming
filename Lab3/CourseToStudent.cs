using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class CourseToStudent
    {
        private int _RelationID;
        // readonly -- only define at start
        public int RelationID { get { return _RelationID; } }
        private void SetID(int id)
        {
            if (id > 99)
            {
                _RelationID = id;
            }
            else
            {
                throw new Exception("Course ID should be number greater than 100");
            }
        }

        public Course Course { get; set; }
        public Student Student { get; set; }

        private int? _courseGrade;
        public int? CourseGrade { get { return _courseGrade; } }
        public void SetCourseGrade(int grade)
        {
            if (Course == null)
            {
                throw new Exception("Student not enrolled in any course.");
            }
            else if (grade < 0 || grade > 100)
            {
                throw new Exception("Grade must be between 0 and 100)");
            }
            else
            {
                _courseGrade = grade;
            };
        }
        public void RemoveGrade()
        {
            _courseGrade = null;
        }

        private DateTime? _dateRegistered;
        public DateTime? DateRegistered
        {
            get { return _dateRegistered; }
            set { _dateRegistered = value; }
        }


        public CourseToStudent(int id,Course course,Student student,DateTime regDatetime)
        {
            SetID(id);
            Course= course;
            Student= student;
            DateRegistered= regDatetime;
        }

    }
}
