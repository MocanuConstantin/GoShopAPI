using GoShop.Domain.Entities;

public class MobilePhoneEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public int? Year { get; set; }
    public string Condition { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal? Price { get; set; }


    public MobilePhoneHardwareEntity MobilePhoneHardware { get; set; } = default!;
    public MobilePhoneSoftwareEntity MobilePhoneSoftware { get; set; } = default!;
}
