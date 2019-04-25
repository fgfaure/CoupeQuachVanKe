namespace LamSonVodao.CoupeQuachVanKe.AccesPattern
{
    using System.Data.Entity;

    public interface IDataContextFactory
    {
        /// <summary>
        /// Creates the data context.
        /// </summary>
        /// <returns>The new data context.</returns>
        DbContext CreateDataContext();
    }
}
