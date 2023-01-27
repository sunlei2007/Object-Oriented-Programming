using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Course
    {
        private int _courseId;
        // readonly -- only define at start
        public int CourseId { get { return _courseId; } }
        private void _setCourseId(int courseId)
        {
            if (courseId > 99)
            {
                _courseId = courseId;
            }
            else
            {
                throw new Exception("Course ID should be number greater than 100");
            }
        }


        private string _title;
        public string Title { get { return _title; } }
        private void _setTitle(string title)
        {
            if (title.Length > 2)
            {
                _title = title;
            }
            else
            {
                throw new Exception("Title should be three or more characters.");
            }
        }


        private int _capacity;
        public int Capacity { get { return _capacity; } }
        private void _setCapacity(int capacity)
        {
            if (capacity > 0)
            {
                _capacity = capacity;
            }
            else
            {
                throw new Exception("Capacity must be greater than zero.");
            }
        }

        public Course(int courseId, string title, int capacity)
        {
            _setCourseId(courseId);
            _setTitle(title);
            _setCapacity(capacity);
        }
    }
}