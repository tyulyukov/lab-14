using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Lab14;

public partial class MainWindow : Window
{
    private HomePet? _currentPet;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void CreateDogButton_Click(object sender, RoutedEventArgs e)
    {
        var name = DogNameTextBox.Text?.Trim();
        if (string.IsNullOrEmpty(name))
        {
            DogInfoTextBlock.Text = "Введіть ім'я собаки.";
            return;
        }

        var dog = new Dog(name);
        dog.SoundMade += OnSoundMade;
        _currentPet = dog;
        SpeakButton.IsEnabled = true;

        DogInfoTextBlock.Text = $"Собака '{dog.Name}' створена";
        DogNameTextBox.Text = string.Empty;
    }

    private void CreateCatButton_Click(object sender, RoutedEventArgs e)
    {
        var name = CatNameTextBox.Text?.Trim();
        if (string.IsNullOrEmpty(name))
        {
            CatInfoTextBlock.Text = "Введіть ім'я кішки.";
            return;
        }

        var cat = new Cat(name);
        cat.SoundMade += OnSoundMade;
        _currentPet = cat;
        SpeakButton.IsEnabled = true;

        CatInfoTextBlock.Text = $"Кішка '{cat.Name}' створена";
        CatNameTextBox.Text = string.Empty;
    }

    private void CreateParrotButton_Click(object sender, RoutedEventArgs e)
    {
        var name = ParrotNameTextBox.Text?.Trim();
        if (string.IsNullOrEmpty(name))
        {
            ParrotInfoTextBlock.Text = "Введіть ім'я папуги.";
            return;
        }

        var parrot = new Parrot(name);
        parrot.SoundMade += OnSoundMade;
        _currentPet = parrot;
        SpeakButton.IsEnabled = true;

        ParrotInfoTextBlock.Text = $"Папуга '{parrot.Name}' створена";
        ParrotNameTextBox.Text = string.Empty;
    }

    // новий обробник для кнопки Speak
    private void SpeakButton_Click(object sender, RoutedEventArgs e)
    {
        _currentPet?.Speak();
    }

    private void OnSoundMade(object sender, SoundEventArgs e)
    {
        if (sender is HomePet pet)
        {
            LastEventTextBlock.Text = $"{pet.Name} сказав: {e.Sound}";
        }
    }
}
