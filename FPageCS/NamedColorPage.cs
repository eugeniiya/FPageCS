using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace FPageCS
{
    class NamedColorPage : ContentPage
    {
        public NamedColorPage()
        {
            // Элемент управления BoxView для отображения цвета
            BoxView boxView = new BoxView
            {
                WidthRequest = 100,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center
            };
            boxView.SetBinding(BoxView.ColorProperty, "Color");
            // Функция для формирования шести элементов управления Labels.
            Func<string, string, Label> CreateLabel = (string source, string fmt) =>
            {
                Label label = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalTextAlignment = TextAlignment.End
                };
                label.SetBinding(Label.TextProperty,
                new Binding(source, BindingMode.OneWay, null, null, fmt));
                return label;
            };
            // Построение страницы (макет Stacklayout, BoxView, макет Stacklayout)
            Content = new StackLayout
            {
                Children =
 {
 new StackLayout
 {
 HorizontalOptions = LayoutOptions.Center,
 VerticalOptions = LayoutOptions.CenterAndExpand,
 Children =
 {
 CreateLabel ("Color.R", "R = {0:F2}"),
 CreateLabel ("Color.G", "G = {0:F2}"),
 CreateLabel ("Color.B", "B = {0:F2}"),
 }
 },
 boxView,
 new StackLayout
 {
 HorizontalOptions = LayoutOptions.Center,
 VerticalOptions = LayoutOptions.CenterAndExpand,
 Children =
 {
 CreateLabel ("Color.Hue", "Hue = {0:F2}"),
 CreateLabel ("Color.Saturation", "Saturation = {0:F2}"),
 CreateLabel ("Color.Luminosity", "Luminosity = {0:F2}")
 }
 }
 }
            };
        }
    }
}