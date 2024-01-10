namespace JohnGpaCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Student Performance Tracker");
            Console.Write("How many Courses did you take: ");
                int numberCourses = int.Parse(Console.ReadLine());
            Console.Clear();
            
            List<PerformanceTracker> coursePerformance = new List<PerformanceTracker>();

            for (int i = 0; i < numberCourses; i++)
            {
                Console.Write($"Enter course code {i + 1}]: ");
                string courseCode = Console.ReadLine();

                Console.Write($"Enter credit load for course {courseCode}: ");
                int creditLoad = int.Parse(Console.ReadLine());

                Console.Write($"Enter your score for {courseCode}: ");
                int score = int.Parse(Console.ReadLine());
                Console.Clear();


                char grade;
                int gradePoint;
                int pointWeight;
                string remark;

                if (score >= 70 && score <= 100)
                {
                    grade = 'A';
                    gradePoint = 5;
                    remark = "Excellent";
                }
                else if (score >= 60 && score <= 69)
                {
                    grade = 'B';
                    gradePoint = 4;
                    remark = "Very Good";
                }
                else if (score >= 50 && score <= 59)
                {
                    grade = 'C';
                    gradePoint = 3;
                    remark = "Good";
                }
                else if (score >= 45 && score <= 49)
                {
                    grade = 'D';
                    gradePoint = 2;
                    remark = "Fair";
                }
                else if (score >= 40 && score <= 44)
                {
                    grade = 'E';
                    gradePoint = 1;
                    remark = "Pass";
                }
                else
                {
                    grade = 'F';
                    gradePoint = 0;
                    remark = "Fail";
                }

                pointWeight = creditLoad * gradePoint;

                coursePerformance.Add(new PerformanceTracker
                { 
                    CourseCode = courseCode, CreditLoad = creditLoad, Grade = grade,
                    GradePoint = gradePoint, PointWeight = pointWeight, Remark = remark
                });
            }

            Console.WriteLine("|-----------------|----------------|----------|-------------------|-----------------|-----------------|");
            Console.WriteLine("| COURSE CODE     | CREDIT LOAD    | GRADE    | GRADE POINT       | POINT WEIGHT    | REMARK          |");
            Console.WriteLine("|-----------------|----------------|----------|-------------------|-----------------|-----------------|");
           
            foreach (var performance in coursePerformance)
            {
                Console.WriteLine($"| {performance.CourseCode,-15} | {performance.CreditLoad,-14} | {performance.Grade,-8} | {performance.GradePoint,-17} | {performance.PointWeight,-15} | {performance.Remark,-15} |");
            }

            Console.WriteLine("|-----------------|----------------|----------|-------------------|-----------------|-----------------|");

            int totalCreditLoadRegistered = 0;
            int totalCreditLoadPassed = 0;
            double totalPointWeight = 0;

            foreach (var performance in coursePerformance)
            {
                totalCreditLoadRegistered += performance.CreditLoad;
                if (performance.Grade != 'F')
                {
                    totalCreditLoadPassed += performance.CreditLoad;
                    totalPointWeight += performance.PointWeight;
                }
            }

            double gpa = Math.Round(totalPointWeight / totalCreditLoadPassed, 2);

            Console.WriteLine($"Total Credit Load Registered is {totalCreditLoadRegistered}");
            Console.WriteLine($"Total Credit Load Passed is {totalCreditLoadPassed}");
            Console.WriteLine($"Total Point Weight is {totalPointWeight}");
            Console.WriteLine($"Your GPA: {gpa}");

            string message = "";
            if (gpa >= 4.50 && gpa <= 5.00)
            {
                message = "Performance Report: You are in the \"First class\" range.";
            }
            else if (gpa >= 3.50 && gpa < 4.50)
            {
                message = "Performance Report: You are in the \"Second class Upper Division\" range.";
            }
            else if (gpa >= 2.50 && gpa < 3.50)
            {
                message = "Performance Report: You are in the \"Second class Lower Division\" range.";
            }
            else if (gpa >= 1.50 && gpa < 2.50)
                {
                message = "Performance Report: You are in the \"Third Class\" range.";
            }
            else if (gpa >= 1.00 && gpa < 1.50)
            {
                message = "Performance Report: You are in the \"Pass Class\" range.";
            }
            else
            {
                message = "You need to Step Up. if not \"No Degree will be awarded\".";
            }
            Console.WriteLine(message);

            DateTime myValue = DateTime.Now;
            Console.WriteLine(myValue.ToString());
        }
    }
   
}