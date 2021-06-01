using System;
using System.Collections.Generic;
using System.Text;

namespace TqlBootcamp.Models {
    
    public class AssessmentScore {

        public int Id { get; set; }
        public int ActualScore { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int AssessmentId { get; set; }
        public virtual Assessment Assessment { get; set; }

        public AssessmentScore() {}
    }
}
