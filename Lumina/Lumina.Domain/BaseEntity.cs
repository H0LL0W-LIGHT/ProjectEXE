using System.ComponentModel.DataAnnotations;

namespace Lumina.Domain
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
