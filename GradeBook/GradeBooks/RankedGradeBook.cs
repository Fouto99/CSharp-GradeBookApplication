using System;
using GradeBook.Enums;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            double total = 0.0;
            Students.ForEach(student => total += student.AverageGrade);

            double percentage = (total / Students.Count) * 100;

            if (percentage >= 80) return 'A';
            else if (percentage < 80 && percentage >= 60) return 'B';
            else if (percentage < 60 && percentage >= 40) return 'C';
            else if (percentage < 40 && percentage >= 20) return 'D';
            return 'F';
        }
    }
}