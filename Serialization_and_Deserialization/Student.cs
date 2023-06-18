using System;

namespace Serialization_and_Deserialization
{
    [Serializable]
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Course { get; set; }
        int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Student(string FirstName, string LastName, int Age, int Course, int score) 
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Course = Course;
            this.score = score;
        }
        public Student() { }
    }
}
