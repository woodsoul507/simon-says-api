# Simon Says API

## Description
Classic Simon Says game. Get an array of numbers where each number is a Simon's instruction. Post exactly the same array to get the array once again with a new number/instruction into it. Repeat the process until you fail repeating the array of numbers/instructions.

## Usage <a name = "usage"></a>
Get the initial array.
The query param interactWaitMinutes indicate how many time the Simon game will be alive. If your current game does not get any interaction within the interactWaitMinutes then it will be removed.

Also maxValue query param means the higher a number can be in the array. maxValue = 4 means the numbers into the array can be any between 1, 2, 3, 4

```
Default values without params interactWaitMinutes = 5 and maxValue = 4
GET /SimonSays

or

Example of custom interactWaitMinutes and maxValue query parameter
GET /SimonSays?interactWaitMinutes=2&maxValue=6
```

Post your response.
If your response has the same values in the same order than the previous Simon Says array you will get the array once again with a new number added at the tail.
```
POST /SimonSays
{
    "id": "811f2c97-1bdb-4be2-b610-1920a112e2e0-258333523301",
    "says": [
       2,
       4
    ]
}
```

### About the id property
The id property is always required since it allows the server to know which Simon Says game you want to interact with. So you should always include the same id for your current game.

### Failing
If you fail on the values or order you will get a No Content 204 response and the game will be remove of the server.
You will also get a 204 response if you input an incorrect id property.

## License
This project is under MIT license.