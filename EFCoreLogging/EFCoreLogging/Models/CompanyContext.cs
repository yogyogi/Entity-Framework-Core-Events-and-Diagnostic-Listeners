using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Diagnostics;

namespace EFCoreLogging.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
            ChangeTracker.StateChanged += UpdateTimestamps;
            ChangeTracker.Tracked += UpdateTimestamps;
        }

        /*public CompanyContext() : base()
        {
        }*/

        public DbSet<Employee> Employee { get; set; }

        #region UpdateTimestamps
        private static void UpdateTimestamps(object sender, EntityEntryEventArgs e)
        {
            if (e.Entry.Entity is IHasTimestamps entityWithTimestamps)
            {
                switch (e.Entry.State)
                {
                    case EntityState.Deleted:
                        entityWithTimestamps.Deleted = DateTime.UtcNow;
                        Console.WriteLine($"Stamped for delete: {e.Entry.Entity}");
                        break;
                    case EntityState.Modified:
                        entityWithTimestamps.Modified = DateTime.UtcNow;
                        Console.WriteLine($"Stamped for update: {e.Entry.Entity}");
                        break;
                    case EntityState.Added:
                        entityWithTimestamps.Added = DateTime.UtcNow;
                        Console.WriteLine($"Stamped for insert: {e.Entry.Entity}");
                        break;
                }
            }
        }
        #endregion

        /*public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); }); 
             
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder
                    .UseLoggerFactory(MyLoggerFactory)
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreLogging;Trusted_Connection=True;ConnectRetryCount=0")
                    .EnableSensitiveDataLogging();*/

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.LogTo(Console.WriteLine);

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Name });*/

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine, new[] { CoreEventId.ContextDisposed, CoreEventId.ContextInitialized });*/

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(message => Debug.WriteLine(message));*/

        /*private readonly StreamWriter stream = new StreamWriter("mylog.txt", append: true);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(stream.WriteLine);

        public override void Dispose()
        {
            base.Dispose();
            stream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await stream.DisposeAsync();
        }*/
    }
}
