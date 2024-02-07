using advent_14;

// parse reflector dish configuration
// var dish = DishParser.Parse("configurations/example.dish");
var dish = DishParser.Parse("configurations/input.dish");

// Create reflector dish and print current state
var reflectorDish = new ReflectorDish(dish);

// we till the lever which causes the round rocks to slide north
reflectorDish.TillLever();

// get the load on the north support beam
var totalLoad = reflectorDish.GetNorthLoad();
Console.WriteLine($"Total load on north support beam: {totalLoad}");

// PART 2
var loadAfterCycles = reflectorDish.MultipleSpinCycles(1000000000);
Console.WriteLine($"Total load on north support beam: {loadAfterCycles}");