namespace Catalog.Settings{
    public class MysqlDbSettings{
        public string Host { get; set; }
        public string Uid { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string ConnectionString { get{
            return $"server={Host};uid={Uid};pwd={Password};database={Database}";
        } }
    }
}