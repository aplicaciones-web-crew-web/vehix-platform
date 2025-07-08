using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Aggregates;

public partial class Analytic : IEntityWithCreatedUpdatedDate
{
    [Column(name: "CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column(name: "UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}