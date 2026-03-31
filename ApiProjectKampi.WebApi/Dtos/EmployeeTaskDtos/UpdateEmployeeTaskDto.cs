namespace ApiProjectKampi.WebApi.Dtos.EmployeeTaskDtos
{
    public class UpdateEmployeeTaskDto
    {
        public int EmployeeTaskId { get; set; }
        public string TaskName { get; set; }
        public byte TaskStatusValue { get; set; }
        public DateTime AssignDate { get; set; } // Atama Tarihi
        public DateTime DueDate { get; set; } // Bitiş Tarihi
        public string Priority { get; set; } // Öncelik
        public string TaskStatus { get; set; } // Öncelik
        public int ChefId { get; set; } // Öncelik
    }
}
