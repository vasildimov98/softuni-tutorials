namespace P03._Database_Before
{
    using System.Collections.Generic;

    public interface ICourseData
    {
        public IEnumerable<int> CourseIds();

        public IEnumerable<string> CourseNames();

        public IEnumerable<string> Search(string substring);

        public string GetCourseById(int id);
    }
}
