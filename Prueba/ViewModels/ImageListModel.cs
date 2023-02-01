using Prueba.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Prueba.Apis;


namespace Prueba.ViewModels
{
    public partial class ImageListModel : ObservableObject
    {
        public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();

        private readonly InterfazBDD _noteService;

        public ImageListModel(InterfazBDD phServ)
        {
            _noteService = phServ;
        }

        [ICommand]
        public async void GetPhotoList()
        {
            Photos.Clear();
            var PhotoList = await _noteService.GetPhotoList();
            if (PhotoList?.Count > 0)
            {
                PhotoList = PhotoList.OrderBy(f => f.img_src).ToList();
                foreach (var Photo in PhotoList)
                {
                        Photos.Add(Photo);
                }

            }
        }
        
       [ICommand]
        public async void AddUpdatePhoto()
        {
            await AppShell.Current.GoToAsync(nameof(MainPage));
        }

        [ICommand]
        public async void MostrarAccion(Photo photoModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Seleccione Opcion", "OK", null, "Editar", "Borrar");
            if (response == "Editar")
            {
                var navParam = new Dictionary<string, object>
                {
                    { "PhotoDetail", photoModel }
                };
                await AppShell.Current.GoToAsync(nameof(MainPage), navParam);
            }

            else if (response == "Borrar")
            {
                var delResponse = await _noteService.DeletePhoto(photoModel);
                if (delResponse > 0)
                {
                    GetPhotoList();
                }
            }
        }
    }
}
