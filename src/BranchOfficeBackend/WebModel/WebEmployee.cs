namespace BranchOfficeBackend
{
    /// <summary>
    /// Accessible through API server
    /// </summary>
    public class WebEmployee
    {
        /// <summary>
        /// May be needed for deserialization
        /// </summary>
        public WebEmployee()
        {

        }
        public WebEmployee(Employee e)
        {
            this.Name = e.Name;
            this.Email = e.Email;
            this.ID = e.EmployeeId;
            this.IsManager = e.IsManager;
            // TODo more fiels
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public int ID { get; set; }
        public bool IsManager { get; set; }
    }
}
