namespace MyNotes.DAL
{
    public abstract class MyNotesDB
    {
        protected string ConnectionString { get; set; }

        public MyNotesDB(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
