using System.Text.Json.Serialization;

public class MobilePhoneHardwareEntity
{
    public Guid Id { get; set; }
    public string Processor { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }
    public string Display { get; set; }
    public string Battery { get; set; }
    public string Camera { get; set; }
    public string Dimensions { get; set; }
    public string Weight { get; set; }

    public Guid MobilePhoneId { get; set; }
    public MobilePhoneEntity MobilePhone { get; set; }
}

