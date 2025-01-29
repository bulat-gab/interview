namespace DesignPatterns.Visitor;


public interface IBuilding
{
    void Accept(IVisitor visitor);
}

public class Office : IBuilding
{
    public int EmployeesCount { get; init; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitOffice(this);
    }
}

public class ResidentialBuilding : IBuilding
{
    public int ApartmentsCount { get; init; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitResidential(this);
    }
}

public class Restaurant : IBuilding
{
    public string Name { get; init; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitRestaurant(this);
    }
}

public interface IVisitor
{
    decimal VisitOffice(Office building);
    decimal VisitResidential(ResidentialBuilding building);
    decimal VisitRestaurant(Restaurant restaurant);
}

public class InsuranceAgent : IVisitor
{
    public decimal VisitOffice(Office building)
    {
        int insuranceCoefficient = 1;
        if (building.EmployeesCount >= 1000)
        {
            insuranceCoefficient = 2;
        }
        
        decimal insurancePrice = building.EmployeesCount * insuranceCoefficient;
        Console.WriteLine($"{GetType().Name} has visited {building.GetType().Name}. Insurance price: ${insurancePrice}.");
        return insurancePrice;
    }

    public decimal VisitResidential(ResidentialBuilding building)
    {
        decimal insurancePrice = 1000 * building.ApartmentsCount;
        Console.WriteLine($"{GetType().Name} has visited {building.GetType().Name}. Insurance price: ${insurancePrice}.");
        return insurancePrice;
    }

    public decimal VisitRestaurant(Restaurant restaurant)
    {
        int insuranceCoefficient = 1;
        if (restaurant.Name.Contains("Premium"))
        {
            insuranceCoefficient = 10;
        }
        
        decimal insurancePrice = 20000m * insuranceCoefficient;
        Console.WriteLine($"{GetType().Name} has visited {restaurant.GetType().Name} '{restaurant.Name}'. Insurance price: ${insurancePrice}.");
        return insurancePrice;
    }
}

public class InsuranceAgentVisitorExample
{
    public static void RunInsuranceAgentVisitorExample()
    {
        var agent = new InsuranceAgent();
        var bigOffice = new Office()
        {
            EmployeesCount = 1000,
        };
        var smallOffice = new Office()
        {
            EmployeesCount = 50,
        };
        
        var cheapRestaurant = new Restaurant()
        {
            Name = "CheapAss",
        };
        var premiumRestaurant = new Restaurant()
        {
            Name = "Premium Michelin Pasta",
        };
        
        var residential = new ResidentialBuilding()
        {
            ApartmentsCount = 40
        };
        
        var buildings = new List<IBuilding>() {bigOffice, smallOffice, residential, cheapRestaurant, premiumRestaurant};
        foreach (var b in buildings)
        {
            b.Accept(agent);
        }
    }
}

/*
 * Output:

InsuranceAgent has visited Office. Insurance price: $2000.
InsuranceAgent has visited Office. Insurance price: $50.
InsuranceAgent has visited ResidentialBuilding. Insurance price: $40000.
InsuranceAgent has visited Restaurant 'CheapAss'. Insurance price: $20000.
InsuranceAgent has visited Restaurant 'Premium Michelin Pasta'. Insurance price: $200000.

*/