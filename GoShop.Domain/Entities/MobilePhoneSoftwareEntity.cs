using System.Text.Json.Serialization;

public class MobilePhoneSoftwareEntity
{
    public Guid Id { get; set; }
    public string OperatingSystem { get; set; }
    public string OSVersion { get; set; }
    public string FirmwareVersion { get; set; }
    public bool IsRootedOrJailbroken { get; set; }
    public DateTime LastSoftwareUpdate { get; set; }

    public Guid MobilePhoneId { get; set; }
    public MobilePhoneEntity MobilePhone { get; set; }
}
