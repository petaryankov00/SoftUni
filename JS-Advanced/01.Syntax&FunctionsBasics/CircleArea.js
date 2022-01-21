function solve(a){
    let result;
    if (typeof(a) == 'number') {
        result = `${(Math.PI * (a*a)).toFixed(2)}`
    } else{
        result = `We can not calculate the circle area, because we receive a ${typeof(a)}.`
    }
    return result;
    
}

let output = solve(5);
console.log(output);