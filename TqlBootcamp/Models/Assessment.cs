using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TqlBootcamp.Models {
    
    public class Assessment {

        public int Id { get; set; }
        [Required, StringLength(30)]
        public string Topic { get; set; }
        public int NumberOfQuestions { get; set; }
        public int MaxPoints { get; set; }

        public virtual List<AssessmentScore> AssessmentScores { get; set; }

        public Assessment() {}
    }
}
