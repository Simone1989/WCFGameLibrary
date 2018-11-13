using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using WCFGameLibrary.Data;
using WCFGameLibrary.Model;
using System.Data.SqlClient;
using System.Windows;

namespace WCFGameLibrary.Services
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.PerCall)]
    public class WCFGameLibraryService : IWCFGameLibraryService
    {
        private readonly WCFGameLibraryDbContext _context = new WCFGameLibraryDbContext();

        public void Add(Game game)
        {
            using (var context = _context)
            {
                context.Games.Attach(game);
                context.Entry(game).State = EntityState.Added;
                context.Games.Add(game);
                context.SaveChanges();
            }

            try
            {
                SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WCFGameLibrary;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();

                string Query = @"INSERT INTO Games (Id, Title, Description) Values(@Id, @Title, @Description)";

                cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Id", game.Id);
                cmd.Parameters.AddWithValue("@Title", game.Title);
                cmd.Parameters.AddWithValue("@Description", game.Description);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Delete(Game game)
        {
            using (var context = _context)
            {
                context.Games.Attach(game);
                context.Entry(game).State = EntityState.Deleted;
                context.Games.Remove(game);
                context.SaveChanges();
            }
        }
        
        public List<Game> GetAllGames()
        {
            return _context.Games.ToList();
        }

        public async void Save(Game game)
        {
            using (var context = _context)
            {
                context.Games.Attach(game);
                context.Entry(game).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
