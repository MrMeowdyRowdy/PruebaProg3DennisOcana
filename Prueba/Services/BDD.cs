using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Apis;

namespace Prueba.Services
{
    namespace CAD_PROYECTO2.Services
    {
        public class BDD : InterfazBDD
        {
            //se declara el uso de una conexion asincrona con la BDD
            private SQLiteAsyncConnection conn;

            //inicializacion de la base de datos y creacion de la misma ademas de establecer el Path a esta
            private async Task ReadySteadyGO()
            {
                if (conn == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "photos.db3");
                    conn = new SQLiteAsyncConnection(dbPath);
                    await conn.CreateTableAsync<Photo>();
                }
            }

            //Codigo para interaccion de la BDD con la tabla comentarios
            public async Task<int> AddPhoto(Photo photo)
            {
                await ReadySteadyGO();
                return await conn.InsertAsync(photo);
            }

            public async Task<int> DeletePhoto(Photo photo)
            {
                await ReadySteadyGO();
                return await conn.DeleteAsync(photo);
            }

            public async Task<List<Photo>> GetPhotoList()
            {
                await ReadySteadyGO();
                var photo = await conn.Table<Photo>().ToListAsync();
                return photo;
            }

            public async Task<int> UpdatePhoto(Photo photo)
            {
                await ReadySteadyGO();
                return await conn.UpdateAsync(photo);
            }
        }
    }

}
