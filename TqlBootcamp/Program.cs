using System;
using System.Linq;
using System.Collections.Generic;

using TqlBootcamp.Models;

namespace TqlBootcamp {
    class Program {
        static void Main(string[] args) {

        }
        static void Loaddb() { 
            var _context = new BootcampContext();

            var scores = from s in _context.Students
                         join asc in _context.AssessmentScores
                         on s.Id equals asc.StudentId
                         join a in _context.Assessments
                         on asc.AssessmentId equals a.Id
                         select new { s.Lastname, asc.ActualScore };

            foreach(var score in scores) {
                Console.WriteLine($"{score.Lastname} {score.ActualScore}");
            }

            //var avgPoints = (from asc in _context.AssessmentScores
            //                 select new { asc.ActualScore })
            //                .Average(asc => asc.ActualScore);

            //avgPoints = _context.AssessmentScores.Average(asc => asc.ActualScore);

            //Console.WriteLine($"Average points on assessments is {avgPoints}");

        
            //var _context = new BootcampContext();
            // add the student
            var greg = new Student() {
                Firstname = "Greg", Lastname = "Doud", TargetSalary = 20000, InBootcamp = true
            };
            _context.Students.Add(greg);
            if(_context.SaveChanges() != 1) { throw new Exception("Insert student failed!");  }
            // add the assessments
            var git = new Assessment() { Topic = "Git", NumberOfQuestions = 6, MaxPoints = 120 };
            var sql = new Assessment() { Topic = "SQL", NumberOfQuestions = 12, MaxPoints = 110 };
            var cs = new Assessment() { Topic = "C#", NumberOfQuestions = 12, MaxPoints = 110 };
            var js = new Assessment() { Topic = "JavaScript", NumberOfQuestions = 11, MaxPoints = 110 };
            var ng = new Assessment() { Topic = "Angular", NumberOfQuestions = 11, MaxPoints = 110 };
            _context.Assessments.AddRange(git, sql, cs, js, ng);
            if(_context.SaveChanges() != 5) { throw new Exception("Insert assessments failed!"); }
            // add assessment scores
            var gitScore = new AssessmentScore() {
                StudentId = greg.Id, AssessmentId = git.Id, ActualScore = 10
            };
            var sqlScore = new AssessmentScore() {
                StudentId = greg.Id, AssessmentId = sql.Id, ActualScore = 20
            };
            _context.AssessmentScores.AddRange(gitScore, sqlScore);
            if(_context.SaveChanges() != 2) { throw new Exception("Insert assessment scores failed!"); }
        }
    }
}
