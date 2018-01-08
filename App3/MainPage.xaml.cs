using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitializeAnimalList();
            InitializeFoodList();
            ItemGridView.ItemsSource = animalsList;
            ItemListView.ItemsSource = foodList;
            flipView1.ItemsSource = AnswerList;
            var temp = "Состояние шерсти улучшается";
            AnswerList.Insert((int)Animal.State.Good, temp);
            var temp1 = "Действует как успокоительное";
            AnswerList.Insert((int)Animal.State.Neutral, temp1);
            var temp2 = "Животное умрет от отравления";
            AnswerList.Insert((int)Animal.State.Bad, temp2);

        }
        private static List<Animal> animalsList = new List<Animal>();
        private static List<Food> foodList = new List<Food>();
        private static List<string> AnswerList = new List<string>();
        +
        private void InitializeAnimalList()
        {
            Animal NewAnimal = new Animal();
            NewAnimal.Name = "Кот";
            NewAnimal.ImagePath = new Uri("ms-appx:///Assets/Images/Cat.png");
            NewAnimal.SoundPath = new Uri("ms-appx:///Assets/Sounds/Cat.mp3");
            NewAnimal.animalClass = Animal.Class.Cat;
            animalsList.Add(NewAnimal);
            Animal NewAnimal1 = new Animal();
            NewAnimal1.Name = "Собака";
            NewAnimal1.ImagePath = new Uri("ms-appx:///Assets/Images/Dog.png");
            NewAnimal1.SoundPath = new Uri("ms-appx:///Assets/Sounds/Dog.wav");
            NewAnimal1.animalClass = Animal.Class.Dog;
            animalsList.Add(NewAnimal1);
            Animal NewAnimal2 = new Animal();
            NewAnimal2.Name = "Хомяк";
            NewAnimal2.ImagePath = new Uri("ms-appx:///Assets/Images/Dog.png");
            NewAnimal2.SoundPath = new Uri("ms-appx:///Assets/Sounds/Dog.wav");
            NewAnimal2.animalClass = Animal.Class.Rodert;
            animalsList.Add(NewAnimal2);
        }

        private void InitializeFoodList()
        {
            Food NewFood = new Food();
            NewFood.NameFood = "Гамбургер";
            NewFood.ImagePathFood = new Uri("ms-appx:///Assets/Images/Food1.jpg");
            NewFood.Description = "Жирная пища";
            NewFood.foodType = Food.Type.Meat;
            foodList.Add(NewFood);
            Food NewFood1 = new Food();
            NewFood1.NameFood = "Фрукты";
            NewFood1.ImagePathFood = new Uri("ms-appx:///Assets/Images/Food2.jpg");
            NewFood1.Description = "Много сахара";
            NewFood1.foodType = Food.Type.Sweets;
            foodList.Add(NewFood1);
            Food NewFood2= new Food();
            NewFood2.NameFood = "Рыба";
            NewFood2.ImagePathFood = new Uri("ms-appx:///Assets/Images/Food2.jpg");
            NewFood1.Description = "Много белка";
            NewFood2.foodType = Food.Type.Fish;
            foodList.Add(NewFood2);
        }
        private void GridView_ItemClick(object sender, SelectionChangedEventArgs e)
        {
            mediaPlayer.Source = animalsList[ItemGridView.SelectedIndex].SoundPath;
            mediaPlayer.Volume = 1;
            mediaPlayer.Play();
            if ((ItemGridView.SelectedIndex >= 0) && (ItemListView.SelectedIndex >= 0))
            {
                SetStateToFlipview(animalsList[ItemGridView.SelectedIndex].animalClass, foodList[ItemListView.SelectedIndex].foodType);
            }

        }
        private async void Player_MediaOpened(object sender, RoutedEventArgs e)
        {
            await mediaPlayer.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                mediaPlayer.Play();
            });
        }
        private void ListView_ItemClick(object sender, SelectionChangedEventArgs e)
        {
           if ((ItemListView.SelectedIndex >= 0) && (ItemGridView.SelectedIndex >= 0))
            {
               SetStateToFlipview(animalsList[ItemGridView.SelectedIndex].animalClass, foodList[ItemListView.SelectedIndex].foodType);
           }
        }

        private void SetStateToFlipview(Animal.Class animalClass, Food.Type typeFood)
        {
            var t = Animal.CurrenState(animalClass, typeFood);
            if (t == Animal.State.Bad)
            {
                flipView1.SelectedIndex = (int) t;
            }
            if (t == Animal.State.Good)
            {
                flipView1.SelectedIndex = (int) t;
            }
            if (t == Animal.State.Neutral)
            {
                flipView1.SelectedIndex = (int) t;

            }
        }
    }

}

