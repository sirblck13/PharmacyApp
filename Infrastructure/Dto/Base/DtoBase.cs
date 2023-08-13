namespace Dal.Model.Base
{
    public abstract class DtoBase
    {
        #region Publich Fields

        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime? DeletionDate { get; set; }

        #endregion
    }
}
