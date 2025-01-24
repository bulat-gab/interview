using CsharpFeatures;

//Demo.CheckObject();


//var customAwaitable = await new CustomAwaitable();
//Console.WriteLine($"Custom Awaitable: {customAwaitable}"); // Custom Awaitable: 42


// var semaphoreSlimExample = new SemaphoreSlimExample();
// await semaphoreSlimExample.RunExample();


var covaContraExample = new CovarianceAndContravarianceExample();
covaContraExample.RunCovarianceExample();
covaContraExample.RunContravarianceExample();