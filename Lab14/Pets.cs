using System;

namespace Lab14;

public interface IPet
{
    event EventHandler PetSound;
    void Speak();
}

public class HomePet : IPet
{
    public event EventHandler PetSound;
    public string Name { get; set; }

    public HomePet(string name)
    {
        Name = name;
    }

    // New protected method to raise the event.
    protected void RaisePetSound()
    {
        PetSound?.Invoke(this, EventArgs.Empty);
    }

    public virtual void Speak()
    {
        RaisePetSound();
    }
}

public class Dog : HomePet
{
    public Dog(string name) : base(name) { }

    public override void Speak()
    {
        RaisePetSound();
    }
}

public class Cat : HomePet
{
    public Cat(string name) : base(name) { }

    public override void Speak()
    {
        RaisePetSound();
    }
}

public class Parrot : HomePet
{
    public Parrot(string name) : base(name) { }

    public override void Speak()
    {
        RaisePetSound();
    }
}
