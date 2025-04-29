using System;

namespace Lab14;

// Інтерфейс зі звуком і подією
public interface ISpeakable
{
    void Speak();
    event EventHandler<SoundEventArgs>? SoundMade;
}

public class SoundEventArgs : EventArgs
{
    public string Sound { get; set; }
}

// Головний клас ієрархії
public class HomePet : ISpeakable
{
    public HomePet(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public event EventHandler<SoundEventArgs>? SoundMade;

    public void Speak()
    {
        var soundCount = Random.Shared.Next(1, 5);
        var s = string.Empty;
        for (var i = 0; i < soundCount; i++)
        {
            s += GetSound() + " ";
        }

        SoundMade?.Invoke(this, new SoundEventArgs { Sound = s });
    }

    protected virtual string GetSound()
    {
        return "Я домашня тварина";
    }
}

public class Dog : HomePet
{
    public Dog(string name) : base(name)
    {
    }

    protected override string GetSound()
    {
        return "Гав";
    }
}

public class Cat : HomePet
{
    public Cat(string name) : base(name)
    {
    }

    protected override string GetSound()
    {
        return "Мяу";
    }
}

public class Parrot : HomePet
{
    public Parrot(string name) : base(name)
    {
    }

    protected override string GetSound()
    {
        return "Крр";
    }
}