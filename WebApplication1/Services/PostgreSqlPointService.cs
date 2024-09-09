using Npgsql;

public class PostgreSqlPointService : GenericService<Point>
{
    private readonly string _connectionString;

    public PostgreSqlPointService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public override List<Point> GetAll()
    {
        var points = new List<Point>();
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            var command = new NpgsqlCommand("SELECT * FROM Points", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    points.Add(new Point
                    {
                        Id = reader.GetInt64(0),
                        PointX = reader.GetDouble(1),
                        PointY = reader.GetDouble(2),
                        Name = reader.GetString(3)
                    });
                }
            }
        }
        return points;
    }

    public override Point GetById(long id)
    {
        Point point = null;
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            var command = new NpgsqlCommand("SELECT * FROM Points WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    point = new Point
                    {
                        Id = reader.GetInt64(0),
                        PointX = reader.GetDouble(1),
                        PointY = reader.GetDouble(2),
                        Name = reader.GetString(3)
                    };
                }
            }
        }
        return point;
    }

    public override Point Add(Point point)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            var command = new NpgsqlCommand(
                "INSERT INTO Points (PointX, PointY, Name) VALUES (@x, @y, @name) RETURNING Id", connection);

            command.Parameters.AddWithValue("@x", point.PointX);
            command.Parameters.AddWithValue("@y", point.PointY);
            command.Parameters.AddWithValue("@name", point.Name);

        }
        return point;
    }

    public override Point Update(long id, Point updatedPoint)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            var command = new NpgsqlCommand(
                "UPDATE Points SET PointX = @x, PointY = @y, Name = @name WHERE Id = @id", connection);

            command.Parameters.AddWithValue("@x", updatedPoint.PointX);
            command.Parameters.AddWithValue("@y", updatedPoint.PointY);
            command.Parameters.AddWithValue("@name", updatedPoint.Name);
            command.Parameters.AddWithValue("@id", id);

            var affectedRows = command.ExecuteNonQuery();
            if (affectedRows == 0) return null;
        }
        return updatedPoint;
    }

    public override bool Delete(long id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            var command = new NpgsqlCommand("DELETE FROM Points WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            var affectedRows = command.ExecuteNonQuery();
            return affectedRows > 0;
        }
    }
}
