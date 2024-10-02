namespace AngularTask2.Server.Dtos
{
    public class addServicesDTO
    {

        public string? ServiceName { get; set; }

        public string? ServiceDescription { get; set; }

        public IFormFile ServiceImage { get; set; }
    }
}
