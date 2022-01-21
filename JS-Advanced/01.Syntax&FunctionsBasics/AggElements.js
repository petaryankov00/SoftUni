function solve(arr){
    let sum = 0;
    let reverseSum = 0;
    let concat = '';
    for (let i = 0; i < arr.length; i++) {
        let value = arr[i];
        sum+=value;
    }

    for (let i = 0; i < arr.length; i++) {
        let inverseValue = 1/arr[i];
        reverseSum+=inverseValue;
    }
   for (let i = 0; i < arr.length; i++) {
        let stringValue = arr[i].toString();
        concat+=stringValue;
   }
    console.log(sum);
    console.log(reverseSum);
    console.log(concat);
}

solve([1, 2, 3]);

