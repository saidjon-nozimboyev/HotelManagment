namespace HotelManagment.Domain.Entities;

public class Hotel : Base
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double StarRating { get; set; }
    public string ContactInformation { get; set; } = string.Empty;  
    public string Geolocation {  get; set; } = string.Empty;
}
