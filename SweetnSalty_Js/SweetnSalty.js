const { Console } = require("console");

// intitialize counters
let sweetCounter = 0;
let saltyCounter = 0;
let sweetNSaltyCounter = 0;
// initialize arrays since javascript will always create a new line with console.log
let array = [];
let arraytmp = [];
// for loop 1-1000
for (let i = 1; i <= 1000; i++){
        //check if multiple of 3 and 5
        if (i % 3 == 0 && i % 5 == 0){
           
        array[i - 1] = 'SweetnSalty';
            sweetNSaltyCounter++;
        }
        // check if multiple of 3
        else if (i % 3 == 0){
            array[i - 1] = 'Sweet';
            sweetCounter++;
        }
        //check if multiple of 5
        else if(i % 5 == 0){
           
            array[i - 1] = 'Salty';
            saltyCounter++;
        }
        else{
            array[i - 1] = i;
        }
        
    
    
}

for (i = 0; i < array.length; i++){
    arraytmp.push(array[i]);
    // check if it is the 20th element of an the array to create the grouping with arraytmp
    if(arraytmp.length == 20){
        console.log(arraytmp);
        // reset the array
        arraytmp = [];
    }
}
// print the counters
console.log('SweetnSalty Counter: ' + sweetNSaltyCounter);
console.log('Sweet Counter: ' + sweetCounter);
console.log("Salty Counter: " + saltyCounter);