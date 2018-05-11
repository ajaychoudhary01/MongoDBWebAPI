namespace MongoDBWebAPI.Model
{
    /// <summary>
    /// Connection string settings class for options
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// get or set mongo database connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// get or set mongo database name
        /// </summary>
        public string Database { get; set; }
    }
}
