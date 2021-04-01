namespace AspNetCoreMVC.Services
{
    public class InstanceService : IInstaceService
    {
        private static int countOfInstances;

        public InstanceService()
        {
            countOfInstances++;
        }

        public int CountOfInstances => countOfInstances;
    }
}
