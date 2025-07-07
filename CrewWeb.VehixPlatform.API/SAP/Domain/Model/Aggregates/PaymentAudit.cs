using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace CrewWeb.VehixPlatform.API.SAP.Domain.Model.Aggregates;

public partial class Payment : IEntityWithCreatedUpdatedDate
{
    [Column(name: "CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column(name: "UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}