using System;

class Program
{
    public class Job()
    {
        public string _company;
        public string _jobTitle;
        public int _startYear;
        public int _endYear;
        public void display()
        {
            Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
        }
    }
    public class Resume()
    {
        public string _name;
        public List<Job> _jobs = new List<Job>();
        public void display()
        {
            Console.WriteLine(_name);
            foreach (Job job in _jobs){
                job.display();
            }
        }
        
    }

    static void Main(string[] args)
    {
        
        Resume MattE = new Resume();
        Job job1 = new Job();
        job1._company = "Walmart";
        job1._jobTitle = "Manager";
        job1._startYear = 1997;
        job1._endYear = 1999;
        Job job2 = new Job();
        job2._company = "CarMax";
        job2._jobTitle = "Mechanic";
        job2._startYear = 2000;
        job2._endYear = 2003;
        
        MattE._name = "Matthew Eyre";
        MattE._jobs.Add(job1);
        MattE._jobs.Add(job2);
        MattE.display();
    }
}