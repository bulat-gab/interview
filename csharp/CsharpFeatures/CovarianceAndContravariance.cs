namespace CsharpFeatures;

public class CovarianceAndContravarianceExample
{
    public void RunCovarianceExample()
    {
        IProducer<Dog> dogProducer = new DogProducer();
        IProducer<Animal> animalProducer = dogProducer; // will not compile unless IProducer declared with 'out'

        dogProducer.Produce();
    }

    public void RunContravarianceExample()
    {
        IConsumer<Animal> animalConsumer = new AnimalConsumer();
        IConsumer<Dog> dogConsumer = animalConsumer; // will not compile unless IConsumer declared with 'in'
        
        dogConsumer.Consume(new Dog()); // Accepts a Dog and processes it as an Animal
    }
}

public class Animal {}
public class Dog : Animal {}
public class Cat : Animal {}

public interface IProducer<out T> // 'out' enables covariance, i.e. subclasses can be assigned to parent classes 
{
    T Produce();
}

public class DogProducer : IProducer<Dog>
{
    public Dog Produce()
    {
        Console.WriteLine($"Produced an animal of type {nameof(Dog)}");
        return new Dog();
    }
}

public interface IConsumer<in T>
{
    void Consume(T item);
}

public class AnimalConsumer : IConsumer<Animal>
{
    public void Consume(Animal item)
    {
        Console.WriteLine($"Consumed an animal of type {item.GetType().Name}");
    }
}