namespace P03._Database
{
    using P03._Database_Before;

    public class CoursesConstructor
    {
        private readonly ICourseData database;

        public CoursesConstructor(ICourseData database)
        {
            this.database = database;
        }

        public void PrintAll()
        {
            var courses = this.database.CourseNames();

            //print courses
        }

        public void PrintIds()
        {
            var courseIds = this.database.CourseIds();

            //print course ids
        }

        public void PrintById(int id)
        {
            var course = this.database.GetCourseById(id);

            // print course
        }

        public void Search(string substring)
        {
            var courses = this.database.Search(substring);

            // print courses
        }
    }
}
