namespace nsw_pt_map.Models
{
    public class VehicleViewModel
    {

        public string Label { get; set; }
        public string LicensePlate { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string id { get; set; }

        public VehicleViewModel(string id, string Label, string LicensePlate, float Longitude, float Latitude)
        {
            this.Label = Label;
            this.LicensePlate = LicensePlate;
            this.Longitude = Longitude;
            this.Latitude = Latitude;
            this.id = id;
        }
    }
}
