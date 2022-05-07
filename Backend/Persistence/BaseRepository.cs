namespace Backend.Persistence
{
    public class BaseRepository
    {
        protected readonly ApplicationDbContext dbContext;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
