public class Program
{
    public static void Main(string[] args)
    {
        ArrayList<int> arrayList = new ArrayList<int>();

        arrayList.Add(5);
        arrayList.Add(5);
        arrayList.Add(5);
        arrayList.Add(5);
        arrayList.Add(5);

        arrayList.RemoveAt(3);
        arrayList.RemoveAt(0);

        System.Console.WriteLine(arrayList.Count);
    }
}
