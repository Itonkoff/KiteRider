namespace Services.Api.Emp {
    public class EmployeeService : IEmployeeService {
        private readonly IEmployeeService _employeeService;

        public EmployeeService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
    }
}