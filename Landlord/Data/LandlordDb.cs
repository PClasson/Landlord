using System.ComponentModel.DataAnnotations;
using Blazor.IndexedDB.Framework;
using Microsoft.JSInterop;

namespace Landlord.Data
{
    public class LandlordDb : IndexedDb
    {
        public LandlordDb(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }

        public IndexedSet<Tenant> Tenants { get; set; }
        public IndexedSet<InvoiceRow> InvoiceRows { get; set; }
    }

    public class Tenant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }

    public class InvoiceRow
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }

        [Required]
        public int TenantId { get; set; }
    }
}