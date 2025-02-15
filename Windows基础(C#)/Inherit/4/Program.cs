using System;
class Program
{
    public class Person
    {
    }
    public interface IHomeworkCollector
    {
        void CollectHomework();
    }
    class Student : Person, IHomeworkCollector
    {
        public void CollectHomework()
        {
            Console.WriteLine("报告老师！作业收集完毕！");
        }
    }
    class Teacher : Person, IHomeworkCollector
    {
        public void CollectHomework()
        {
            Console.WriteLine("同学们，请交作业！");
        }
    }
    private void DoCollectHomework(IHomeworkCollector collector)
    {
        collector.CollectHomework();
    }
    static void Main(string[] args)
    {
        Student person1 = new Student();
        Teacher person2 = new Teacher();
        Program program = new Program();
        program.DoCollectHomework(person1);
        program.DoCollectHomework(person2);
    }
}



