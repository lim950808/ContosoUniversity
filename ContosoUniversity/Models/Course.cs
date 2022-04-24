using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        public Department Department { get; set; }
        //강좌에는 등록된 학생이 여러 명 있을 수 있으므로 Enrollments 탐색 속성은 컬렉션
        public ICollection<Enrollment> Enrollments { get; set; }
        //여러 강사가 한 강좌를 수업할 수 있으므로 CourseAssignments 탐색 속성은 컬렉션
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}