using Prueba.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Apis;

namespace Prueba.ViewModels;

[QueryProperty(nameof(PhotoDetail), "PhotoDetail")]
public partial class AddupdateImageModel : ObservableObject
{
    [ObservableProperty]
    private Photo _PhotoDetail = new Photo();

    private readonly InterfazBDD photoService;
    public AddupdateImageModel(InterfazBDD photoService)
    {
        this.photoService = photoService;
    }

    [ICommand]
    public async void AddUpdateNote()
    {
        int response = -1;
        if (PhotoDetail.id > 0)
        {
            response = await photoService.UpdatePhoto(PhotoDetail);
        }
        else
        {
            response = await photoService.AddPhoto(new Apis.Photo
            {
                img_src = PhotoDetail.img_src,
                id = PhotoDetail.id,
                earth_date = PhotoDetail.earth_date,
            });
        }

        if (response > 0)
        {
            await Shell.Current.DisplayAlert("Comentario Guardado", "Registro guardado exitosamente", "OK");
            await Shell.Current.GoToAsync("..");
        }
        else
        {
            await Shell.Current.DisplayAlert("ERROR", "Algo fallo mientras se guardaba el registro", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}
