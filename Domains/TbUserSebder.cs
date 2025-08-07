using Domains;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class TbUserSebder : BaseTable
{
    public Guid UserId { get; set; }

    public string SenderName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string PostalCode { get; set; } = null!;
    public string Contact { get; set; } = null!;
    public string OtherAddress { get; set; } = null!;
    public bool IsDefault { get; set; }
    public Guid CityId { get; set; }

    public string Address { get; set; } = null!;

    public virtual TbCity City { get; set; } = null!;

    public virtual ICollection<TbShippment> TbShippments { get; set; } = new List<TbShippment>();
}
