using BibleVerseApplication.Models;
using BibleVerseApplication.Services.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BibleVerseApplication.Services.Data
{
    public class DAO
    {
        //Connection and useable variables
        private readonly SqlConnection connection = new SqlConnection("data source=(localdb)\\MSSQLLocalDB; database=Verse; integrated security = SSPI");
        private string testament, book, text;
        private int chapter, verse;

        //Initialized 
        public DAO(VerseModel model)
        {
            
            testament = model.Testament;
            book = model.Book;
            chapter = model.Chapter;
            verse = model.Verse;
            text = model.Text;
        }

        //Make sure verse does not all ready exisit. 
        public bool CheckExisting()
        {
            try
            {
                MyLogger.GetInstance().Info("Check if verse already exists! CheckExisting()");
                string query = "SELECT * FROM dbo.Verse WHERE Book=@book AND Verse=@verse AND Text=@text";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@book", SqlDbType.NVarChar, 50).Value = book;
                command.Parameters.Add("@verse", SqlDbType.Int).Value = verse;
                command.Parameters.Add("@text", SqlDbType.NVarChar).Value = text;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    connection.Close();
                    MyLogger.GetInstance().Info("The verse already exists in our App!");
                    return false;
                }
                else
                {
                    connection.Close();
                    MyLogger.GetInstance().Info("This verse is not in the App yet!");
                    return true;
                }
            }
            catch (SqlException e)
            {
                MyLogger.GetInstance().Info("There was an error trying to add: " + e.ToString());
                throw e;
            }
        }

        //Add Verse to Database
        public void InsertVerse()
        {
            try
            {

                string query = "INSERT INTO dbo.Verse (Testament, Book, Chapter, Verse, Text) VALUES (@testament," +
                    " @book, @chapter, @verse, @text)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@testament", SqlDbType.NVarChar, 50).Value = testament;
                command.Parameters.Add("@book", SqlDbType.NVarChar, 50).Value = book;
                command.Parameters.Add("@chapter", SqlDbType.Int).Value = chapter;
                command.Parameters.Add("@verse", SqlDbType.Int).Value = verse;
                command.Parameters.Add("@text", SqlDbType.NVarChar).Value = text;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        //Search for Verse with user inputed: book, chapter, and verse
        public List<string> SearchVerse()
        {
            try
            {

                string query = "SELECT * FROM dbo.Verse WHERE Testament=@testament AND Book=@book AND Chapter=@chapter" +
                    " AND Verse=@verse";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@testament", SqlDbType.NVarChar, 50).Value = testament;
                command.Parameters.Add("@book", SqlDbType.NVarChar, 50).Value = book;
                command.Parameters.Add("@chapter", SqlDbType.Int).Value = chapter;
                command.Parameters.Add("@verse", SqlDbType.Int).Value = verse;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<string> list = new List<string>();

                if (!reader.HasRows)
                {
                    list.Add("No results found!");
                    return list;
                }

                while (reader.Read())
                {
                    list.Add(reader["Testament"].ToString());
                    list.Add(reader["Book"].ToString());
                    list.Add(reader["Chapter"].ToString());
                    list.Add(reader["Verse"].ToString());
                    list.Add(reader["Text"].ToString());
                }

                connection.Close();
                return list;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
    }
}