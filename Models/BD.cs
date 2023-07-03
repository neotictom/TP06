using System.Data.SqlClient;
using Dapper;
public class BD{
    public static string _connectionString = @"Server=localhost; DataBase=Elecciones;Trusted_Connection=True;";
    public static void AgregarCandidato(Candidato can){
        string sql = "INSERT INTO Candidatos (IdCandidato, IdPartido, Apellido, Nombre, Fechanacimiento, Foto, Postulacion) " + "VALUES (@IdCandidato, @IdPartido, @Apellido, @Nombre, @Fechanacimiento, @Foto, @Postulacion);";
        using (SqlConnection conexion = new SqlConnection(_connectionString)){
        conexion.Execute(sql, new {IdCandidato = can.idCandidato, IdPartido = can.idPartido, Apellido = can.Apellido, Nombre = can.Nombre, Fechanacimiento = can.FechaNacimiento, Foto = can.Foto, Postulacion = can.Postulacion});
        }
    }
    public static void EliminarCandidato(int idCandidato){
        string consulta = "DELETE FROM Candidatos WHERE IdCandidato = @IdCandidato;";
    using (SqlConnection conexion = new SqlConnection(_connectionString))
    {
        conexion.Execute(consulta, new { IdCandidato = idCandidato });
    }
    }
    public static Partido VerInfoPartido(int idPartido){
    Partido info = null;
    using (SqlConnection conexion = new SqlConnection(_connectionString))
    {
        string sql = "SELECT * FROM Partidos WHERE IdPartido = @IdPartido;";
        info = conexion.QueryFirstOrDefault<Partido>(sql, new {IdPartido = idPartido});
    }
    return info;
    }
    public static Candidato VerInfoCandidato(int idCandidato)
    {
    Candidato info = null;
    using (SqlConnection conexion = new SqlConnection(_connectionString))
    {
        string sql = "SELECT * FROM Candidatos WHERE IdCandidato = @IdCandidato;";
        info = conexion.QuerySingleOrDefault<Candidato>(sql, new { IdCandidato = idCandidato });
    }
    return info;
    }
    public List<Partido> ListarPartidos()
    {
    string sql = "SELECT IdPartido, Nombre, Logo, Sitioweb, Fechafundacion, Cantidaddiputados, Cantidadsenadores FROM Partidos;";

    using (SqlConnection conexion = new SqlConnection(_connectionString))
    {
        return conexion.Query<Partido>(sql).ToList();
    }
    }
    public List<Candidato> ListarCandidatos(int idPartido)
    {
    string sql = "SELECT IdCandidato, IdPartido, Apellido, Nombre, Fechanacimiento, Foto, Postulacion FROM Candidatos WHERE IdPartido = @IdPartido;";
    using (SqlConnection conexion = new SqlConnection(_connectionString))
    {
        return conexion.Query<Candidato>(sql, new { IdPartido = idPartido }).ToList();
    }
    }
}