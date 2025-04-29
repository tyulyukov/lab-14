using Avalonia.Controls;
using System;

namespace Lab14;

public partial class MainWindow : Window
{
    private HomePet _mainPet;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnCreateHomePet(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_mainPet == null)
        {
            _mainPet = new HomePet("MyHomePet");
            _mainPet.PetSound += Pet_PetSound;
            // Enable subordinate pet actions
            CreateDogButton.IsEnabled = true;
            CreateCatButton.IsEnabled = true;
            CreateParrotButton.IsEnabled = true;
            OutputTextBlock.Text = $"{_mainPet.Name} created.";
        }
    }

    private void OnCreateDog(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var dog = new Dog("Doggo");
        dog.PetSound += Pet_PetSound;
        dog.Speak();
    }

    private void OnCreateCat(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var cat = new Cat("Kitty");
        cat.PetSound += Pet_PetSound;
        cat.Speak();
    }

    private void OnCreateParrot(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var parrot = new Parrot("Polly");
        parrot.PetSound += Pet_PetSound;
        parrot.Speak();
    }

    private void Pet_PetSound(object? sender, EventArgs e)
    {
        if (sender is HomePet pet)
        {
            OutputTextBlock.Text = $"{pet.Name} says: {GetSound(pet)}";
        }
    }

    private string GetSound(HomePet pet)
    {
        // Return a specific sound depending on the pet type
        return pet switch
        {
            Dog _ => "Gav!",
            Cat _ => "Meow!",
            Parrot _ => "chika chika chika slim shady!",
            _ => "Some sound"
        };
    }
}