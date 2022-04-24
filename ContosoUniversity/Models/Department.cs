using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        //부서는 관리자가 있을 수도 있고 없을 수도 있으며, 관리자는 항상 강사입니다. 따라서 InstructorID 속성은 강사 엔터티에 외래 키로 포함
        public int? InstructorID { get; set; }

        //Timestamp 특성은 데이터베이스에 전송된 Update 및 Delete 명령의 Where 절에 이 열이 포함되도록 지정
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Instructor Administrator { get; set; }
        //부서에는 강좌가 많이 있을 수 있으므로 강좌 탐색 속성이 있습니다.
        public ICollection<Course> Courses { get; set; }
    }
}