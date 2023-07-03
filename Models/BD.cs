using System.Data.SqlClient;
using Dapper;
public class BD{
    private static string _connectionString = @"Server=localhost; DataBase=Elecciones;Trusted_Connection=True;";
    public static void AgregarCandidato(Candidato can){
        string sql = "INSERT INTO Candidatos (IdCandidato, IdPartido, Apellido, Nombre, Fechanacimiento, Foto, Postulacion) " + "VALUES (@IdCandidato, @IdPartido, @Apellido, @Nombre, @Fechanacimiento, @Foto, @Postulacion);";
        using (SqlConnection conexion = new SqlConnection(_connectionString)){
        conexion.Execute(sql, new {cId = can.idCandidato, cIdp = can.idPartido, cApellido = can.Apellido, cNombre = can.Nombre, cFechanac = can.FechaNacimiento, cFoto = can.Foto, cPostulacion = can.Postulacion});
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
        string sql = "SELECT IdPartido, Nombre, Logo, Sitioweb, Fechafundacion, Cantidaddiputados, Cantidadsenadores FROM Partidos WHERE IdPartido = @IdPartido;";
        info = conexion.Query<Partido>(sql, new { IdPartido = idPartido });
    }
    return info;
    }
    public static Candidato VerInfoCandidato(int idCandidato)
    {
    string consulta = "SELECT IdCandidato, IdPartido, Apellido, Nombre, Fechanacimiento, Foto, Postulacion FROM Candidatos WHERE IdCandidato = @IdCandidato;";
    using (SqlConnection conexion = new SqlConnection(_connectionString))
    {
        return conexion.QuerySingleOrDefault<Candidato>(consulta, new { IdCandidato = idCandidato });
    }
    }
    public List<Partido> ListarPartidos()
    {
    string consulta = "SELECT IdPartido, Nombre, Logo, Sitioweb, Fechafundacion, Cantidaddiputados, Cantidadsenadores FROM Partidos;";

    using (SqlConnection conexion = new SqlConnection(_connectionString))
    {
        return conexion.Query<Partido>(consulta).ToList();
    }
    }
    public List<Candidato> ListarCandidatos(int idPartido)
    {
    string consulta = "SELECT IdCandidato, IdPartido, Apellido, Nombre, Fechanacimiento, Foto, Postulacion FROM Candidatos WHERE IdPartido = @IdPartido;";
    using (SqlConnection conexion = new SqlConnection(_connectionString))
    {
        return conexion.Query<Candidato>(consulta, new { IdPartido = idPartido }).ToList();
    }
    }
}