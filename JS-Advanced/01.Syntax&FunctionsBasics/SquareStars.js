function solve(size = 5){
    let output = '';
    for (let i = 1; i <= size; i++) {
        for (let j = 0; j < size; j++) {
            output+='* ';
        }
        output+='\n';
    }
    return output;
}

console.log(solve());