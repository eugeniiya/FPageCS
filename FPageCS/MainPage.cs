using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace FPageCS
{
    class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            Title = "FlayoutPage Demo";
            Label header = new Label
            {
                Text = "FlayoutPage",
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };
            // Assemble an array of NamedColor objects.
            NamedColor[] namedColors = {
 new NamedColor ("Aqua", Color.Aqua),
 new NamedColor ("Black", Color.Black),
 new NamedColor ("Blue", Color.Blue),
 new NamedColor ("Fuchsia", Color.Fuchsia),
 new NamedColor ("Gray", Color.Gray),
 new NamedColor ("Green", Color.Green),
 new NamedColor ("Lime", Color.Lime),
 new NamedColor ("Maroon", Color.Maroon),
 new NamedColor ("Navy", Color.Navy),
 new NamedColor ("Olive", Color.Olive),
 new NamedColor ("Purple", Color.Purple),
 new NamedColor ("Red", Color.Red),
 new NamedColor ("Silver", Color.Silver),
 new NamedColor ("Teal", Color.Teal),
 new NamedColor ("White", Color.White),
 new NamedColor ("Yellow", Color.Yellow)
 };
            // Создание элемента управления ListView для flyout page.
            ListView listView = new ListView
            {
                ItemsSource = namedColors,
                Margin = new Thickness(10, 0),
                BackgroundColor = Color.Black,

            };
            // Формирование flyout page с помощью элемента управления ListView.
            Master = new ContentPage
            {
                Title = "Color List",
                Content = new StackLayout
                {
                    Children = {
 header,
 listView
 }
                }
            };
            // Создание detail page с использованием класса NamedColorPage
            NamedColorPage detailPage = new NamedColorPage();
            Detail = detailPage;
            // Define a selected handler for the ListView.
            listView.ItemSelected += (sender, args) => {
                // Set the BindingContext of the detail page.
                Detail.BindingContext = args.SelectedItem;
                // Show the detail page.
                IsPresented = true;
            };
            // Initialize the ListView selection.
            listView.SelectedItem = namedColors[5];
            MasterBehavior = MasterBehavior.Popover;
        }
    }
}