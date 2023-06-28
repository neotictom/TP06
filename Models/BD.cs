using System.Data.SqlClient;
using Dapper;
public class BD{
    private static string _connectionString = @"Server=localhost; DataBase=Elecciones;Trusted_Connection=True;";
    public static void AgregarCandidato(Candidato can){
        string consulta = "INSERT INTO Candidatos (IdCandidato, IdPartido, Apellido, Nombre, Fechanacimiento, Foto, Postulacion) " + "VALUES (@IdCandidato, @IdPartido, @Apellido, @Nombre, @Fechanacimiento, @Foto, @Postulacion);";
        using (SqlConnection conexion = new SqlConnection(connectionString)){
        conexion.Execute(consulta, can);
        }
    }
    public static void EliminarCandidato(int idCandidato){
        string consulta = "DELETE FROM Candidatos WHERE IdCandidato = @IdCandidato;";
    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        conexion.Execute(consulta, new { IdCandidato = idCandidato });
    }
    }
    public static Partido VerInfoPartido(int idPartido){
    string consulta = "SELECT IdPartido, Nombre, Logo, Sitioweb, Fechafundacion, Cantidaddiputados, Cantidadsenadores FROM Partidos WHERE IdPartido = @IdPartido;";
    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        return conexion.QuerySingleOrDefault<Partido>(consulta, new { IdPartido = idPartido });
    }
    }
    public static Candidato VerInfoCandidato(int idCandidato)
    {
    string consulta = "SELECT IdCandidato, IdPartido, Apellido, Nombre, Fechanacimiento, Foto, Postulacion FROM Candidatos WHERE IdCandidato = @IdCandidato;";
    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        return conexion.QuerySingleOrDefault<Candidato>(consulta, new { IdCandidato = idCandidato });
    }
    }
    public List<Partido> ListarPartidos()
    {
    string consulta = "SELECT IdPartido, Nombre, Logo, Sitioweb, Fechafundacion, Cantidaddiputados, Cantidadsenadores FROM Partidos;";

    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        return conexion.Query<Partido>(consulta).ToList();
    }
    }
public List<Candidato> ListarCandidatos(int idPartido)
    {
    string consulta = "SELECT IdCandidato, IdPartido, Apellido, Nombre, Fechanacimiento, Foto, Postulacion FROM Candidatos WHERE IdPartido = @IdPartido;";
    using (SqlConnection conexion = new SqlConnection(connectionString))
    {
        return conexion.Query<Candidato>(consulta, new { IdPartido = idPartido }).ToList();
    }
    }
}