using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Apis;

namespace Prueba.Services
{
    public interface InterfazBDD
    {
        Task<List<Photo>> GetPhotoList();
        Task<int> AddPhoto(Photo foto);
        Task<int> DeletePhoto(Photo foto);
        Task<int> UpdatePhoto(Photo foto);
    }
}
