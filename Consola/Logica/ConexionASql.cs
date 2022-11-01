using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;


namespace Logica
{
 
    public class ConexionASql
    {
        private static ConexionInstancia instancia = null;


        public static SQLiteConnection obtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new ConexionInstancia();
            }
            return instancia.Con;
        }


        public static DataTable hacerConsulta(string sql)
        {
            DataTable dt = new DataTable();

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, obtenerInstancia());
            dataAdapter.Fill(dt);

            return dt;
        }
        public static bool hacerConsultas(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, ConexionASql.obtenerInstancia());
            SQLiteDataReader lector = cmd.ExecuteReader();

            return lector.Read();
        }

    }

    
    public class ConexionInstancia
    {
        public SQLiteConnection Con = null;
        //private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        public ConexionInstancia()
        {
            
            Con = new SQLiteConnection("Data Source = C:\\Programacion\\TPTomasGimnacio\\Consola\\Logica\\databasegim.db");
            Con.Open();
        }

        public void ConexionInstancias()
        {
            Con.Close();
        }


        
    }
}

