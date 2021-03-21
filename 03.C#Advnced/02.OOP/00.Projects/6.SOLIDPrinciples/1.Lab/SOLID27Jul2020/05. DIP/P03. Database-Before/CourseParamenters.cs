namespace P03._Database_Before
{
    public class CourseParamenters
    {
        public void PrintAll(ICourseData database)
        {
            var courses = database.CourseNames();

            //print courses
        }

        public void PrintIds(ICourseData database)
        {
            var courseIds = database.CourseIds();

            //print course ids
        }

        public void PrintById(int id, ICourseData database)
        {
            var course = database.GetCourseById(id);

            // print course
        }

        public void Search(string substring, ICourseData database)
        {
            var courses = database.Search(substring);

            // print courses
        }
    }
}
