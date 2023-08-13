using System.ComponentModel.DataAnnotations;

namespace Dal.Model.Base
{
    public abstract class EntityBase
    {
        #region Publich Fields

        [Key]
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime? DeletionDate { get; set; }

        #endregion
    }
}
