using System.Reflection;

namespace FilmArchive.Application
{
    public class AssemblyUtility
    {
        public static Assembly GetAssembly() => Assembly.GetExecutingAssembly();
    }
}