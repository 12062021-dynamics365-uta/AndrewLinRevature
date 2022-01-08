// initialize elements used in the webpage
let header = document.createElement('h1');
document.body.appendChild(header);
header.innerText = 'Welcome to SweetnSaltyInteractive!' 
let inputElemStarting = document.createElement('input');

let inputElemFinal = document.createElement('input');

let enterButton = document.createElement('button');
document.body.appendChild(enterButton);

let description = document.createElement('p');
document.body.appendChild(description);
description.innerText = 'Welcome to a program called SweetnSalty! \n You will enter a starting number and a final number by typing the number into the input box and pressing the Enter key on your keyboard.  \n The program will then print all the numbers between your starting number and your ending number and any multiple of 3 will be replaced with Sweet and any number with the multiple of 5 will be replaced with Salty.  \n Any number that is a multiple of 3 and a multiple of 5 will be printed out as SweetnSalty.  \n The numbers need to be non negative and the difference bewteen the numbers should be no less than 200 and no greater than 10,000 \n There will be a counter at the end the list telling you how many numbers were printed as Sweet, Salty, or SweetnSalty. \n  Click on the buttons to continue to the next step. \n Enjoy!'
enterButton.innerText = 'Enter into SweetNSaltyInteractive';
let p = document.createElement('p');
let enterButton1 = document.createElement('button');
let header1 = document.createElement('h1');
let enterButton2 = document.createElement('button');
let header2 = document.createElement('h1');
let sweetCount = document.createElement('li');
let saltyCount = document.createElement('li');
let sweetnSaltyCount = document.createElement('li');
let errorMessage = document.createElement('li');
let successMessage = document.createElement('li');
let span = document.createElement('Span');
let restart = document.createElement('button');
restart.innerText = 'Restart Program'; 
let startingNumber = 0;
let endingNumber = 0;
let sweetnSaltyCounter = 0;
let sweetCounter = 0;
let saltyCounter = 0;
let grouping = 0;


// checking if number user entered is non negative and actually a number and not a char or string and prints a message accordingly
function isValidInput(number){
    if (number < 0 || isNaN(number)){
        errorMessage.classList.add("error");
        errorMessage.textContent = 'The number needs to be non negative and actually a number';
        document.body.appendChild(errorMessage);
        alert('The number needs to be non negative and actually a number');
        return false;
    }
        else {
            successMessage.classList.add("CorrectInput");
            successMessage.textContent = 'Valid Number!';
            document.body.appendChild(successMessage);
            return true;
        }     
}
// comparing the 2 nummbers to check if the difference matches the requirements and prints a message accordingly
function compareNumbers(number1, number2){
    if((number2 - number1) < 200 || (number2 - number1) > 10000){
        errorMessage.classList.add("error");
        errorMessage.textContent = 'The difference between the starting and final numbers need to be at least 200 apart and no more than 10,000 apart';
        document.body.appendChild(errorMessage);
        alert('The difference between the starting and final numbers need to be at least 200 apart and no more than 10,000 apart');
        return false;
    }
    else if(number1 > number2){
        errorMessage.classList.add("error");
        errorMessage.textContent = 'The starting number should be less than the final number';
        alert('The starting number should be less than the final number');
        document.body.appendChild(errorMessage);
        return false;
    }
    else{
        successMessage.classList.add("CorrectInput");
        successMessage.textContent = 'The difference between numbers is greater than 200 and less than 10,000!';
        document.body.appendChild(successMessage);
        return true;
    }
}
// first button clears the first page and creates the new page
enterButton.addEventListener('click', (e) => {
header1.innerText = 'Please enter a starting number';
description.remove();
header.remove();
enterButton.remove();
document.body.appendChild(header1);
document.body.appendChild(inputElemStarting);
enterButton1.innerText = 'Go to enter final number';
document.body.appendChild(enterButton1);

});


// second button clears the second page and creates the new page
enterButton1.addEventListener('click', (e) =>{

enterButton2.innerText = 'Go start SweetnSalty Program';
  
  header2.innerText = 'Please enter a final number';
  errorMessage.remove();
  successMessage.remove();
  header1.remove();
  inputElemStarting.remove();
  enterButton1.remove();
  document.body.appendChild(header2);
  document.body.appendChild(inputElemFinal);
  document.body.appendChild(enterButton2);
  
});
// will take user input and see if it causes any errors 
inputElemStarting.addEventListener('keydown', (e) =>{
    if(e.key == 'Enter'){
    startingNumber = parseInt(inputElemStarting.value);
    isValidInput(startingNumber); 
    }
})

// will take user input and see if it causes any errors 
inputElemFinal.addEventListener('keydown', (e) => {
  if (e.key == 'Enter'){
    endingNumber = parseInt(inputElemFinal.value);
    isValidInput(endingNumber);
    compareNumbers(startingNumber,endingNumber);
  }
});
// last button clears the 3rd page and starts the sweetnsalty program
enterButton2.addEventListener('click', (e) =>{
    errorMessage.remove();
    successMessage.remove();
    header2.remove();
    enterButton2.remove();
    inputElemFinal.remove();
    enterSweetnSalty(startingNumber,endingNumber);
    
});

// sweet and salty function that uses the starting and ending numbers that the user had inputted
function enterSweetnSalty(startingNumber, endingNumber){
 for (let i = startingNumber; i <= endingNumber; i++){
    document.body.appendChild(p);
    grouping++; 
    if(i % 3 == 0 && i % 5){
        let sweetnSalty = document.createElement('span');
        sweetnSaltyCounter++;
        sweetnSalty.classList.add("isSweetnSalty");
         sweetnSalty.textContent = 'SweetnSalty';
         p.append(sweetnSalty);

     }
     else if(i % 3 == 0){
        let sweet = document.createElement('span') 
        sweetCounter++;
         sweet.classList.add("isSweetnSalty");
         sweet.textContent = 'Sweet';
         p.append(sweet);
     }
     else if( i % 5 == 0){
        let salty = document.createElement('span');
        saltyCounter++;
         salty.classList.add("isSweetnSalty");
         salty.textContent = 'Salty';
         p.append(salty);
     }
     else{
        if(i >= 1000){
            p.append(`${i.toLocaleString()}`);
        }
        else {
            p.append(`${i}`);
        }
    }
       // if the number is a multiple of 40, create a new line or if its the last number
        if(grouping % 40 == 0 || grouping == endingNumber){
            p = document.createElement('p');
            document.body.appendChild(p)

     }
     
     p.append(' ');
 }
   // print counters
 document.body.appendChild(sweetnSaltyCount);
 document.body.appendChild(saltyCount);
 document.body.appendChild(sweetCount);
 document.body.appendChild(restart);
 sweetnSaltyCount.innerText = 'SweetnSalty Counter:  ' + sweetnSaltyCounter;
 
 sweetCount.innerText = 'Sweet Counter:  ' + sweetCounter;

 saltyCount.innerText = 'Salty Counter:  ' + saltyCounter;

 
}
// restart the program if button is pressed
restart.addEventListener('click' , (e) => {
    document.body.innerHTML = ' ';
    document.body.appendChild(header);
    document.body.appendChild(enterButton);
    document.body.appendChild(description);
});