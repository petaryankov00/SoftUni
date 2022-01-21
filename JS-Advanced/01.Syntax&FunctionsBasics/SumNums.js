function solve(n,m){
    let min = Number(n);
    let max = Number(m);
    let result = 0;
    for (let i = min; i <= max; i++) {
         result+=i;
    }

    return result;
}

console.log(solve('1','5'));