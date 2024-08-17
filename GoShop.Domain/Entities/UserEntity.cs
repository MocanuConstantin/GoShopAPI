using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoShop.Domain.Entities;

public class UserEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string UserName { get; set; } = default!;

    // Коллекция мобильных телефонов, принадлежащих пользователю
    public ICollection<MobilePhoneEntity> MobilePhones { get; set; } = new List<MobilePhoneEntity>();
}
