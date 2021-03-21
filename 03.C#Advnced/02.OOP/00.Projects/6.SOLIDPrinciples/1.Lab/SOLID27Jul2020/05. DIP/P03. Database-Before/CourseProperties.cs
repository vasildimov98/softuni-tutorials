namespace P03._Database_Before
{
    public class CourseProperties
    {
        public ICourseData Database { get; set; }

        public void PrintAll()
        {
            var courses = this.Database.CourseNames();

            //print courses
        }

        public void PrintIds()
        {
            var courseIds = this.Database.CourseIds();

            //print course ids
        }

        public void PrintById(int id)
        {
            var course = this.Database.GetCourseById(id);

            // print course
        }

        public void Search(string substring)
        {
            var courses = this.Database.Search(substring);

            // print courses
        }
    }
}
